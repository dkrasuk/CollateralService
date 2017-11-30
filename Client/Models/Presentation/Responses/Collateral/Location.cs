using CollateralService.ApiClient;
using CollateralService.ApiClient.Client;
using Newtonsoft.Json;
using System.Linq;

namespace CollateralService.ApiClient.Client.Models.Presentation.Responses.Collateral
{
    public partial class Location
    {
        public Location()
        {
            CustomInit();
        }

        public Location(string lat = default(string), string lng = default(string), string address = default(string), string type = default(string))
        {
            Lat = lat;
            Lng = lng;
            Address = address;
            Type = type;
            CustomInit();
        }
        partial void CustomInit();

        [JsonProperty(PropertyName = "Lat")]
        public string Lat { get; set; }
        [JsonProperty(PropertyName = "Lng")]
        public string Lng { get; set; }
        [JsonProperty(PropertyName = "Address")]
        public string Address { get; set; }
        [JsonProperty(PropertyName = "Type")]
        public string Type { get; set; }
    }
}
