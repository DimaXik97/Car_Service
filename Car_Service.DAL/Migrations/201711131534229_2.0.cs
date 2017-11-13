namespace Car_Service.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "DateStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reservations", "DateEnd", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reservations", "Date");
            DropColumn("dbo.Reservations", "TimeStart");
            DropColumn("dbo.Reservations", "TimeEnd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "TimeEnd", c => c.String());
            AddColumn("dbo.Reservations", "TimeStart", c => c.String());
            AddColumn("dbo.Reservations", "Date", c => c.String());
            DropColumn("dbo.Reservations", "DateEnd");
            DropColumn("dbo.Reservations", "DateStart");
        }
    }
}
