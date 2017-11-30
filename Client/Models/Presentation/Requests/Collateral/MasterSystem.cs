using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollateralService.ApiClient.Client.Models.Presentation.Requests.Collateral
{
    public partial class MasterSystem
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Status class.
        /// </summary>
        public MasterSystem()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Status class.
        /// </summary>
        public MasterSystem(string id = default(string), string name = default(string))
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
