using System.ComponentModel.DataAnnotations;

namespace testRedis.data.models
{
    public class Category
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property
        public ICollection<Product>? Products { get; set; }
    }
}
