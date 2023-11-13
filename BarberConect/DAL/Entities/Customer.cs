using System.ComponentModel.DataAnnotations;

namespace BarberConect.DAL.Entities
{
    public class Customer : User
    {
        [MaxLength(20)]
        public string? Phone { get; set; }
    }
}
