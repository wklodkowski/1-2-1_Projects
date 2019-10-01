namespace WpfApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInvoiceRelationForCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Invoices", "CustomerId");
            AddForeignKey("dbo.Invoices", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Invoices", new[] { "CustomerId" });
            DropColumn("dbo.Invoices", "CustomerId");
        }
    }
}
