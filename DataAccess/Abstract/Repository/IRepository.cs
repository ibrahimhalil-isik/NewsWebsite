namespace DataAccess.Abstract.Repository
{
    public interface IRepository<TEntity>where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        bool Delete(TEntity entity);
    }
}
