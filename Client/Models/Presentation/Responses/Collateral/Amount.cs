// Code generated by Microsoft (R) AutoRest Code Generator 1.0.1.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace CollateralService.ApiClient.Client.Models.Presentation.Responses.Collateral
{
    using CollateralService.ApiClient;
    using CollateralService.ApiClient.Client;
    using Newtonsoft.Json;
    using System.Linq;

    public partial class Amount
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Amount class.
        /// </summary>
        public Amount()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Amount class.
        /// </summary>
        public Amount(Currency currency = default(Currency), double? value = default(double?))
        {
            Currency = currency;
            Value = value;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Currency")]
        public Currency Currency { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Value")]
        public double? Value { get; set; }

    }
}
