using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using NflStats.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace NflStats.Data.Repositories
{
    public class BaseRepository
    {
        private readonly SqlContext ctx;

        protected BaseRepository(SqlContext ctx)
        {
            this.ctx = ctx;
        }

        protected virtual TEntity Add<TEntity>(TEntity entity) where TEntity : class
        {
            EntityEntry<TEntity> entry = ctx.Set<TEntity>().Add(entity);
            ctx.SaveChanges();
            return entry.Entity;
        }

        protected virtual TEntity Update<TEntity>(TEntity entity) where TEntity : class
        {
            var entry = ctx.Entry(entity);
            IKey key = entry.Metadata.FindPrimaryKey();
            List<object> keyValues = new();

            foreach (IProperty prop in key.Properties)
            {
                PropertyInfo pi = prop.PropertyInfo;
                keyValues.Add(pi.GetValue(entity));
            }

            var original = ctx.Find<TEntity>(keyValues.ToArray());

            if (!entity.Equals(original))
            {
                ctx.Entry(original).CurrentValues.SetValues(entity);
            }
            ctx.SaveChanges();
            return ctx.Entry(entity).Entity;

        }

        protected virtual IQueryable<TEntity> Query<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
        {
            return ctx.Set<TEntity>().Where(expression).AsQueryable();
        }

    }
}
