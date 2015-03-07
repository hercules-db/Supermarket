namespace Supermarket.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Vendor
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Vendor Name")]
        public string VendorName { get; set; }
    }
}