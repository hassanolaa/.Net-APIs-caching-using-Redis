namespace testRedis.data.contarcts
{
    public interface IBaseRepo<TEntity>
    {
        TEntity FindById(int id);

        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(int id);

    }
}
