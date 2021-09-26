using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using NflStats.Data.Contexts;
using NflStats.Data.DataObjects;
using NflStats.Data.Repositories;
using NflStats.Roster.Loader.Configuration;
using NflStats.Roster.Loader.Models;
using Serilog;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NflStats.Roster.Loader
{
    class Program
    {
        static void Main()
        {
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);

            var provider = services.BuildServiceProvider();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Fatal)
                .WriteTo.Console(Serilog.Events.LogEventLevel.Information)
                .CreateLogger();

            var logger = provider.GetService<ILogger<Program>>();
            var settings = provider.GetService<AppSettings>();

            logger.LogInformation("PRESS ANY KEY TO LOAD ROSTERS");
            Console.ReadKey();

            if (Directory.Exists(settings.SourceFolder))
            {
                List<string> files = Directory.GetFiles(settings.SourceFolder).ToList();

                Parallel.ForEach(files, new ParallelOptions { MaxDegreeOfParallelism = 5 }, (item) =>
                {
                    logger.LogInformation($"Processing Roster: {item}");
                    string json = File.ReadAllText(item);

                    if (!string.IsNullOrEmpty(json))
                    {
                        var jsonSettings = new JsonSerializerSettings()
                        {
                            MissingMemberHandling = MissingMemberHandling.Ignore,
                            NullValueHandling = NullValueHandling.Ignore
                        };
                        List<RosterModel> models = JsonConvert.DeserializeObject<List<RosterModel>>(json, jsonSettings);

                        var context = provider.GetService<SqlContext>();
                        var repo = new SqlRespository(context);

                        foreach (RosterModel model in models)
                        {
                            var player = repo.GetPlayer(model.Url.Replace("http://", "https://"));

                            if (player == null)
                            {
                                logger.LogInformation($"Player not found, Adding {model.Name}");
                                player = new Player()
                                {
                                    Url = model.Url,
                                    Name = model.Name,
                                    Position = model.Position                                 
                                };
                                player = repo.Save(player);
                            }

                            var team = repo.GetTeam(model.Team.ToUpper());

                            if (player != null && team != null)
                            {
                                var entry = new RosterEntry()
                                {
                                    TeamId = team.Id,
                                    PlayerId = player.Id

                                };

                                if (repo.Exists(entry))
                                {
                                    var original = repo.GetRosterEntries().Where(c => c.PlayerId == entry.PlayerId && c.TeamId == team.Id).FirstOrDefault();
                                    if (original != null)
                                    {
                                        entry.Id = original.Id;
                                    }
                                    
                                }
                                repo.Save(entry);
                            }
                            else
                            {
                                logger.LogWarning($"Player {model.Name} not present");
                            }
                        }
                    }
                    else
                    {
                        logger.LogWarning($"File {item} is empty");
                    }
                });
            }
            else
            {
                logger.LogWarning($"NO FILES IN DIRECTORY {settings.SourceFolder}");
            }
            
            logger.LogInformation("DONE");
            Console.ReadKey();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(config => config.AddSerilog());

            var settings = new AppSettings();
            var config = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            config.GetSection("application").Bind(settings);
            services.AddDbContext<SqlContext>(options => options.UseSqlServer(settings.ConnectionString), ServiceLifetime.Transient);
            services.AddSingleton(settings);

        }
    }
}
