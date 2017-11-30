using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AutoMapper;

namespace BusinessLayer.Models.Presentation.Responses.Collateral
{
    public class Collateral
    {
        public string Id { get; set; }
        public virtual Type Type { get; set; }
        public Subtype Subtype { get; set; }
        public string Description { get; set; }
        public string ActualDescription { get; set; }
        public bool Deleted { get; set; }
        public Evaluation Evaluation { get; set; }
        public DateTime? EvaluationDate { get; set; }
        public Status Status { get; set; }
        public bool IsActive { get; set; }
        public Moratorium Moratorium { get; set; }
        public bool IsVerified { get; set; }
        public bool IsAdditionalProperty { get; set; }
        public string Comment { get; set; }
        public string User { get; set; }
        public DateTime? SetamDate { get; set; }
        public DateTime? BiddingDate { get; set; }
        public DateTime? InventoryDate { get; set; }
        public DateTime? SaleDate { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyUser { get; set; }
        public IEnumerable<Evaluation> EvaluationHistory { get; set; }
        public SaleType SaleType { get; set; }
        public State State { get; set; }        
        public string RegistrationClientAddress { get; set; }
        public MasterSystem MasterSystem { get; set; }

        public void DeserializeJson(JToken iListValue)
        {
            iListValue.ToObject<Collateral>();
        }
    }
}
