namespace Supermarket.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public Vendor Vendor { get; set; }

        [Required]
        public Measure Measure { get; set; }
    }
}