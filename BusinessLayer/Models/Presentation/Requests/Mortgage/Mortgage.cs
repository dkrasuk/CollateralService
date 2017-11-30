using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BusinessLayer.Models.Presentation.Requests.Mortgage
{
    public class Mortgage : Collateral.Collateral
    {
        public Region Region { get; set; }
        public District District { get; set; }
        public Settlement Settlement { get; set; }
        public SettlementType SettlementType { get; set; }
        public string Street { get; set; }
        public StreetType StreetType { get; set; }
        public string House { get; set; }
        public string Apartment { get; set; }
        public int? NumberOfRooms { get; set; }
        public string TotalArea { get; set; }
        public string LandArea { get; set; }
        public Appointment Appointment { get; set; }
        public string Pledgers { get; set; }

        public void DeserializeJson(JToken responseDoc)
        {
            responseDoc.ToObject<Mortgage>();
        }
    }
}
