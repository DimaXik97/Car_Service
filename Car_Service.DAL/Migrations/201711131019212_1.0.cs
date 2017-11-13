namespace Car_Service.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkTimes", "DateStart", c => c.String());
            AddColumn("dbo.WorkTimes", "DateEnd", c => c.String());
            DropColumn("dbo.WorkTimes", "Date");
            DropColumn("dbo.WorkTimes", "TimeStart");
            DropColumn("dbo.WorkTimes", "TimeEnd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkTimes", "TimeEnd", c => c.String());
            AddColumn("dbo.WorkTimes", "TimeStart", c => c.String());
            AddColumn("dbo.WorkTimes", "Date", c => c.String());
            DropColumn("dbo.WorkTimes", "DateEnd");
            DropColumn("dbo.WorkTimes", "DateStart");
        }
    }
}
