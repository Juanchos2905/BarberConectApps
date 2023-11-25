using System.ComponentModel.DataAnnotations;

namespace BarberConect.DAL.Entities
{
    public class Role
    {
        public  int RoleId { get; set; }

        [Display(Name = "Rol")]
        [Required]
        [MaxLength(30)]
        public string RoleName { get; set; }//Varchar(30)


    }
}
