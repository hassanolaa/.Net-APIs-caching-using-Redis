using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testRedis.data.models
{
    public class Product
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        // Navigation property
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
