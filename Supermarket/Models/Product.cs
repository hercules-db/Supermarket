namespace Supermarket.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Product")]
        public string ProductName { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }

        [Required]
        public int MeasureId { get; set; }
        public virtual Measure Measure { get; set; }

        [Required]
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}