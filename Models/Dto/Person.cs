using System;
using System.Collections.Generic;

namespace AlfaBank.AlfaCollection.Services.PersonService.Models.Dto
{
    public class Person
    {
        public string Id { get; set; }

        public string RecordHash { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public DateTime? BirthDay { get; set; }

        public virtual PersonCategory Category { get; set; }

        public virtual PersonType Type { get; set; }
        public virtual Gender Gender { get; set; }

        public IEnumerable<MasterLink> MasterLinks { get; set; }

        public IEnumerable<Document> Documents { get; set; }
    }
}
