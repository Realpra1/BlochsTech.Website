namespace BlochsTech.Website.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusToPurchaseOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseOrders", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseOrders", "Status");
        }
    }
}
