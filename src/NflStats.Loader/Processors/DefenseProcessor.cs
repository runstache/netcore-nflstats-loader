using NflStats.Data.Contexts;
using NflStats.Data.DataObjects;
using NflStats.Data.Repositories;
using NflStats.Loader.Models;
using NflStats.Loader.Transformers;
using System.Collections.Generic;

namespace NflStats.Loader.Processors
{
    public class DefenseProcessor : BasePlayerStatProcessor, IProcessor<DefenseModel>
    {
        private readonly IRepository repo;
        public DefenseProcessor(SqlContext ctx) : base(ctx)
        {
            repo = new SqlRespository(ctx);
        }

        public void ProcessItems(List<DefenseModel> models, ScheduleItem schedule)
        {
            var transformer = new DefenseTransformer();
            foreach (var model in models)
            {
                if (!string.IsNullOrEmpty(model.Player.Url))
                {
                    var player = ProcessPlayer(model.Player);
                    var stat = transformer.Transform(model);
                    AddCommonInfo(stat, player.Id, schedule);
                    AddOriginalId(stat);
                    repo.Save(stat);
                }
            }
        }
    }
}
