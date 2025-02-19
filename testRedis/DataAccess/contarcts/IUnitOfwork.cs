namespace testRedis.data.contarcts
{
    public interface IUnitOfwork
    {
        ICatgeoryRepo catgeoryRepo { get; }
        IProductRepo productRepo { get; }

        void Save();
    }
}
