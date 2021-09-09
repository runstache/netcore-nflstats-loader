using NflStats.Data.Contexts;
using NflStats.Data.DataObjects;
using NflStats.Data.Repositories;
using NflStats.Loader.Models;
using NflStats.Loader.Transformers;
using System.Collections.Generic;
using System.Linq;


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
                if (!string.IsNullOrEmpty(model.Player.Url))
                {
                    var player = ProcessPlayer(model.Player);
                    var stat = transformer.Transform(model);
                    AddCommonInfo(stat, player.Id, schedule);
                    MergeReturns(stat);
                    repo.Save(stat);
                }
            }
        }

        private void MergeReturns(ReturnStat stat)
        {
            var original = repo.GetReturnStats(stat.PlayerId).Where(c => c.ScheduleId == stat.ScheduleId).FirstOrDefault();
            if (original != null)
            {
                stat.Id = original.Id;
                stat.KickReturns = original.KickReturns + stat.KickReturns;
                if (original.LongReturn > stat.LongReturn)
                {
                    stat.LongReturn = original.LongReturn;
                }
                stat.Touchdowns = original.Touchdowns + stat.Touchdowns;
                stat.Yards = original.Yards + stat.Yards;
                stat.AverageReturn = stat.Yards / stat.KickReturns;
            }
        }
    }
}
