using HMSERM.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HMSERM.Model
{
    public class User:Base
    {
        public int UserId { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public List<RolesEnum> Role { get; set; } = new List<RolesEnum>();

        public int? ClinicId { get; set; }   

        public virtual Clinic? Clinic { get; set; }

        [JsonIgnore]
        public string? PasswordHash { get; set; }
        [JsonIgnore]
        public byte[]? PasswordSalt { get; set; }
    }
}
