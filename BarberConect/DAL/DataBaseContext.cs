using BarberConect.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

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
            modelBuilder.Entity<User>().HasIndex(u => u.Id).IsUnique();
            modelBuilder.Entity<Role>().HasIndex(r => r.RoleId).IsUnique();
            modelBuilder.Entity<Service>().HasIndex(s => s.Id).IsUnique();


            modelBuilder.Entity<AppointmentReservation>().HasIndex("Date", "Time", "AppointmentStatus").IsUnique();
            modelBuilder.Entity<AppointmentReservation>()
                .HasOne(ar => ar.User)
                .WithOne(u => u.AppointmentReservations)
                .HasForeignKey<AppointmentReservation>(ar => ar.UserId);


        }
        //DBset!
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<AppointmentReservation> AppointmentReservations { get; set; }
    }


    

}
