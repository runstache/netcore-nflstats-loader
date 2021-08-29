using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Serilog;

using NflStats.Data.Contexts;
using NflStats.Data.Repositories;
using NflStats.Data.DataObjects;

using NflStats.Loader.Configuration;
using NflStats.Loader.Models;
using NflStats.Loader.Transformers;
using NflStats.Loader.Helpers;


using Newtonsoft.Json;
using NflStats.Loader.Processors;

namespace NflStats.Loader
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var provider = services.BuildServiceProvider();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Fatal)
                .WriteTo.Console(Serilog.Events.LogEventLevel.Information)
                .CreateLogger();

            var logger = provider.GetService<ILogger<Program>>();
            var settings = provider.GetService<AppSettings>();

            logger.LogInformation("READY TO BEGIN. PRESS ANY KEY TO START");
            if (Directory.Exists(settings.SourceFolder))
            {
                List<string> files = Directory.GetFiles(settings.SourceFolder).ToList();
                var jsonSettings = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                Parallel.ForEach(files, new ParallelOptions { MaxDegreeOfParallelism = 5 }, (file) =>
                {
                    var context = provider.GetService<SqlContext>();
                    var repo = new SqlRespository(context);


                    string json = File.ReadAllText(file);
                    if (!string.IsNullOrEmpty(json))
                    {
                        
                        var gameModel = JsonConvert.DeserializeObject<GameModel>(json, jsonSettings);

                        var homeTeam = repo.GetTeam(gameModel.HomeTeam);
                        var awayTeam = repo.GetTeam(gameModel.AwayTeam);
                        var typeCode = repo.GetTypeCodes().Where(c => c.Description.ToLower() == gameModel.SeasonType.ToLower()).FirstOrDefault();


                        // Build A Home Schedule Entry
                        var homeScheduleItem = new ScheduleItem()
                        {
                            GameId = DataHelper.ParseLong(gameModel.GameId),
                            WeekNumber = DataHelper.ParseInt(gameModel.WeekNumber),
                            IsHome = true,
                            OpponentId = awayTeam.Id,
                            TeamId = homeTeam.Id,
                            TypeId = typeCode.Id,
                            YearValue = DataHelper.ParseInt(gameModel.Year)
                        };
                        if (repo.Exists(homeScheduleItem))
                        {
                            var original = repo.GetScheduleItems(homeTeam.Id, typeCode.Id, true).Where(c => c.OpponentId == awayTeam.Id && c.WeekNumber == homeScheduleItem.WeekNumber).FirstOrDefault();
                            homeScheduleItem.Id = original.Id;
                        }
                        homeScheduleItem = repo.Save(homeScheduleItem);

                        // Builder an Away Schedule Entry
                        var awayScheduleItem = new ScheduleItem()
                        {
                            GameId = DataHelper.ParseLong(gameModel.GameId),
                            WeekNumber = DataHelper.ParseInt(gameModel.WeekNumber),
                            IsHome = false,
                            OpponentId = homeTeam.Id,
                            TeamId = awayTeam.Id,
                            TypeId = typeCode.Id,
                            YearValue = DataHelper.ParseInt(gameModel.Year)
                        };
                        if (repo.Exists(homeScheduleItem))
                        {
                            var original = repo.GetScheduleItems(awayTeam.Id, typeCode.Id, false).Where(c => c.OpponentId == homeTeam.Id && c.WeekNumber == awayScheduleItem.WeekNumber).FirstOrDefault();
                            awayScheduleItem.Id = original.Id;
                        }
                        awayScheduleItem = repo.Save(awayScheduleItem);

                        // Process the Model Boxscore items                       

                        // Passing
                        logger.LogInformation($"PROCESSING PASSING FOR {gameModel.GameId}");
                        var passingProcessor = provider.GetService<IProcessor<PassingModel>>();
                        passingProcessor.ProcessItems(gameModel.Boxscore.HomePassing, homeScheduleItem);
                        passingProcessor.ProcessItems(gameModel.Boxscore.AwayPassing, awayScheduleItem);


                        //Home Rushing
                        logger.LogInformation($"PROCESSING RUSHING FOR {gameModel.GameId}");
                        var rushingProcesser = provider.GetService<IProcessor<RushingModel>>();
                        rushingProcesser.ProcessItems(gameModel.Boxscore.HomeRushing, homeScheduleItem);
                        rushingProcesser.ProcessItems(gameModel.Boxscore.AwayRushing, awayScheduleItem);

                        // Receiving
                        logger.LogInformation($"PROCESSING RECEIVING FOR {gameModel.GameId}");
                        var receivingProcessor = provider.GetService<IProcessor<ReceivingModel>>();
                        receivingProcessor.ProcessItems(gameModel.Boxscore.HomeReceiving, homeScheduleItem);
                        receivingProcessor.ProcessItems(gameModel.Boxscore.AwayReceiving, awayScheduleItem);

                        // Fumbles
                        logger.LogInformation($"PROCESSING FUMBLES FOR {gameModel.GameId}");
                        var fumbleProcessor = provider.GetService<IProcessor<FumbleModel>>();
                        fumbleProcessor.ProcessItems(gameModel.Boxscore.HomeFumbles, homeScheduleItem);
                        fumbleProcessor.ProcessItems(gameModel.Boxscore.AwayFumbles, awayScheduleItem);

                        // Defense
                        logger.LogInformation($"PROCESSING DEFENSE FOR {gameModel.GameId}");
                        var defenseProcessor = provider.GetService<IProcessor<DefenseModel>>();
                        defenseProcessor.ProcessItems(gameModel.Boxscore.HomeDefense, homeScheduleItem);
                        defenseProcessor.ProcessItems(gameModel.Boxscore.AwayDefense, awayScheduleItem);

                        // Interceptions
                        logger.LogInformation($"PROCESSING INTERCEPTIONS FOR {gameModel.GameId}");
                        var interceptionProcessor = provider.GetService<IProcessor<InterceptionModel>>();
                        interceptionProcessor.ProcessItems(gameModel.Boxscore.HomeInterceptions, homeScheduleItem);
                        interceptionProcessor.ProcessItems(gameModel.Boxscore.AwayInterceptions, awayScheduleItem);

                        //Kick Returns
                        logger.LogInformation($"PROCESSING KICK RETURNS FOR {gameModel.GameId}");
                        var returnProcessor = provider.GetService<IProcessor<ReturnModel>>();
                        returnProcessor.ProcessItems(gameModel.Boxscore.HomeKickReturns, homeScheduleItem);
                        returnProcessor.ProcessItems(gameModel.Boxscore.AwayKickReturns, awayScheduleItem);

                        // Punt Returns
                        logger.LogInformation($"PROCESSING PUNT RETURNS FOR {gameModel.GameId}");
                        returnProcessor.ProcessItems(gameModel.Boxscore.HomePuntReturns, homeScheduleItem);
                        returnProcessor.ProcessItems(gameModel.Boxscore.AwayPuntReturns, awayScheduleItem);

                        // Kicking
                        logger.LogInformation($"PROCESSING KICKING FOR {gameModel.GameId}");
                        var kickingProcessor = provider.GetService<IProcessor<KickingModel>>();
                        kickingProcessor.ProcessItems(gameModel.Boxscore.HomeKicking, homeScheduleItem);
                        kickingProcessor.ProcessItems(gameModel.Boxscore.AwayKicking, awayScheduleItem);

                        // Punting
                        logger.LogInformation($"PROCESSING PUNTING FOR {gameModel.GameId}");
                        var puntingProcessor = provider.GetService<IProcessor<PuntingModel>>();
                        puntingProcessor.ProcessItems(gameModel.Boxscore.HomePunting, homeScheduleItem);
                        puntingProcessor.ProcessItems(gameModel.Boxscore.AwayPunting, awayScheduleItem);

                        // Team Stats
                        logger.LogInformation($"PROCESSING TEAM STATS FOR {gameModel.GameId}");
                        var teamStats = MatchupTransformer.Transform(gameModel.Matchup);

                        if (teamStats.TryGetValue("home", out TeamStat homeTeamStat))
                        {
                            var processor = provider.GetService<TeamStatProcessor>();
                            processor.ProcessItem(homeTeamStat, gameModel, homeTeam.Code, awayTeam.Code, homeScheduleItem);                            
                        }

                        
                        if (teamStats.TryGetValue("away", out TeamStat awayTeamStat))
                        {
                            var processor = provider.GetService<TeamStatProcessor>();
                            processor.ProcessItem(awayTeamStat, gameModel, awayTeam.Code, homeTeam.Code, awayScheduleItem);
                        }

                        //Scoreing
                        logger.LogInformation($"PROCESSING SCORING FOR {gameModel.GameId}");
                        var scoringProcessor = provider.GetService<ScoringProcessor>();
                        scoringProcessor.ProcessItems(gameModel.Matchup.Boxscore.Where(c => c.Team.ToLower() == homeTeam.Code.ToLower()).FirstOrDefault().Quarters, homeScheduleItem);
                        scoringProcessor.ProcessItems(gameModel.Matchup.Boxscore.Where(c => c.Team.ToLower() == awayTeam.Code.ToLower()).FirstOrDefault().Quarters, awayScheduleItem);
                    }

                });
            }
            else
            {
                logger.LogError($"SOURCE DIRECTORY {settings.SourceFolder} DOES NOT EXITS");
            }
            logger.LogInformation("DONE");
        }

        static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(config => config.AddSerilog());

            var config = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            var settings = new AppSettings();
            config.GetSection("application").Bind(settings);

            services.AddSingleton(settings);
            services.AddDbContext<SqlContext>(options => options.UseSqlServer(settings.ConnectionString), ServiceLifetime.Transient);

            // Register the Transformers
            services.AddSingleton(new MatchupTransformer());

            
            // Add Processors
            services.AddSingleton<IProcessor<ReceivingModel>>(provider => new ReceivingProcessor(provider.GetService<SqlContext>()));
            services.AddSingleton<IProcessor<PassingModel>>(provider => new PassingProcessor(provider.GetService<SqlContext>()));
            services.AddSingleton<IProcessor<RushingModel>>(provider => new RushingProcessor(provider.GetService<SqlContext>()));
            services.AddSingleton<IProcessor<FumbleModel>>(provider => new FumbleProcessor(provider.GetService<SqlContext>()));
            services.AddSingleton<IProcessor<DefenseModel>>(provider => new DefenseProcessor(provider.GetService<SqlContext>()));
            services.AddSingleton<IProcessor<InterceptionModel>>(provider => new InterceptionProcessor(provider.GetService<SqlContext>()));
            services.AddSingleton<IProcessor<ReturnModel>>(provider => new ReturnProcessor(provider.GetService<SqlContext>()));
            services.AddSingleton<IProcessor<KickingModel>>(provider => new KickingProcessor(provider.GetService<SqlContext>()));
            services.AddSingleton<IProcessor<PuntingModel>>(provider => new PuntingProcessor(provider.GetService<SqlContext>()));
            services.AddSingleton(provider => new ScoringProcessor(provider.GetService<SqlContext>()));
            services.AddSingleton(provider => new TeamStatProcessor(provider.GetService<SqlContext>()));


        }        
    }
}
