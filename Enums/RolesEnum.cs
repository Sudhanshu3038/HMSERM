
using System.ComponentModel.DataAnnotations;

namespace HMSERM.Enums
{
    public enum RolesEnum
    {
        [Display(Name = "Patient")]
        Patient = 1 ,
        [Display(Name = "Practitioner")]
        Practitioner = 2,
        [Display(Name ="ClinicAdmin")]
        ClinicAdmin = 3

    }
}
