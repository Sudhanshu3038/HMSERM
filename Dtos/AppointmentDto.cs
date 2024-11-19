using System.Text.Json.Serialization;

namespace HMSERM.Dtos
{
    public class AppointmentDto
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }


        [JsonPropertyName("clinicId")]
        public int? ClinicId { get; set; }

        [JsonPropertyName("practitionerId")]
        public int? PractitionerId { get; set; }

        [JsonPropertyName("patientId")]
        public int? PatientId { get; set; }

        [JsonPropertyName("locationId")]
        public int? LocationId { get; set; }
    }
}
