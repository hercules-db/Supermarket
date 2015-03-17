namespace Supermarket.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string ProductName { get; set; }

        [Required]
        public int MeasureId { get; set; }

        [Required]
        public int VendorId { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }

        public virtual Measure Measure { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}