using testRedis.data.models;

namespace testRedis.Services.contarcts
{
    public interface ICategoryServices
    {

        // Get all categories
        IEnumerable<Category> GetAllCategories();

        // Get category by id
        Category GetCategoryById(int id);

        // Create a new category
        String CreateCategory(Category category);

        // Update a category
        String UpdateCategory(int id, Category category);

        // Delete a category
        String DeleteCategory(int id);

    }
}
