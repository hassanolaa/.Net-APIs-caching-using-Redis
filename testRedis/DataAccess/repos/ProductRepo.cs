using Microsoft.EntityFrameworkCore;
using testRedis.data.contarcts;
using testRedis.data.models;

namespace testRedis.data.repos
{
    public class ProductRepo: BaseRepo<Product>, IProductRepo
    {
        public ProductRepo(AppDbContext context): base(context)
        {
        }

        // get all products with their categories
        public override IEnumerable<Product> GetAll()
        {
            return _db.Products.Include(p => p.Category).AsEnumerable();
        }

        // get product by id with its category
        public  Product FindById(int id)
        {
            return _db.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
        }
    }
}
