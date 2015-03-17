namespace Supermarket.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQL : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "HERCULES.MEASURE", newName: "Measures");
            RenameTable(name: "HERCULES.PRODUCT", newName: "Products");
            RenameTable(name: "HERCULES.VENDOR", newName: "Vendors");
            MoveTable(name: "HERCULES.Measures", newSchema: "dbo");
            MoveTable(name: "HERCULES.Products", newSchema: "dbo");
            MoveTable(name: "HERCULES.Vendors", newSchema: "dbo");
            RenameColumn(table: "dbo.Measures", name: "MEASURE_ID", newName: "MeasureId");
            RenameColumn(table: "dbo.Measures", name: "MEASURE_NAME", newName: "MeasureName");
            RenameColumn(table: "dbo.Products", name: "PRODUCT_ID", newName: "ProductId");
            RenameColumn(table: "dbo.Products", name: "PRODUCT_NAME", newName: "ProductName");
            RenameColumn(table: "dbo.Products", name: "MEASURE_ID", newName: "MeasureId");
            RenameColumn(table: "dbo.Products", name: "VENDOR_ID", newName: "VendorId");
            RenameColumn(table: "dbo.Products", name: "PRODUCT_PRICE", newName: "ProductPrice");
            RenameColumn(table: "dbo.Vendors", name: "VENDOR_ID", newName: "VendorId");
            RenameColumn(table: "dbo.Vendors", name: "VENDOR_NAME", newName: "VendorName");
            RenameIndex(table: "dbo.Products", name: "IX_MEASURE_ID", newName: "IX_MeasureId");
            RenameIndex(table: "dbo.Products", name: "IX_VENDOR_ID", newName: "IX_VendorId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Products", name: "IX_VendorId", newName: "IX_VENDOR_ID");
            RenameIndex(table: "dbo.Products", name: "IX_MeasureId", newName: "IX_MEASURE_ID");
            RenameColumn(table: "dbo.Vendors", name: "VendorName", newName: "VENDOR_NAME");
            RenameColumn(table: "dbo.Vendors", name: "VendorId", newName: "VENDOR_ID");
            RenameColumn(table: "dbo.Products", name: "ProductPrice", newName: "PRODUCT_PRICE");
            RenameColumn(table: "dbo.Products", name: "VendorId", newName: "VENDOR_ID");
            RenameColumn(table: "dbo.Products", name: "MeasureId", newName: "MEASURE_ID");
            RenameColumn(table: "dbo.Products", name: "ProductName", newName: "PRODUCT_NAME");
            RenameColumn(table: "dbo.Products", name: "ProductId", newName: "PRODUCT_ID");
            RenameColumn(table: "dbo.Measures", name: "MeasureName", newName: "MEASURE_NAME");
            RenameColumn(table: "dbo.Measures", name: "MeasureId", newName: "MEASURE_ID");
            MoveTable(name: "dbo.Vendors", newSchema: "HERCULES");
            MoveTable(name: "dbo.Products", newSchema: "HERCULES");
            MoveTable(name: "dbo.Measures", newSchema: "HERCULES");
            RenameTable(name: "HERCULES.Vendors", newName: "VENDOR");
            RenameTable(name: "HERCULES.Products", newName: "PRODUCT");
            RenameTable(name: "HERCULES.Measures", newName: "MEASURE");
        }
    }
}
