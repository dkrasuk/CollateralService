using System;
using Repository.Pattern.Ef6;
using AutoMapper;

namespace AlfaBank.AlfaCollection.Services.PersonService.Models.Database
{
    public class Document : Entity
    {
        private string id;
        public string Id
        {
            get => id ?? (id = Guid.NewGuid().ToString());
            set => id = value;
        }

        public string Series { get; set; }

        public string Number { get; set; }

        public DateTime? IssueDate { get; set; }

        public string Issuer { get; set; }

        public string TypeId { get; set; }

        public string PersonId { get; set; }

        public virtual Person Person { get; set; }
        public DTO.Document ToDtoObject()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Document, DTO.Document>());
            var dto = Mapper.Map<DTO.Document>(this);
            dto.Type = new DTO.DocumentType { Id = TypeId };
            return dto;
        }
    }
}
