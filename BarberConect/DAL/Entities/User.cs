using System.ComponentModel.DataAnnotations;

namespace BarberConect.DAL.Entities
{
    public class User : AuditBase
    {
        [Display(Name = "Usuario")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string? LastName { get; set; }

        //[Required]
        //public int Role { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo{1} caracter")]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }


        [Required]
        public int Age { get; set; }

        [MaxLength(50)]
        public string? Phone { get; set; }

        [MaxLength(100)]
        public string? Skill { get; set; }

        public int RoleId { get; set; } //FK

        [Display(Name = "Cita")]
        public AppointmentReservation? AppointmentReservations { get; set; }//OBJ 

        [Display(Name = "Id Cita")]
        public Guid? AppointmentReservationId { get; set; } //FK

    }
}
