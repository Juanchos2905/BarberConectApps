namespace BarberConect.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;

        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }
/*
        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await PopulateAppointmentReservationsAsync();

            await _context.SaveChangesAsync();
        }

        #region Private Methods
        private async Task PopulateAppointmentReservationsAsync()
        {
            if (!_context.AppointmentRservation.Any())
            {
                _context.AppointmentRservations.Add(new AppointmentRservation
                {

                }
            }
        }
            #endregion
*/
    }
}
