namespace Supermarket.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Supermarket
    {
        private ICollection<Sale> sales;
 
        public Supermarket()
        {
            this.Sales = new HashSet<Sale>();
        }

        [Key]
        public int SupermarketId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string SupermarketName { get; set; }

        public virtual ICollection<Sale> Sales
        {
            get
            {
                return this.sales;
            }

            set
            {
                this.sales = value;
            }
        }
    }
}