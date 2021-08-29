using NflStats.Data.Contexts;
using NflStats.Data.DataObjects;
using NflStats.Data.Repositories;
using NflStats.Loader.Models;
using NflStats.Loader.Transformers;
using System.Collections.Generic;

namespace NflStats.Loader.Processors
{
    public class InterceptionProcessor : BasePlayerStatProcessor, IProcessor<InterceptionModel>
    {
        private readonly IRepository repo;
        public InterceptionProcessor(SqlContext ctx) : base(ctx)
        {
            repo = new SqlRespository(ctx);
        }

        public void ProcessItems(List<InterceptionModel> models, ScheduleItem schedule)
        {
            var transformer = new InterceptionTransformer();
            foreach (var model in models)
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
