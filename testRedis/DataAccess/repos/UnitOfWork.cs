using testRedis.data.contarcts;

namespace testRedis.data.repos
{
    public class UnitOfWork : IUnitOfwork
    {
        private readonly AppDbContext _db;
        private readonly IProductRepo _productRepo;
        private readonly ICatgeoryRepo _catgeoryRepo;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            _productRepo = new ProductRepo(_db);
            _catgeoryRepo = new CatgeoryRepo(_db);
        }

        public ICatgeoryRepo catgeoryRepo => _catgeoryRepo;

        public IProductRepo productRepo => _productRepo;

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
