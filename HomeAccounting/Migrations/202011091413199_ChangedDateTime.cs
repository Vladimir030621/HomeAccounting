namespace HomeAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Operations", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Operations", "Date", c => c.DateTime(nullable: false));
        }
    }
}
