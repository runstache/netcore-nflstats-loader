using NflStats.Data.Contexts;
using NflStats.Data.DataObjects;
using NflStats.Data.Repositories;
using NflStats.Loader.Models;
using NflStats.Loader.Transformers;
using System.Collections.Generic;

namespace NflStats.Loader.Processors
{
    public class FumbleProcessor : BasePlayerStatProcessor, IProcessor<FumbleModel>
    {
        private readonly IRepository repo;
        public FumbleProcessor(SqlContext ctx) : base(ctx)
        {
            repo = new SqlRespository(ctx);
        }

        public void ProcessItems(List<FumbleModel> models, ScheduleItem schedule)
        {
            ITransformer<FumbleModel, FumbleStat> transformer = new FumbleTransformer();
            foreach (FumbleModel model in models)
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
