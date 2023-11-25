using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace BarberConect.DAL.Entities
{
    public class Service : AuditBase
    {
        [Display(Name = "Servicio")]
        [Required]
        [MaxLength(30)]
        public string BarberService { get; set; }//Varchar(30)
        [Display(Name = "Tarifa")]
        [Required]
        public double Rate { get; set; }
        [Display(Name = "TiempoServicio")]
        [Required]
        public int Minutes { get; set; }


        public AppointmentReservation? AppointmentReservation { get; set; }

        [Display(Name = "Appointment id")]
        public Guid? AppointmentReservationId{ get; set; } //FK


    }
}
