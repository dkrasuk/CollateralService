using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models.Presentation.Requests.Mortgage;
using BusinessLayer.Interfaces;
using Microsoft.Practices.ServiceLocation;

namespace BusinessLayer.Models.Dto.Mortgage
{
    public class Mortgage : Collateral.Collateral
    {

        private static IDictionaryService _dictionaryService;

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


        static Mortgage()
        {
            _dictionaryService = ServiceLocator.Current.GetInstance<IDictionaryService>();
        }

        public static implicit operator Mortgage(Entities.Models.Collateral collateral)
        {
            return JsonConvert.DeserializeObject<Mortgage>(collateral.Body);
        }        

        public static implicit operator string(Mortgage collateral)
        {
            return JsonConvert.SerializeObject(collateral);
        }

        public static implicit operator Presentation.Responses.Mortgage.Mortgage(Mortgage collateral)
        {
            var response = Mapper.Map<Presentation.Responses.Mortgage.Mortgage>(collateral);

            return response;
        }

        public static explicit operator Mortgage(Presentation.Requests.Mortgage.Mortgage collateral)
        {
            var dto = Mapper.Map<Mortgage>(collateral);

            RestoreDictionaryProperties(dto, collateral);

            return dto;
        }

        protected static void RestoreDictionaryProperties(Mortgage dto, Models.Presentation.Requests.Mortgage.Mortgage collateral)
        {
            if (collateral.Appointment != null)
            {
                if (collateral.Appointment.Name != null && collateral.Appointment.Id == null)
                    dto.Appointment = _dictionaryService.GetAppointmentByName(collateral.Appointment.Name);

                if (collateral.Appointment.Name == null && collateral.Appointment.Id != null)
                    dto.Appointment = _dictionaryService.GetAppointmentById(collateral.Appointment.Id);
            }

            if (collateral.SettlementType != null)
            {
                if (collateral.SettlementType.Name != null && collateral.SettlementType.Id == null)
                    dto.SettlementType = _dictionaryService.GetSettlementTypeByName(collateral.SettlementType.Name);

                if (collateral.SettlementType.Name == null && collateral.SettlementType.Id != null)
                    dto.SettlementType = _dictionaryService.GetSettlementTypeById(collateral.SettlementType.Id);
            }

            Collateral.Collateral.RestoreDictionaryProperties(dto, collateral);
        }
    }
}
