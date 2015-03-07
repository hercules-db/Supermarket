namespace Supermarket.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Measure
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Measure Name")]
        public string MeasureName { get; set; }
    }
}