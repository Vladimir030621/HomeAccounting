namespace HomeAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OperationChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Operations", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Operations", "Total");
        }
    }
}
