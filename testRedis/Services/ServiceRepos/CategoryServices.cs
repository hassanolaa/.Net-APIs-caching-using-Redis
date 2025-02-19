using testRedis.data.contarcts;
using testRedis.data.models;
using testRedis.Services.contarcts;

namespace testRedis.Services.ServiceRepos
{
    public class CategoryServices : ICategoryServices
    {
        readonly IUnitOfwork _unitOfwork;

        public CategoryServices(IUnitOfwork unitOfwork)
        {
            this._unitOfwork = unitOfwork;
        }
        public string CreateCategory(Category category)
        {
            try
            {
               

                _unitOfwork.catgeoryRepo.Add(category);
                _unitOfwork.Save();

                return "Category created successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteCategory(int id)
        {
            try
            {
                var category = _unitOfwork.catgeoryRepo.FindById(id);
                if (category == null)
                {
                    return "Category not found";
                }
                _unitOfwork.catgeoryRepo.Delete(id);
                _unitOfwork.Save();
                return "Category deleted successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IEnumerable<Category> GetAllCategories()
        {
          return _unitOfwork.catgeoryRepo.GetAll();
        }

        public Category GetCategoryById(int id)
        {
           return _unitOfwork.catgeoryRepo.FindById(id);
        }

        public string UpdateCategory(int id, Category category)
        {
            try
            {
              var category_ =  _unitOfwork.catgeoryRepo.FindById(id);
                if (category_ == null)
                {
                    return "Category not found";
                }
                category_.Name = category.Name;
                _unitOfwork.catgeoryRepo.Update(category_);
                _unitOfwork.Save();
                return "Category updated successfully";

        }catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
