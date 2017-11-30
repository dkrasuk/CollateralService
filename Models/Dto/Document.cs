using System;

namespace AlfaBank.AlfaCollection.Services.PersonService.Models.DTO
{
    public class Document
    {
        public string Id { get; set; }

        public string Series { get; set; }

        public string Number { get; set; }

        public DateTime? IssueDate { get; set; }

        public string Issuer { get; set; }

        public DocumentType Type{ get; set; }
    }
}
