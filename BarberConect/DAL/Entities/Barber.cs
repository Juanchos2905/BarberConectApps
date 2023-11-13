using System.ComponentModel.DataAnnotations;

namespace BarberConect.DAL.Entities
{
    public class Barber : User
    {
        [MaxLength(300)]
        [Required]
        public string Habilidades { get; set; }
    }
}
