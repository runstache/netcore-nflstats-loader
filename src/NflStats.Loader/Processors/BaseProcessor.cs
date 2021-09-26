using NflStats.Data.Contexts;
using NflStats.Data.DataObjects;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace NflStats.Loader.Processors
{
    public class BaseProcessor
    {
        private readonly SqlContext ctx;
        protected BaseProcessor(SqlContext ctx)
        {
            this.ctx = ctx;
        }

        protected static void AddCommonInfo<T>(T stat, ScheduleItem schedule) where T : BaseStat
        {
            stat.TeamId = schedule.TeamId;
            stat.OpponentId = schedule.OpponentId;
            stat.ScheduleId = schedule.Id;
        }

        protected void AddOriginalId<TEntity>(TEntity stat, Expression<Func<TEntity, bool>> expression) where TEntity : BaseStat
        {
            var original = ctx.Set<TEntity>().Where(expression).FirstOrDefault();
            if (original != null)
            {
                stat.Id = original.Id;
            }
        }

    }
}
