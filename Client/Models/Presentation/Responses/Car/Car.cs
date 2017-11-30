using Newtonsoft.Json;
using System.Collections.Generic;

namespace CollateralService.ApiClient.Client.Models.Presentation.Responses.Car
{
    public partial class Car : Collateral.Collateral
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Car class.
        /// </summary>
        public Car()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Car class.
        /// </summary>
        public Car(
            BodyType bodyType = default(BodyType),
            Brand brand = default(Brand),
            Model model = default(Model),
            string stateNumber = default(string),
            string vinCode = default(string),
            int? yearIssue = default(int?),
            Color color = default(Color),
            string engine = default(string),
            GearBox gearBox = default(GearBox),
            Region region = default(Region),
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
        ) : base(
            id, type, subtype, description, actualDescription,
            deleted, evaluation, evaluationDate, status, isActive,
            moratorium, isVerified, isAdditionalProperty, comment,
            user, modifyUser, setamDate, biddingDate, inventoryDate, saleDate,
            entryDate, modifyDate, evaluationHistory, saleType, state, registrationClientAddress
        )
        {
            BodyType = bodyType;
            Brand = brand;
            Model = model;
            StateNumber = stateNumber;
            VinCode = vinCode;
            YearIssue = yearIssue;
            Color = color;
            Engine = engine;
            GearBox = gearBox;
            Region = region;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BodyType")]
        public BodyType BodyType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Brand")]
        public Brand Brand { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Model")]
        public Model Model { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "StateNumber")]
        public string StateNumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "VinCode")]
        public string VinCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "YearIssue")]
        public int? YearIssue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Color")]
        public Color Color { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Engine")]
        public string Engine { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "GearBox")]
        public GearBox GearBox { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Region")]
        public Region Region { get; set; }

    }
}
