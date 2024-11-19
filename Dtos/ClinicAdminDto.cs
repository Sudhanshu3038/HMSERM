using System.Text.Json.Serialization;

namespace HMSERM.Dtos
{
    public class ClinicAdminDto
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("middleName")]
        public string MiddleName { get; set; }

        [JsonPropertyName("phoneNo")]
        public int PhoneNo { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("dob")]
        public DateOnly DOB { get; set; }


        [JsonPropertyName("clinicId")]
        public int? ClinicId { get; set; }
        [JsonPropertyName("userId")]
        public int? UserId { get; set; }
    }
}
