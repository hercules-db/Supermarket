namespace Supermarket.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "HERCULES.MEASURE",
                c => new
                    {
                        MEASURE_ID = c.Int(nullable: false, identity: true),
                        MEASURE_NAME = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.MEASURE_ID);
            
            CreateTable(
                "HERCULES.PRODUCT",
                c => new
                    {
                        PRODUCT_ID = c.Int(nullable: false, identity: true),
                        PRODUCT_NAME = c.String(nullable: false, maxLength: 50),
                        MEASURE_ID = c.Int(nullable: false),
                        VENDOR_ID = c.Int(nullable: false),
                        PRODUCT_PRICE = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PRODUCT_ID)
                .ForeignKey("HERCULES.MEASURE", t => t.MEASURE_ID, cascadeDelete: true)
                .ForeignKey("HERCULES.VENDOR", t => t.VENDOR_ID, cascadeDelete: true)
                .Index(t => t.MEASURE_ID)
                .Index(t => t.VENDOR_ID);
            
            CreateTable(
                "HERCULES.VENDOR",
                c => new
                    {
                        VENDOR_ID = c.Int(nullable: false, identity: true),
                        VENDOR_NAME = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.VENDOR_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("HERCULES.PRODUCT", "VENDOR_ID", "HERCULES.VENDOR");
            DropForeignKey("HERCULES.PRODUCT", "MEASURE_ID", "HERCULES.MEASURE");
            DropIndex("HERCULES.PRODUCT", new[] { "VENDOR_ID" });
            DropIndex("HERCULES.PRODUCT", new[] { "MEASURE_ID" });
            DropTable("HERCULES.VENDOR");
            DropTable("HERCULES.PRODUCT");
            DropTable("HERCULES.MEASURE");
        }
    }
}
