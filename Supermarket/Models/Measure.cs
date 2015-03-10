namespace Supermarket.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Measure
    {
        [Key]
        public int MeasureId { get; set; }

        [Required]
        [Display(Name = "Measure")]
        public string MeasureName { get; set; }
    }
}