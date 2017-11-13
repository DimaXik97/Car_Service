namespace Car_Service.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WorkTimes", "DateStart", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WorkTimes", "DateEnd", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkTimes", "DateEnd", c => c.String());
            AlterColumn("dbo.WorkTimes", "DateStart", c => c.String());
        }
    }
}
