namespace Supermarket.Models.SQL
{
    public partial class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int MeasureId { get; set; }

        public int VendorId { get; set; }

        public decimal ProductPrice { get; set; }

        public virtual Measure Measure { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}