using AutoMapper;
using BusinessLayer.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Models.Dto.Car
{
    public class Car : Collateral.Collateral
    {
        private static IDictionaryService _dictionaryService;

        static Car()
        {
            _dictionaryService = ServiceLocator.Current.GetInstance<IDictionaryService>();
        }
 

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



        public static implicit operator Car(Entities.Models.Collateral collateral)
        {
            return JsonConvert.DeserializeObject<Car>(collateral.Body);
        }

        public static implicit operator string(Car collateral)
        {
            return JsonConvert.SerializeObject(collateral);
        }

        public static explicit operator Car(Presentation.Requests.Car.Car collateral)
        {

            var dto = Mapper.Map<Car>(collateral);

            RestoreDictionaryProperties(dto, collateral);            

            return dto;
        }

        public static implicit operator Presentation.Responses.Car.Car(Car collateral)
        {
            var response = Mapper.Map<Presentation.Responses.Car.Car>(collateral);

            return response;
        }

        protected static void RestoreDictionaryProperties(Car dto, Presentation.Requests.Car.Car collateral)
        {
            Collateral.Collateral.RestoreDictionaryProperties(dto, collateral);

            if (collateral.BodyType != null)
            {
                if (collateral.BodyType.Name != null && collateral.BodyType.Id == null)
                    dto.BodyType = _dictionaryService.GetBodyTypeByName(collateral.BodyType.Name);

                if (collateral.BodyType.Name == null && collateral.BodyType.Id != null)
                    dto.BodyType = _dictionaryService.GetBodyTypeById(collateral.BodyType.Id);
            }

            if (collateral.Brand != null)
            {
                if (collateral.Brand.Name != null && collateral.Brand.Id == null)
                    dto.Brand = _dictionaryService.GetBrandByName(collateral.Brand.Name);

                if (collateral.Brand.Name == null && collateral.Brand.Id != null)
                    dto.Brand = _dictionaryService.GetBrandById(collateral.Brand.Id);
            }

            if (collateral.Color != null)
            {
                if (collateral.Color.Name != null && collateral.Color.Id == null)
                    dto.Color = _dictionaryService.GetColorByName(collateral.Color.Name);

                if (collateral.Color.Name == null && collateral.Color.Id != null)
                    dto.Color = _dictionaryService.GetColorById(collateral.Color.Id);
            }

            if (collateral.GearBox != null)
            {
                if (collateral.GearBox.Name != null && collateral.GearBox.Id == null)
                    dto.GearBox = _dictionaryService.GetGearBoxByName(collateral.GearBox.Name);

                if (collateral.GearBox.Name == null && collateral.GearBox.Id != null)
                    dto.GearBox = _dictionaryService.GetGearBoxById(collateral.GearBox.Id);
            }

            if (collateral.Model != null && (collateral.Model.Name == null || collateral.Model.Id == null))
            {
                IEnumerable<Model> models = null;
                if (collateral.Model.Name != null && collateral.Model.Id == null)
                    models = _dictionaryService.GetModelByName(collateral.Model.Name, dto.Brand?.Name);
                
                if (collateral.Model.Name == null && collateral.Model.Id != null)
                    models = _dictionaryService.GetModelById(collateral.Model.Id, dto.Brand?.Name);

                if (models?.ToList().Count() >= 1 && dto.Brand?.Id != null)
                    dto.Model = models.ToList().FirstOrDefault();

                if (models?.ToList().Count() == 1 && dto.Brand?.Id == null)
                {
                    var model = models.ToList().FirstOrDefault();
                    dto.Model = model;
                    dto.Brand = _dictionaryService.GetBrandByName(model.Brand);
                }
            }
        }
    }
}