using Newtonsoft.Json;
using System.Collections.Generic;

namespace CollateralService.ApiClient.Client.Models.Presentation.Responses.Collateral
{
    public partial class Collateral
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Collateral class.
        /// </summary>
        public Collateral()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Collateral class.
        /// </summary>
        public Collateral(
            string id = default(string),
            Type type = default(Type),
            Subtype subtype = default(Subtype),
            string description = default(string),
            string actualDescription = default(string),
            bool? deleted = default(bool?),
            Evaluation evaluation = default(Evaluation),
            System.DateTime? evaluationDate = default(System.DateTime?),
            Status status = default(Status),
            bool? isActive = default(bool?),
            Moratorium moratorium = default(Moratorium),
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
            IList<Evaluation> evaluationHistory = default(IList<Evaluation>),
            SaleType saleType = default(SaleType),
            State state = default(State),
            string registrationClientAddress = default(string),
            MasterSystem masterSystem = default(MasterSystem)
        )
        {
            Id = id;
            Type = type;
            Subtype = subtype;
            Description = description;
            ActualDescription = actualDescription;
            Deleted = deleted;
            Evaluation = evaluation;
            EvaluationDate = evaluationDate;
            Status = status;
            IsActive = isActive;
            Moratorium = moratorium;
            IsVerified = isVerified;
            IsAdditionalProperty = isAdditionalProperty;
            Comment = comment;
            User = user;
            ModifyUser = modifyUser;
            SetamDate = setamDate;
            BiddingDate = biddingDate;
            InventoryDate = inventoryDate;
            SaleDate = saleDate;
            EntryDate = entryDate;
            ModifyDate = modifyDate;
            EvaluationHistory = evaluationHistory;
            SaleType = saleType;
            State = state;
            RegistrationClientAddress = registrationClientAddress;
            MasterSystem = masterSystem;

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
        [JsonProperty(PropertyName = "Type")]
        public Type Type { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Subtype")]
        public Subtype Subtype { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ActualDescription")]
        public string ActualDescription { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Deleted")]
        public bool? Deleted { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Evaluation")]
        public Evaluation Evaluation { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EvaluationDate")]
        public System.DateTime? EvaluationDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Status")]
        public Status Status { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "IsActive")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Moratorium")]
        public Moratorium Moratorium { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "IsVerified")]
        public bool? IsVerified { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "IsAdditionalProperty")]
        public bool? IsAdditionalProperty { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Comment")]
        public string Comment { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "User")]
        public string User { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "SetamDate")]
        public System.DateTime? SetamDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BiddingDate")]
        public System.DateTime? BiddingDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "InventoryDate")]
        public System.DateTime? InventoryDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "SaleDate")]
        public System.DateTime? SaleDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EntryDate")]
        public System.DateTime? EntryDate { get; set; }

        /// <summary>      
        /// </summary>
        [JsonProperty(PropertyName = "ModifyDate")]
        public System.DateTime? ModifyDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EvaluationHistory")]
        public IList<Evaluation> EvaluationHistory { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "SaleType")]
        public SaleType SaleType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "State")]
        public State State { get; set; }

        [JsonProperty(PropertyName = "ModifyUser")]
        public string ModifyUser { get; set; }

        /// <summary>        
        /// </summary>
        [JsonProperty(PropertyName = "RegistrationClientAddress")]
        public string RegistrationClientAddress { get; set; }

        /// <summary>        
        /// </summary>
        [JsonProperty(PropertyName = "MasterSystem")]
        public MasterSystem MasterSystem { get; set; }

    }
}
