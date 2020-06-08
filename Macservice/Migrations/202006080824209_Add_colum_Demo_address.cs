namespace Macservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_colum_Demo_address : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Demos", "address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Demos", "address");
        }
    }
}
