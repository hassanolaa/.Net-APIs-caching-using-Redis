using testRedis.data.models;

namespace testRedis.Services.contarcts
{
    public interface IProductServices
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        String CreateProduct(Product product);
        String UpdateProduct(int id, Product product);
        String DeleteProduct(int id);
    }
}
