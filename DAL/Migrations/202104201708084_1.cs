namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReservationStatuses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "LengthMin", c => c.Int(nullable: false));
            AddColumn("dbo.Reservations", "StatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reservations", "StatusId");
            AddForeignKey("dbo.Reservations", "StatusId", "dbo.ReservationStatuses", "Id", cascadeDelete: true);
            DropColumn("dbo.Movies", "DurationMin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "DurationMin", c => c.Int(nullable: false));
            DropForeignKey("dbo.Reservations", "StatusId", "dbo.ReservationStatuses");
            DropIndex("dbo.Reservations", new[] { "StatusId" });
            DropColumn("dbo.Reservations", "StatusId");
            DropColumn("dbo.Movies", "LengthMin");
            DropTable("dbo.ReservationStatuses");
        }
    }
}
