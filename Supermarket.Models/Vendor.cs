namespace Supermarket.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Vendor
    {
        private ICollection<Product> products;

        public Vendor()
        {
            this.Products = new HashSet<Product>();
        }

        [Key]
        public int VendorId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string VendorName { get; set; }

        public virtual ICollection<Product> Products
        {
            get
            {
                return this.products;
            }

            set
            {
                this.products = value;
            }
        }
    }
}