namespace Supermarket.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sql : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ExpenseId = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(nullable: false),
                        ExpenseDate = c.DateTime(nullable: false),
                        ExpenseAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ExpenseId)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.VendorId);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        VendorId = c.Int(nullable: false, identity: true),
                        VendorName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.VendorId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        ProductPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MeasureId = c.Int(nullable: false),
                        VendorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Measures", t => t.MeasureId, cascadeDelete: true)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.MeasureId)
                .Index(t => t.VendorId);
            
            CreateTable(
                "dbo.Measures",
                c => new
                    {
                        MeasureId = c.Int(nullable: false, identity: true),
                        MeasureName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.MeasureId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        SupermarketId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        DateSold = c.DateTime(nullable: false),
                        Quantity = c.Long(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SaleSum = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SaleId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Supermarkets", t => t.SupermarketId, cascadeDelete: true)
                .Index(t => t.SupermarketId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Supermarkets",
                c => new
                    {
                        SupermarketId = c.Int(nullable: false, identity: true),
                        SupermarketName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.SupermarketId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "SupermarketId", "dbo.Supermarkets");
            DropForeignKey("dbo.Sales", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Expenses", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.Products", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.Products", "MeasureId", "dbo.Measures");
            DropIndex("dbo.Sales", new[] { "ProductId" });
            DropIndex("dbo.Sales", new[] { "SupermarketId" });
            DropIndex("dbo.Products", new[] { "VendorId" });
            DropIndex("dbo.Products", new[] { "MeasureId" });
            DropIndex("dbo.Expenses", new[] { "VendorId" });
            DropTable("dbo.Supermarkets");
            DropTable("dbo.Sales");
            DropTable("dbo.Measures");
            DropTable("dbo.Products");
            DropTable("dbo.Vendors");
            DropTable("dbo.Expenses");
        }
    }
}
