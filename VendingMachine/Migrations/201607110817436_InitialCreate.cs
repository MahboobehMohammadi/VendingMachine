namespace VendingMachine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beverages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Order = c.Short(nullable: false),
                        Beverage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Beverages", t => t.Beverage_Id)
                .Index(t => t.Beverage_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "Beverage_Id", "dbo.Beverages");
            DropIndex("dbo.Recipes", new[] { "Beverage_Id" });
            DropTable("dbo.Recipes");
            DropTable("dbo.Beverages");
        }
    }
}
