namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        DurationMin = c.Int(nullable: false),
                        Description = c.String(),
                        ImgPath = c.String(),
                        AddDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Screening",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MovieId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReserveredSeats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        ReservationId = c.Int(nullable: false),
                        ScreeningId = c.Int(nullable: false),
                        RoomId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reservations", t => t.ReservationId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId)
                .ForeignKey("dbo.Screening", t => t.ScreeningId, cascadeDelete: true)
                .Index(t => t.ReservationId)
                .Index(t => t.ScreeningId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MoviesGenres",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieId, t.GenreId })
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsersRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UsersRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.MoviesGenres", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.MoviesGenres", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Screening", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.ReserveredSeats", "ScreeningId", "dbo.Screening");
            DropForeignKey("dbo.ReserveredSeats", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.ReserveredSeats", "ReservationId", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "UserId", "dbo.Users");
            DropForeignKey("dbo.Screening", "MovieId", "dbo.Movies");
            DropIndex("dbo.UsersRoles", new[] { "RoleId" });
            DropIndex("dbo.UsersRoles", new[] { "UserId" });
            DropIndex("dbo.MoviesGenres", new[] { "GenreId" });
            DropIndex("dbo.MoviesGenres", new[] { "MovieId" });
            DropIndex("dbo.Reservations", new[] { "UserId" });
            DropIndex("dbo.ReserveredSeats", new[] { "RoomId" });
            DropIndex("dbo.ReserveredSeats", new[] { "ScreeningId" });
            DropIndex("dbo.ReserveredSeats", new[] { "ReservationId" });
            DropIndex("dbo.Screening", new[] { "RoomId" });
            DropIndex("dbo.Screening", new[] { "MovieId" });
            DropTable("dbo.UsersRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.MoviesGenres");
            DropTable("dbo.Users");
            DropTable("dbo.Reservations");
            DropTable("dbo.ReserveredSeats");
            DropTable("dbo.Rooms");
            DropTable("dbo.Screening");
            DropTable("dbo.Movies");
            DropTable("dbo.Genres");
        }
    }
}
