using testRedis.data.contarcts;
using testRedis.data.models;
using testRedis.Services.contarcts;

namespace testRedis.Services.ServiceRepos
{
    public class ProductServices : IProductServices
    {

        readonly IUnitOfwork _unitOfwork;

        public ProductServices(IUnitOfwork unitOfwork)
        {
            this._unitOfwork = unitOfwork;
        }
        public String CreateProduct(Product product)
        {
            try
            {
                _unitOfwork.productRepo.Add(product);
                _unitOfwork.Save();

                return "Product created successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public String DeleteProduct(int id)
        {
            try
            {
                Product product = _unitOfwork.productRepo.FindById(id);
                if (product == null)
                {
                    return "Product not found";
                }
                _unitOfwork.productRepo.Delete(id);
                _unitOfwork.Save();

                return "Product deleted successfully";
            } catch (Exception ex) {
                return ex.Message;
            }
           
        }

        public IEnumerable<Product> GetAllProducts()
        {
          return  _unitOfwork.productRepo.GetAll();
        }

        public Product GetProductById(int id)
        {
            return _unitOfwork.productRepo.FindById(id);
        }

        public String UpdateProduct(int id, Product product)
        {
            try {

                Product productToUpdate = _unitOfwork.productRepo.FindById(id);
                if (productToUpdate == null)
                {
                    return "Product not found";
                }
                productToUpdate.Name = product.Name;
                productToUpdate.Description = product.Description;
                productToUpdate.Price = product.Price;
                productToUpdate.CategoryId = product.CategoryId;
                _unitOfwork.productRepo.Update(productToUpdate);
                _unitOfwork.Save();

                return "Product updated successfully";
            } catch (Exception ex) {
                return ex.Message;
            
            } 
        }
    }
}
