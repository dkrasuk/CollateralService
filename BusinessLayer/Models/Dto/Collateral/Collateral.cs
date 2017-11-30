using AutoMapper;
using BusinessLayer.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Models.Dto.Collateral
{
    public class Collateral
    {
        private static IDictionaryService _dictionaryService;

        static Collateral()
        {
            _dictionaryService = ServiceLocator.Current.GetInstance<IDictionaryService>();
        }

        public string Id { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public virtual Type Type { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public Subtype Subtype { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Description { get; set; }
        public string ActualDescription { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool Deleted { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Evaluation Evaluation { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public DateTime? EvaluationDate { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public Status Status { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsActive { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public Moratorium Moratorium { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsVerified { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsAdditionalProperty { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Comment { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public DateTime? SetamDate { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public DateTime? BiddingDate { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public DateTime? InventoryDate { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public DateTime? SaleDate { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling .Ignore)]
        public DateTime? EntryDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string ModifyUser { get; set; }
        public IEnumerable<Evaluation> EvaluationHistory { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public SaleType SaleType { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public State State { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string RegistrationClientAddress { get; set; }
        [JsonProperty(NullValueHandling =NullValueHandling.Ignore)]
        public MasterSystem MasterSystem { get; set; }


        public static implicit operator Collateral(Entities.Models.Collateral collateral)
        {
            return JsonConvert.DeserializeObject<Collateral>(collateral.Body);
        }

        public static implicit operator string(Collateral collateral)
        {
            return JsonConvert.SerializeObject(collateral);
        }

        public static implicit operator Presentation.Responses.Collateral.Collateral(Collateral collateral)
        {
            return Mapper.Map<Presentation.Responses.Collateral.Collateral>(collateral);
        }

        public static explicit operator Collateral(Presentation.Requests.Collateral.Collateral collateral)
        {
            var dto = Mapper.Map<Collateral>(collateral);

            RestoreDictionaryProperties(dto, collateral);

            return dto;
        }

        protected static void RestoreDictionaryProperties(Collateral dto, Presentation.Requests.Collateral.Collateral request)
        {
            if (request.Status != null)
            {
                if (request.Status.Name != null && request.Status.Id == null)
                    dto.Status = _dictionaryService.GetStatusByName(request.Status.Name);

                if (request.Status.Name == null && request.Status.Id != null)
                    dto.Status = _dictionaryService.GetStatusById(request.Status.Id);
            }

            if (request.Type != null)
            {
                if (request.Type.Name != null && request.Type.Id == null)
                    dto.Type = _dictionaryService.GetTypeByName(request.Type.Name);

                if (request.Type.Name == null && request.Type.Id != null)
                    dto.Type = _dictionaryService.GetTypeById(request.Type.Id);
            }

            if (request.Subtype != null)
            {
                if (request.Subtype.Name != null && request.Subtype.Id == null)
                    dto.Subtype = _dictionaryService.GetSubTypeByName(request.Subtype.Name);

                if (request.Subtype.Name == null && request.Subtype.Id != null)
                    dto.Subtype = _dictionaryService.GetSubTypeById(request.Subtype.Id);
            }

            if (request.SaleType != null)
            {
                if (request.SaleType.Name != null && request.SaleType.Id == null)
                    dto.SaleType = _dictionaryService.GetSaleTypeByName(request.SaleType.Name);

                if (request.SaleType.Name == null && request.SaleType.Id != null)
                    dto.SaleType = _dictionaryService.GetSaleTypeById(request.SaleType.Id);
            }

            if (request.Moratorium != null)
            {
                if (request.Moratorium.Name != null && request.Moratorium.Id == null)
                    dto.Moratorium = _dictionaryService.GetMoratoriumByName(request.Moratorium.Name);

                if (request.Moratorium.Name == null && request.Moratorium.Id != null)
                    dto.Moratorium = _dictionaryService.GetMoratoriumById(request.Moratorium.Id);
            }

            if (request.State != null)
            {
                if (request.State.Name != null && request.State.Id == null)
                    dto.State = _dictionaryService.GetStateByName(request.State.Name);

                if (request.State.Name == null && request.State.Id != null)
                    dto.State = _dictionaryService.GetStateById(request.State.Id);
            }

            if (request.EvaluationHistory?.ToList().Count() > 0)
            {
                dto.EvaluationHistory = request.EvaluationHistory.Select(x => (Evaluation)x);
            }

            if (request.MasterSystem != null)
            {
                if (request.MasterSystem.Name != null && request.MasterSystem.Id == null)
                    dto.MasterSystem = _dictionaryService.GetMasterSystemByName(request.MasterSystem.Name);

                if (request.MasterSystem.Name == null && request.MasterSystem.Id != null)
                    dto.MasterSystem = _dictionaryService.GetMasterSystemById(request.MasterSystem.Id);
            }

        }
    }
}