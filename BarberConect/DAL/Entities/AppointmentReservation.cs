using System.ComponentModel.DataAnnotations;

namespace BarberConect.DAL.Entities
{
    public class AppointmentReservation : AuditBase
    {
        [Display(Name = "FechaCita")]
        [Required]
        public string Date { get; set; } //Date
        [Display(Name = "HoraCita")]
        [MaxLength(2, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required]
        public string Time { get; set; } //Time
        [Display(Name = "EstadoCita")]
        [MaxLength(20)]
        public string AppointmentStatus { get; set; }// Varchar(20)
        /*[Display(Name = "TiempoCita")]
        public int? TotalMinutes { get; set; }
        [Display(Name = "TotalPagar")]
        [Required]
        public double TotalRate { get; set; }*/

        [Display(Name = "Usuario")]
        public User? User { get; set; }

        [Display(Name = "Id Usuario")]
        public Guid UserId { get; set; }  //FK

        [Display(Name = "Servicios")]
        public ICollection<Service>? Services { get; set; } //RC

    }
}
