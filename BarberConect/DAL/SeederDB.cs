using BarberConect.DAL.Entities;

namespace BarberConect.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;

        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }

        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await PopulateRolesAsync();
            await PopulateUsersAsync();
            await PopulateServicesAsync();


            await _context.SaveChangesAsync();
        }

        #region Private Methods
        private async Task PopulateRolesAsync()
        {
            if (!_context.Roles.Any())
            {
                _context.Roles.Add(new Role
                {
                    RoleName = "Barber"
                });

                _context.Roles.Add(new Role
                {
                    RoleName = "Customer"
                });
            }
        }

        private async Task PopulateUsersAsync()
        {
            if (!_context.Users.Any())
            {
                _context.Users.Add(new User
                {
                    Name = "Andres",
                    LastName = "Velez",
                    Email = "AV@gmail.com",
                    Password = "1234",
                    Age = 35,
                    Phone = "3216549874",
                    Skill = "Especializado en cortes de pelo corto.",
                    AppointmentReservationId = null,
                    RoleId = 1,
                    ModifiedDate = null,
                    CreateDate = DateTime.Now
                });
                
                _context.Users.Add(new User
                {
                    Name = "Eurelio",
                    LastName = "Rodriguez",
                    Email = "Eu@gmail.com",
                    Password = "1234",
                    Age = 20,
                    Phone = "3216549874",
                    Skill = "Especializado en cortes de pelo largo y definición de barba.",
                    AppointmentReservationId = null,
                    RoleId = 1,
                    ModifiedDate = null,
                    CreateDate = DateTime.Now
                });

                _context.Users.Add(new User
                {
                    Name = "Juan",
                    LastName = "Valencia",
                    Email = "JValencia@gmail.com",
                    Password = "2222",
                    Age = 20,
                    Phone = "3002036809",
                    Skill = null,
                    RoleId = 2,
                    AppointmentReservationId = null,
                    ModifiedDate = null,
                    CreateDate = DateTime.Now
                });

                _context.Users.Add(new User
                {
                    Name = "Alex",
                    LastName = "Soto",
                    Email = "ALSoto@gmail.com",
                    Password = "1111",
                    Age = 19,
                    Phone = "3135456320",
                    Skill = null,
                    RoleId = 2,
                    AppointmentReservationId = null,
                    ModifiedDate = null,
                    CreateDate = DateTime.Now
                });
            }
        }
        private async Task PopulateServicesAsync()
        {
            if (!_context.Services.Any())
            {
                _context.Services.Add(new Service
                {
                    BarberService = "Corte militar",
                    Rate = 12000,
                    Minutes = 10,
                    AppointmentReservationId = null,
                    CreateDate = DateTime.Now

                });
                _context.Services.Add(new Service
                {
                    BarberService = "Pigmentación de barba",
                    Rate = 8000,
                    Minutes = 45,
                    AppointmentReservationId = null,
                    CreateDate = DateTime.Now

                });
                _context.Services.Add(new Service
                {
                    BarberService = "La 0",
                    Rate = 10000,
                    Minutes = 8,
                    AppointmentReservationId = null,
                    CreateDate = DateTime.Now

                });
            }
        }
        #endregion

    }
}