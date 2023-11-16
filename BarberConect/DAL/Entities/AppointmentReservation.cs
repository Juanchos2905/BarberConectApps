using System.ComponentModel.DataAnnotations;

namespace BarberConect.DAL.Entities
{
    public class AppointmentReservation : AuditBase
    {
        [Display(Name = "FechaCita")]
        [Required]
        public DateTime Date { get; set; } //Date
        [Display(Name = "HoraCita")]
        [Required]
        public string Time { get; set; } //Time
        [Display(Name = "EstadoCita")]
        [Required]
        [MaxLength(20)]
        public string AppointmentStatus { get; set; }// Varchar(20)
        [Display(Name = "TiempoCita")]
        public int? TotalMinutes { get; set; }
        [Display(Name = "TotalPagar")]
        [Required]
        public double TotalRate { get; set; }
        public ICollection<Service>? Services { get; set; }
        public User? User { get; set; }  
    }
}
