namespace Supermarket.Models.SQL
{
    using System.Collections.Generic;

    public partial class Measure
    {
        public Measure()
        {
            this.Products = new HashSet<Product>();
        }

        public int MeasureId { get; set; }

        public string MeasureName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}