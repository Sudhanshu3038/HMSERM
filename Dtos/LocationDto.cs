using System.Text.Json.Serialization;

namespace HMSERM.Dtos
{
    public class LocationDto
    {
        
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
     
        [JsonPropertyName("clinicId")]
        public int? ClinicId { get; set; }
    }
}
