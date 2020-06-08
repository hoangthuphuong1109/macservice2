namespace Macservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_colum_Chitietkhenthuong_Tienthuong : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Chitietkhenthuong", "Tienthuong", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Chitietkhenthuong", "Tienthuong", c => c.Decimal(precision: 18, scale: 0));
        }
    }
}
