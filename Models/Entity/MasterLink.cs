using AutoMapper;
using Repository.Pattern.Ef6;
using System;


namespace AlfaBank.AlfaCollection.Services.PersonService.Models.Database
{
    public class MasterLink : Entity
    {
        private string id;
        public string Id
        {
            get => id ?? (id = Guid.NewGuid().ToString());
            set => id = value;
        }

        public string MasterId { get; set; }

        public string MasterSystemId { get; set; }

        public string InternalId { get; set; }
        public virtual Person Person { get; set; }
        public DTO.MasterLink ToDtoObject()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Document, DTO.Document>());
            var dto = Mapper.Map<DTO.MasterLink>(this);
            dto.MasterSystem = new DTO.MasterSystem { Id = MasterSystemId };
            return dto;
        }
    }
}