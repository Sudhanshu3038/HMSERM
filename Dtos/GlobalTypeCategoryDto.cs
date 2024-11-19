using System.Text.Json.Serialization;

namespace HMSERM.Dtos
{
    public class GlobalTypeCategoryDto
    {
       
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;


        [JsonPropertyName("clinicId")]
        public int? ClinicId { get; set; }
    }
}
