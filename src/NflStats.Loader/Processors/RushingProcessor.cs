using NflStats.Data.Contexts;
using NflStats.Data.DataObjects;
using NflStats.Data.Repositories;
using NflStats.Loader.Models;
using NflStats.Loader.Transformers;
using System.Collections.Generic;

namespace NflStats.Loader.Processors
{
    public class RushingProcessor : BasePlayerStatProcessor, IProcessor<RushingModel>
    {
        private readonly IRepository repo;

        public RushingProcessor(SqlContext ctx) : base(ctx)
        {
            repo = new SqlRespository(ctx);
        }

        public void ProcessItems(List<RushingModel> models, ScheduleItem schedule)
        {
            ITransformer<RushingModel, RushingStat> transformer = new RushingTransformer();

            foreach (RushingModel model in models)
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
