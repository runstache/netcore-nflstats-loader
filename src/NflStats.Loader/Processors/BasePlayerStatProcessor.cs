using NflStats.Data.Contexts;
using NflStats.Data.DataObjects;
using NflStats.Data.Repositories;
using NflStats.Loader.Models;
using NflStats.Loader.Transformers;

namespace NflStats.Loader.Processors
{
    public class BasePlayerStatProcessor : BaseProcessor
    {
        private readonly IRepository repo;

        protected BasePlayerStatProcessor(SqlContext ctx) : base(ctx)
        {
           repo = new SqlRespository(ctx);
        }

        protected Player ProcessPlayer(PlayerModel model)
        {
            ITransformer<PlayerModel, Player> transformer = new PlayerTransformer();

            // Transform the Player
            var player = transformer.Transform(model);
            if (repo.Exists(player))
            {
                var original = repo.GetPlayer(player.Url);
                player.Id = original.Id;
            }
            return repo.Save(player);
        }

        protected static void AddCommonInfo<T>(T stat, long playerId, ScheduleItem schedule) where T : BasePlayerStat
        {
            AddCommonInfo(stat, schedule);
            stat.PlayerId = playerId;
        }

        
        protected void AddOriginalId<TEntity>(TEntity stat) where TEntity : BasePlayerStat
        {
            AddOriginalId(stat, c => c.PlayerId == stat.PlayerId && c.ScheduleId == stat.ScheduleId);
        }        

    }
}
