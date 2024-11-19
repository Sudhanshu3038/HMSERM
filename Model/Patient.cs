using System.ComponentModel.DataAnnotations;

namespace HMSERM.Model
{
    public class Patient: Base
    {
        public int PatientId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        [DataType(DataType.Date)]
        public DateOnly DOB { get; set; }
        public int ClinicId { get; set; }

        public virtual Clinic? Clinic { get; set; }

        public int PractitionerId { get; set; }

        public virtual Practitioner? Practitioner { get; set; }



    }
}
