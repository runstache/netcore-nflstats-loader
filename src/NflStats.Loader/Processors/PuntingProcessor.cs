using NflStats.Data.Contexts;
using NflStats.Data.DataObjects;
using NflStats.Data.Repositories;
using NflStats.Loader.Models;
using NflStats.Loader.Transformers;
using System.Collections.Generic;
using System.Linq;

namespace NflStats.Loader.Processors
{
    public class PuntingProcessor : BasePlayerStatProcessor, IProcessor<PuntingModel>
    {
        private readonly IRepository repo;

        public PuntingProcessor(SqlContext ctx) : base(ctx)
        {
            repo = new SqlRespository(ctx);
        }

        public void ProcessItems(List<PuntingModel> models, ScheduleItem schedule)
        {
            var transformer = new PuntingTransformer();
            foreach (var model in models)
            {
                if (!string.IsNullOrEmpty(model.Player.Url))
                {
                    var player = ProcessPlayer(model.Player);
                    var stat = transformer.Transform(model);
                    AddCommonInfo(stat, player.Id, schedule);
                    MergeItem(stat);
                    repo.Save(stat);
                }
            }
        }
       
        private void MergeItem(KickingStat stat)
        {
            if (repo.Exists(stat))
            {
                var original = repo.GetKickingStats(stat.PlayerId).Where(c => c.ScheduleId == stat.ScheduleId).FirstOrDefault();
                stat.FieldGoals = original.FieldGoals;
                stat.LongFieldGoal = original.LongFieldGoal;
                stat.Id = original.Id;
                stat.Attempts = original.Attempts;
                stat.ExtraPointAttempts = original.ExtraPointAttempts;
                stat.ExtraPoints = original.ExtraPoints;
                stat.Points = original.Points;
            }

        }
    }
}
