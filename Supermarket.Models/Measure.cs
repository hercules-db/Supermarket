namespace Supermarket.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Measure
    {
        private ICollection<Product> products;

        public Measure()
        {
            this.Products = new HashSet<Product>();
        }

        [Key]
        public int MeasureId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string MeasureName { get; set; }

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