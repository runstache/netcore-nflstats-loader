using NflStats.Data.Contexts;
using NflStats.Data.DataObjects;
using NflStats.Data.Repositories;
using NflStats.Loader.Models;
using NflStats.Loader.Transformers;
using System.Collections.Generic;

namespace NflStats.Loader.Processors
{
    public class PassingProcessor : BasePlayerStatProcessor, IProcessor<PassingModel>
    {
        private readonly IRepository repo;
        public PassingProcessor(SqlContext ctx) : base(ctx)
        {
            repo = new SqlRespository(ctx);
        }

        public void ProcessItems(List<PassingModel> models, ScheduleItem schedule)
        {
            ITransformer<PassingModel, PassingStat> passingTransformer = new PassingTransformer();

            foreach (PassingModel model in models)
            {
                // Transform the Player
                var player = ProcessPlayer(model.Player);
                var stat = passingTransformer.Transform(model);
                AddCommonInfo(stat, player.Id, schedule);
                AddOriginalId(stat);
                repo.Save(stat);
            }
        }
    }
}
