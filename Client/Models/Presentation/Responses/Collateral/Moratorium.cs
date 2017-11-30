using CollateralService.ApiClient;
using CollateralService.ApiClient.Client;
using Newtonsoft.Json;
using System.Linq;

namespace CollateralService.ApiClient.Client.Models.Presentation.Responses.Collateral
{
    public partial class Moratorium
    {
        /// <summary>
        /// Initializes a new instance of the
        /// BusinessLayerModelsPresentationRequestsCollateralMoratorium class.
        /// </summary>
        public Moratorium()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// BusinessLayerModelsPresentationRequestsCollateralMoratorium class.
        /// </summary>
        public Moratorium(string id = default(string), string name = default(string))
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
