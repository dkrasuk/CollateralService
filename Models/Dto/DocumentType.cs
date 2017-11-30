using Newtonsoft.Json;

namespace AlfaBank.AlfaCollection.Services.PersonService.Models.DTO
{
    public class DocumentType
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
