using System.ComponentModel.DataAnnotations;

namespace BlazorTrainingDemo.Modules.Products
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }

        public string Description { get; set; }
    }
}
