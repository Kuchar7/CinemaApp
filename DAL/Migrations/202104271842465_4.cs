namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReserveredSeats", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.ReserveredSeats", "ScreeningId", "dbo.Screening");
            DropIndex("dbo.ReserveredSeats", new[] { "ScreeningId" });
            DropIndex("dbo.ReserveredSeats", new[] { "RoomId" });
            AddColumn("dbo.Screening", "BasicPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Reservations", "ScreeningId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reservations", "ScreeningId");
            AddForeignKey("dbo.Reservations", "ScreeningId", "dbo.Screening", "Id", cascadeDelete: true);
            DropColumn("dbo.Screening", "Price");
            DropColumn("dbo.ReserveredSeats", "ScreeningId");
            DropColumn("dbo.ReserveredSeats", "RoomId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReserveredSeats", "RoomId", c => c.Int());
            AddColumn("dbo.ReserveredSeats", "ScreeningId", c => c.Int(nullable: false));
            AddColumn("dbo.Screening", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.Reservations", "ScreeningId", "dbo.Screening");
            DropIndex("dbo.Reservations", new[] { "ScreeningId" });
            DropColumn("dbo.Reservations", "ScreeningId");
            DropColumn("dbo.Screening", "BasicPrice");
            CreateIndex("dbo.ReserveredSeats", "RoomId");
            CreateIndex("dbo.ReserveredSeats", "ScreeningId");
            AddForeignKey("dbo.ReserveredSeats", "ScreeningId", "dbo.Screening", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ReserveredSeats", "RoomId", "dbo.Rooms", "Id");
        }
    }
}
