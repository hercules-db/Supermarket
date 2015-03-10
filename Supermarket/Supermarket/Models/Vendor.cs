namespace Supermarket.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Vendor
    {
        [Key]
        public int VendorId { get; set; }

        [Required]
        [Display(Name = "Vendor")]
        public string VendorName { get; set; }
    }
}