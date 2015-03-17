namespace Supermarket.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    public partial class Vendor
    {
        public Vendor()
        {
            this.Products = new HashSet<Product>();
        }

        [Key]
        [Column("VENDOR_ID")]
        public int VendorId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Column("VENDOR_NAME")]
        public string VendorName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}