using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BusinessLayer.Models.Presentation.Requests.Car
{
    public class Car : Collateral.Collateral
    {
        public BodyType BodyType { get; set; }
        public Brand Brand { get; set; }
        public Model Model { get; set; }
        public string StateNumber { get; set; }
        public string VinCode { get; set; }
        public int? YearIssue { get; set; }
        public Color Color { get; set; }
        public string Engine { get; set; }
        public GearBox GearBox { get; set; }
        public Region Region { get; set; }

        public void DeserializeJson(JToken responseDoc)
        {
            responseDoc.ToObject<Car>();
        }
    }
}