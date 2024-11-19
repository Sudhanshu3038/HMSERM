using System.Text.Json.Serialization;

namespace HMSERM.Dtos
{
    public class GlobalTypeDto
    {
        
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }


        [JsonPropertyName("categoryId")]
        public int? CategoryId { get; set; }

        [JsonPropertyName("clinicId")]
        public int? ClinicId { get; set; }
    }
}
