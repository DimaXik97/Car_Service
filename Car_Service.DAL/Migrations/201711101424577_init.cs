namespace Car_Service.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        URL = c.String(),
                        Reservation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reservations", t => t.Reservation_Id)
                .Index(t => t.Reservation_Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Purpose = c.String(),
                        BreakdownDetails = c.String(),
                        DesiredDiagnosis = c.String(),
                        Date = c.String(),
                        TimeStart = c.String(),
                        TimeEnd = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Worker_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Workers", t => t.Worker_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Worker_Id);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SurName = c.String(),
                        Telephone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        TimeStart = c.String(),
                        TimeEnd = c.String(),
                        Worker_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workers", t => t.Worker_Id)
                .Index(t => t.Worker_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkTimes", "Worker_Id", "dbo.Workers");
            DropForeignKey("dbo.Reservations", "Worker_Id", "dbo.Workers");
            DropForeignKey("dbo.Images", "Reservation_Id", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.WorkTimes", new[] { "Worker_Id" });
            DropIndex("dbo.Reservations", new[] { "Worker_Id" });
            DropIndex("dbo.Reservations", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Images", new[] { "Reservation_Id" });
            DropTable("dbo.WorkTimes");
            DropTable("dbo.Workers");
            DropTable("dbo.Reservations");
            DropTable("dbo.Images");
        }
    }
}
