using System.ComponentModel.DataAnnotations;

namespace BarberConect.DAL.Entities
{
    public class AuditBase
    {
        [Key] //DataAnnotation
        [Required] //doesn't allow null fields
        public virtual Guid Id { get; set; }
        public virtual DateTime? CreateDate { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }

    }
}
