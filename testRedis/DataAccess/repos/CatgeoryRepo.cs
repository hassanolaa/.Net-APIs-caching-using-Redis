using testRedis.data.models;
using testRedis.data.contarcts;
using Microsoft.EntityFrameworkCore;

namespace testRedis.data.repos
{
    public class CatgeoryRepo : BaseRepo<Category> , ICatgeoryRepo
    {
        public CatgeoryRepo(AppDbContext context): base(context)
        {
        }

        // get all categories including their products
        public override IEnumerable<Category> GetAll()
        {
            return _db.Categories.Include(c => c.Products).ToList();
        }
    }
}
