namespace Supermarket.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Sale
    {
        [Key]
        public int SaleId { get; set; }

        [Required]
        public DateTime SoldTime { get; set; }

        [Required]
        public long Quantity { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int SupermarketId { get; set; }

        public virtual Product Product { get; set; }

        public virtual Supermarket Supermarket { get; set; }
    }
}