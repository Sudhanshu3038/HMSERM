using System.ComponentModel.DataAnnotations;

namespace HMSERM.Model
{
    public class Clinic: Base
    {

        public int ClinicId { get; set; }
        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
    }
}
