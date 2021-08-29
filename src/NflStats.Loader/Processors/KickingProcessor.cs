using NflStats.Data.Contexts;
using NflStats.Data.DataObjects;
using NflStats.Data.Repositories;
using NflStats.Loader.Models;
using NflStats.Loader.Transformers;
using System.Collections.Generic;
using System.Linq;

namespace NflStats.Loader.Processors
{
    public class KickingProcessor : BasePlayerStatProcessor, IProcessor<KickingModel>
    {
        private readonly IRepository repo;

        public KickingProcessor(SqlContext ctx) : base(ctx)
        {
            repo = new SqlRespository(ctx);
        }

        public void ProcessItems(List<KickingModel> models, ScheduleItem schedule)
        {
            var transformer = new KickingTransformer();
            foreach (var model in models)
            {
                var player = ProcessPlayer(model.Player);
                var stat = transformer.Transform(model);
                AddCommonInfo(stat, player.Id, schedule);
                MergeItem(stat);
                repo.Save(stat);
            }
        }

        private void MergeItem(KickingStat stat)
        {
            if (repo.Exists(stat))
            {
                var original = repo.GetKickingStats(stat.PlayerId).Where(c => c.ScheduleId == stat.ScheduleId).FirstOrDefault();
                stat.Punts = original.Punts;
                stat.PuntInsideTwenty = original.PuntInsideTwenty;
                stat.PuntLongest = original.PuntLongest;
                stat.PuntTotalYards = original.PuntTotalYards;
                stat.AveragePunt = original.AveragePunt;
                stat.Touchbacks = original.Touchbacks;
                stat.Id = original.Id;
            }

        }
    }
}
