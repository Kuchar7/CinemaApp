namespace DAL
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DatabaseContext : DbContext
    {
 
        public DatabaseContext()
            : base("CinemaDb")
        {
            var ensureDLLIsCopied =
               System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UsersRoles { get; set; }
        public virtual DbSet<MovieGenre> MoviesGenres { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<ReservedSeat> ReservedSeats { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Screening> Screenings { get; set; }
    }


}