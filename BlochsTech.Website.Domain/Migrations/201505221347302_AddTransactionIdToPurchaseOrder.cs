namespace BlochsTech.Website.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTransactionIdToPurchaseOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseOrders", "TransactionId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseOrders", "TransactionId");
        }
    }
}
