using Newtonsoft.Json;
using System.Collections.Generic;

namespace CollateralService.ApiClient.Client.Models.Presentation.Requests.OtherCollateral
{
    public partial class OtherCollateral : Collateral.Collateral
    {
        /// <summary>
        /// Initializes a new instance of the
        /// OtherCollateral
        /// class.
        /// </summary>
        public OtherCollateral()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// OtherCollateral
        /// class.
        /// </summary>
        public OtherCollateral(
            string specification = default(string),
            string id = default(string),
            Collateral.Type type = default(Collateral.Type),
            Collateral.Subtype subtype = default(Collateral.Subtype),
            string description = default(string),
            string actualDescription = default(string),
            bool? deleted = default(bool?),
            Collateral.Evaluation evaluation = default(Collateral.Evaluation),
            System.DateTime? evaluationDate = default(System.DateTime?),
            Collateral.Status status = default(Collateral.Status),
            bool? isActive = default(bool?),
            Collateral.Moratorium moratorium = default(Collateral.Moratorium),
            bool? isVerified = default(bool?),
            bool? isAdditionalProperty = default(bool?),
            string comment = default(string),
            string user = default(string),
            string modifyUser = default(string),
            System.DateTime? setamDate = default(System.DateTime?),
            System.DateTime? biddingDate = default(System.DateTime?),
            System.DateTime? inventoryDate = default(System.DateTime?),
            System.DateTime? saleDate = default(System.DateTime?),
            System.DateTime? entryDate = default(System.DateTime?),
            System.DateTime? modifyDate = default(System.DateTime?),
            IList<Collateral.Evaluation> evaluationHistory = default(IList<Collateral.Evaluation>),
            Collateral.SaleType saleType = default(Collateral.SaleType),
            Collateral.State state = default(Collateral.State),
            string registrationClientAddress = default(string)
        )
        : base(
            id, type, subtype, description, actualDescription,
            deleted, evaluation, evaluationDate, status, isActive,
            moratorium, isVerified, isAdditionalProperty, comment,
            user, modifyUser, setamDate, biddingDate, inventoryDate, saleDate,
            entryDate, modifyDate, evaluationHistory, saleType, state, registrationClientAddress
        )
        {
            Specification = specification;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Specification")]
        public string Specification { get; set; }
    }
}
