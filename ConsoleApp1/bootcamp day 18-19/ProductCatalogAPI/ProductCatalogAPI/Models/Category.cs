using System.ComponentModel.DataAnnotations;

namespace ProductCatalogAPI.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Category name must be between 2 and 50 characters")]
        public string Name { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters")]
        public string? Description { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}