namespace BlochsTech.Website.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb_m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Sreet = c.String(),
                        Apartament = c.String(),
                        ZipCode = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        Email = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PurchaseOrders");
        }
    }
}
