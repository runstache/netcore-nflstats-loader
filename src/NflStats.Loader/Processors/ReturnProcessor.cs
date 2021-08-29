using NflStats.Data.Contexts;
using NflStats.Data.DataObjects;
using NflStats.Data.Repositories;
using NflStats.Loader.Models;
using NflStats.Loader.Transformers;
using System.Collections.Generic;

namespace NflStats.Loader.Processors
{
    public class ReturnProcessor : BasePlayerStatProcessor, IProcessor<ReturnModel>
    {
        private readonly IRepository repo;
        public ReturnProcessor(SqlContext ctx) : base(ctx)
        {
            repo = new SqlRespository(ctx);
        }

        public void ProcessItems(List<ReturnModel> models, ScheduleItem schedule)
        {
            var transformer = new ReturnTransformer();
            foreach(var model in models)
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
