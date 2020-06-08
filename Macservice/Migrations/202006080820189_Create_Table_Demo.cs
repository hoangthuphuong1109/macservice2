namespace Macservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_Demo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Demos",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Password = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Demos");
        }
    }
}
