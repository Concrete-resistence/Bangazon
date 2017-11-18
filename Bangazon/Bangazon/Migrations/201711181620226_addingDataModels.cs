namespace Bangazon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingDataModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Paid = c.Boolean(nullable: false),
                        DeliveryLocation = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        DelivertDate = c.DateTime(nullable: false),
                        Delivery = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        ProductLocation = c.String(nullable: false),
                        ProductDescription = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductsOrders",
                c => new
                    {
                        Products_Id = c.Int(nullable: false),
                        Orders_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Products_Id, t.Orders_Id })
                .ForeignKey("dbo.Products", t => t.Products_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Orders_Id, cascadeDelete: true)
                .Index(t => t.Products_Id)
                .Index(t => t.Orders_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductsOrders", "Orders_Id", "dbo.Orders");
            DropForeignKey("dbo.ProductsOrders", "Products_Id", "dbo.Products");
            DropIndex("dbo.ProductsOrders", new[] { "Orders_Id" });
            DropIndex("dbo.ProductsOrders", new[] { "Products_Id" });
            DropIndex("dbo.Products", new[] { "User_Id" });
            DropTable("dbo.ProductsOrders");
            DropTable("dbo.Types");
            DropTable("dbo.Payments");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.Categories");
        }
    }
}
