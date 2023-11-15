using BarberConect.DAL.Entities;
using Microsoft.EntityFrameworkCore;
//using System.Diagnostics.Metrics;

namespace BarberConect.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Barber>().HasIndex(b => b.Id).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<AppointmentReservation>().HasIndex("Date", "Time", "AppointmentStatus").IsUnique();

            ///modelBuilder.Entity<Hotel>().HasIndex(h => h.Name).IsUnique();
            ///modelBuilder.Entity<Room>().HasIndex("Number", "HotelId").IsUnique();

        }
        //DBset!
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<AppointmentReservation> AppointmentReservations { get; set; }
    }


    

}
