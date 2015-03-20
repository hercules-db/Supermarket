namespace Supermarket.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Sale
    {
        [Key]
        public int SaleId { get; set; }

        [Required]
        public int SupermarketId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateSold { get; set; }

        [Required]
        public long Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        public decimal SaleSum { get; set; }

        public virtual Product Product { get; set; }

        public virtual Supermarket Supermarket { get; set; }
    }
}