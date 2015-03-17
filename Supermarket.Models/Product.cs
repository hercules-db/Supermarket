namespace Supermarket.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Product
    {

        [Key]
        [Column("PRODUCT_ID")]
        public int ProductId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Column("PRODUCT_NAME")]
        public string ProductName { get; set; }

        [Required]
        [Column("MEASURE_ID")]
        public int MeasureId { get; set; }

        [Required]
        [Column("VENDOR_ID")]
        public int VendorId { get; set; }

        [Required]
        [Column("PRODUCT_PRICE")]
        public decimal ProductPrice { get; set; }

        public virtual Measure Measure { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}