namespace Supermarket.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Expense
    {
        public int ExpenseId { get; set; }

        [Required]
        public int VendorId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpenseDate { get; set; }

        [Required]
        public decimal ExpenseAmount { get; set; }

        public Vendor Vendor { get; set; }
    }
}