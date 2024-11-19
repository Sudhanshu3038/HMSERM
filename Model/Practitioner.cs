using System.ComponentModel.DataAnnotations;

namespace HMSERM.Model
{
    public class Practitioner: Base
    {
       
        public int PractitionerId { get; set; }
        [Required]
        public string FirstName { get; set; }

        public string? MiddleName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateOnly DOB { get; set; }
        public int? ClinicId { get; set; }
        public int? UserId { get; set; }

        public virtual Clinic? Clinic { get; set; }
        public virtual User? User { get; set; }
    }
}
