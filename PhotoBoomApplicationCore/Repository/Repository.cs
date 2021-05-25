using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PhotoBoomApplicationCore.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly PhotoBoomContext _photoBoomContext;
        public Repository(PhotoBoomContext context)
        {
            _photoBoomContext = context;
        }
        public void Add(TEntity entity)
        {
            _photoBoomContext.Add(entity);
            _photoBoomContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _photoBoomContext.Remove(entity);
            _photoBoomContext.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _photoBoomContext.Set<TEntity>().Where(filter).FirstOrDefault();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? _photoBoomContext.Set<TEntity>().ToList() : _photoBoomContext.Set<TEntity>().Where(filter).ToList();
        }

        public void Update(TEntity entity)
        {
            _photoBoomContext.Update(entity);
            _photoBoomContext.SaveChanges();
        }
    }
}
