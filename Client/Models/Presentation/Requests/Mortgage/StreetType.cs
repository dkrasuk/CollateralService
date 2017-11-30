// Code generated by Microsoft (R) AutoRest Code Generator 1.0.1.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace CollateralService.ApiClient.Client.Models.Presentation.Requests.Mortgage
{
    using CollateralService.ApiClient;
    using CollateralService.ApiClient.Client;
    using Newtonsoft.Json;
    using System.Linq;

    public partial class StreetType
    {
        /// <summary>
        /// Initializes a new instance of the
        /// StreetType class.
        /// </summary>
        public StreetType()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// StreetType class.
        /// </summary>
        public StreetType(string id = default(string), string name = default(string))
        {
            Id = id;
            Name = name;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

    }
}
