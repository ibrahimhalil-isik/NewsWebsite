using DataAccess.Abstract.Repository;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Base.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly NewsContext _newsContext;
        public GenericRepository(NewsContext newsContext)
        {
            _newsContext = newsContext;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _newsContext.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _newsContext.Set<TEntity>().Find(id);
        }

        public TEntity Add(TEntity entity)
        {
            _newsContext.Entry(entity).State = EntityState.Added;
            _newsContext.SaveChanges();
            return entity;

        }

        public TEntity Update(TEntity entity)
        {
            _newsContext.Entry(entity).State = EntityState.Modified;
            _newsContext.SaveChanges();
            return entity;
        }

        public bool Delete(TEntity entity)
        {
            try
            {
                _newsContext.Entry(entity).State = EntityState.Deleted;
                _newsContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
