using CollateralService.ApiClient;
using CollateralService.ApiClient.Client;
using Newtonsoft.Json;
using System.Linq;

namespace CollateralService.ApiClient.Client.Models.Presentation.Responses.Collateral
{  
    public partial class State
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Status class.
        /// </summary>
        public State()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Status class.
        /// </summary>
        public State(string id = default(string), string name = default(string))
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
