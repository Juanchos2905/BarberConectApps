using System.ComponentModel.DataAnnotations;

namespace BarberConect.DAL.Entities
{
    public class User : AuditBase
    {
        [Display(Name = "Usuario")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo{1} caracter")]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        [MaxLength(50)]
        public string? LastName { get; set; }

        [Required]
        public int Age { get; set; }
        public ICollection<AppointmentReservation>? appointmentReservations { get; set; }
    }
}
