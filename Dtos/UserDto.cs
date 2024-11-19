using HMSERM.Enums;
using System.Text.Json.Serialization;

namespace HMSERM.Dtos
{
    public class UserDto
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("role")]
        public List<RolesEnum> Role { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("clinicId")]
        public int ClinicId { get; set; }
    }
}
