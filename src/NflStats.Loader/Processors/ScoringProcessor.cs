using NflStats.Data.Contexts;
using NflStats.Data.DataObjects;
using NflStats.Data.Repositories;
using NflStats.Loader.Models;
using NflStats.Loader.Transformers;
using System.Collections.Generic;

namespace NflStats.Loader.Processors
{
    public class ScoringProcessor : BaseProcessor
    {
        private readonly IRepository repo;

        public ScoringProcessor(SqlContext ctx) : base(ctx)
        {
            repo = new SqlRespository(ctx);
        }

        public void ProcessItems(List<ScoreValueModel> models, ScheduleItem schedule)
        {
            var transformer = new ScoringTransformer();

            foreach (var model in models)
            {
                var stat = transformer.Transform(model);
                AddCommonInfo(stat, schedule);
                AddOriginalId(stat, c=>c.ScheduleId == schedule.Id && c.TeamId == schedule.TeamId && c.Quarter == stat.Quarter);
                repo.Save(stat);
            }

        }
    }
}
