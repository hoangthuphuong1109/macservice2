namespace Macservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Table_Demo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Demos", "address", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Demos", "address", c => c.String());
        }
    }
}
