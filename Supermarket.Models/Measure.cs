namespace Supermarket.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    public partial class Measure
    {
        public Measure()
        {
            this.Products = new HashSet<Product>();
        }

        [Key]
        [Column("MEASURE_ID")]
        public int MeasureId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        [Column("MEASURE_NAME")]
        public string MeasureName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}