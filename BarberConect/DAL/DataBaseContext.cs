using Microsoft.EntityFrameworkCore;

namespace BarberConect.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///base.OnModelCreating(modelBuilder);
            ///modelBuilder.Entity<Hotel>().HasIndex(h => h.Name).IsUnique();
            ///modelBuilder.Entity<Room>().HasIndex("Number", "HotelId").IsUnique();
        }*/
    }

    //DBset!
}
