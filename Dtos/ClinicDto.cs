using System.Text.Json.Serialization;

namespace HMSERM.Dtos
{
    public class ClinicDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("address")]
        
        public string Address { get; set; }
        
    }
}
