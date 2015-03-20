/*
namespace Supermarket.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Oracle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "HERCULES.MEASURES",
                c => new
                    {
                        MEASURE_ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MEASURE_NAME = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.MEASURE_ID);
            
            CreateTable(
                "HERCULES.PRODUCTS",
                c => new
                    {
                        PRODUCT_ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PRODUCT_NAME = c.String(nullable: false, maxLength: 50),
                        PRODUCT_PRICE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MEASURE_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        VENDOR_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.PRODUCT_ID)
                .ForeignKey("HERCULES.MEASURES", t => t.MEASURE_ID, cascadeDelete: true)
                .ForeignKey("HERCULES.VENDORS", t => t.VENDOR_ID, cascadeDelete: true)
                .Index(t => t.MEASURE_ID)
                .Index(t => t.VENDOR_ID);
            
            CreateTable(
                "HERCULES.VENDORS",
                c => new
                    {
                        VENDOR_ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        VENDOR_NAME = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.VENDOR_ID);
            
            CreateTable(
                "HERCULES.SALES",
                c => new
                    {
                        SALE_ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SUPERMARKET_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        PRODUCT_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        DATE_SOLD = c.DateTime(nullable: false),
                        QUANTITY = c.Decimal(nullable: false, precision: 19, scale: 0),
                        UNIT_PRICE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SALE_SUM = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SALE_ID)
                .ForeignKey("HERCULES.PRODUCTS", t => t.PRODUCT_ID, cascadeDelete: true)
                .ForeignKey("HERCULES.SUPERMARKETS", t => t.SUPERMARKET_ID, cascadeDelete: true)
                .Index(t => t.SUPERMARKET_ID)
                .Index(t => t.PRODUCT_ID);
            
            CreateTable(
                "HERCULES.SUPERMARKETS",
                c => new
                    {
                        SUPERMARKET_ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SUPERMARKET_NAME = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.SUPERMARKET_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("HERCULES.SALES", "SUPERMARKET_ID", "HERCULES.SUPERMARKETS");
            DropForeignKey("HERCULES.SALES", "PRODUCT_ID", "HERCULES.PRODUCTS");
            DropForeignKey("HERCULES.PRODUCTS", "VENDOR_ID", "HERCULES.VENDORS");
            DropForeignKey("HERCULES.PRODUCTS", "MEASURE_ID", "HERCULES.MEASURES");
            DropIndex("HERCULES.SALES", new[] { "PRODUCT_ID" });
            DropIndex("HERCULES.SALES", new[] { "SUPERMARKET_ID" });
            DropIndex("HERCULES.PRODUCTS", new[] { "VENDOR_ID" });
            DropIndex("HERCULES.PRODUCTS", new[] { "MEASURE_ID" });
            DropTable("HERCULES.SUPERMARKETS");
            DropTable("HERCULES.SALES");
            DropTable("HERCULES.VENDORS");
            DropTable("HERCULES.PRODUCTS");
            DropTable("HERCULES.MEASURES");
        }
    }
}
*/