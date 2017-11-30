using Newtonsoft.Json;

namespace AlfaBank.AlfaCollection.Services.PersonService.Models.DTO
{
    public class PersonCategory
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
