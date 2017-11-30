using AutoMapper;
using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AlfaBank.AlfaCollection.Services.PersonService.Models.Database
{
    public class Person : Entity
    {
        private string id;
        public Person()
        {
            Documents = new HashSet<Document>();
            MasterLinks = new HashSet<MasterLink>();
        }

        public string Id
        {
            get => id ?? (id = Guid.NewGuid().ToString());
            set => id = value;
        }

        public string RecordHash { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public DateTime? BirthDay { get; set; }

        public string CategoryId { get; set; }

        public string TypeId { get; set; }

        public string GenderId { get; set; }

        public ICollection<MasterLink> MasterLinks { get; set; }

        public ICollection<Document> Documents { get; set; }
        public DTO.Person ToDtoObject()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Person, DTO.Person>());
            var dto = Mapper.Map<DTO.Person>(this);
            dto.Category = new DTO.PersonCategory { Id = CategoryId };
            dto.Gender = new DTO.Gender { Id = GenderId };
            dto.MasterLinks = MasterLinks.Select(s => s.ToDtoObject());
            dto.Type = new DTO.PersonType { Id = TypeId };
            dto.Documents = Documents.Select(s => s.ToDtoObject());
            return dto;
        }
    }
}
