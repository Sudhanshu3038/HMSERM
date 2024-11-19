using System.Text.Json.Serialization;

namespace HMSERM.Dtos
{
    public class PatientDto
    {
      
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        [JsonPropertyName("dob")]
        public DateOnly DOB { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        [JsonPropertyName("middleName")]
        public string MiddleName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("clinicId")]
        public int ClinicId { get; set; }
        [JsonPropertyName("userId")]
        public int UserId { get; set; }
        [JsonPropertyName("practitionerId")]
        public int PractitionerId { get; set; }
    }
}
