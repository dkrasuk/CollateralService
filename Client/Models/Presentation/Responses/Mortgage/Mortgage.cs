using Newtonsoft.Json;
using System.Collections.Generic;

namespace CollateralService.ApiClient.Client.Models.Presentation.Responses.Mortgage
{
    public partial class Mortgage : Collateral.Collateral
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Mortgage class.
        /// </summary>
        public Mortgage()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Mortgage class.
        /// </summary>
        public Mortgage(
            Region region = default(Region), 
            District district = default(District), 
            Settlement settlement = default(Settlement),
            SettlementType settlementType = default(SettlementType),
            string street = default(string),
            StreetType streetType = default(StreetType),
            string house = default(string),
            string apartment = default(string),
            int? numberOfRooms = default(int?),
            string totalArea = default(string),
            string landArea = default(string), 
            Appointment appointment = default(Appointment),
            string pledgers = default(string),
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
        :base (
               id, type, subtype,
               description, actualDescription,deleted, evaluation, 
               evaluationDate, status, isActive, moratorium,
               isVerified, isAdditionalProperty, comment,
               user, modifyUser, setamDate, biddingDate, inventoryDate,
               saleDate, entryDate, modifyDate, evaluationHistory, saleType, state, registrationClientAddress
        )
        {
            Region = region;
            District = district;
            Settlement = settlement;
            SettlementType = settlementType;
            Street = street;
            StreetType = streetType;
            House = house;
            Apartment = apartment;
            NumberOfRooms = numberOfRooms;
            TotalArea = totalArea;
            LandArea = landArea;
            Appointment = appointment;
            Pledgers = pledgers;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Region")]
        public Region Region { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "District")]
        public District District { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Settlement")]
        public Settlement Settlement { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "SettlementType")]
        public SettlementType SettlementType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Street")]
        public string Street { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "StreetType")]
        public StreetType StreetType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "House")]
        public string House { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Apartment")]
        public string Apartment { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "NumberOfRooms")]
        public int? NumberOfRooms { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "TotalArea")]
        public string TotalArea { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "LandArea")]
        public string LandArea { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Appointment")]
        public Appointment Appointment { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Pledgers")]
        public string Pledgers { get; set; }
    }
}
