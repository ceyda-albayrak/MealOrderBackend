using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Core.Concretes.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, new() where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(int id)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }

        public List<TEntity> GetAll()
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().ToList();

            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
