namespace Supermarket.Models.SQL
{
    using System.Collections.Generic;

    public partial class Vendor
    {
        public Vendor()
        {
            this.Products = new HashSet<Product>();
        }

        public int VendorId { get; set; }

        public string VendorName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
