using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using AlfaCollection.Utility.Common;
using System;
using AlfaBank.AlfaCollection.Services.PersonService.DataAccess.Interface;

namespace AlfaBank.AlfaCollection.Services.PersonService.DataAccess
{
    public class PersonData : IPersonData
    {
        public bool IsPersonExist(string masterLink, string masterSystemId)
        {
            using (var context = new PersonContext())
            {
                return context.MasterLinks.Any(t =>
                    t.MasterId == masterLink &&
                    t.MasterSystemId == masterSystemId &&
                    t.Person != null);
            }
        }

        public void UpdatePerson(Models.DTO.Person person)
        {
            using (var context = new PersonContext())
            {
                var personToUpdate =
                    context.MasterLinks.FirstOrDefault(
                        t =>
                            t.MasterId == person.MasterLink.MasterId &&
                            t.MasterSystemId == person.MasterLink.MasterSystem.Id)?.Person;

                var recordHash = GetRecordHash(person);

                if (recordHash == personToUpdate.RecordHash)
                {
                    return;
                }

                personToUpdate.BirthDay = person.BirthDay;
                personToUpdate.CategoryId = person.Category.Id;
                personToUpdate.FirstName = person.FirstName;
                personToUpdate.LastName = person.LastName;
                personToUpdate.Patronymic = person.Patronymic;
                personToUpdate.GenderId = person.Gender.Id;
                personToUpdate.TypeId = person.Type.Id;
                personToUpdate.RecordHash = recordHash;

                foreach (var document in person.Documents)
                {
                    var documentToUpdate =
                        context.Documents.FirstOrDefault(
                            t => t.Person.Id == personToUpdate.Id && t.TypeId == document.Type.Id);

                    if (documentToUpdate != null)
                    {
                        UpdateDocument(documentToUpdate, document);
                    }
                    else
                    {
                        AddDocument(context, personToUpdate, document);
                    }
                }

                context.SaveChanges();

            }
        }

        /// <summary>
        /// Updates the document.
        /// </summary>
        /// <param name = "documentToUpdate" > The document to update.</param>
        /// <param name = "document" > The document.</param>
        private void UpdateDocument(Models.Database.Document documentToUpdate, Models.DTO.Document document)
        {
            documentToUpdate.Number = document.Number;
            documentToUpdate.Series = document.Series;
            documentToUpdate.IssueDate = document.IssueDate;
            documentToUpdate.Issuer = document.Issuer;
        }

        /// <summary>
        /// Adds the document.
        /// </summary>
        /// <param name = "context" > The context.</param>
        /// <param name = "person" > The person.</param>
        /// <param name = "document" > The document.</param>
        private static void AddDocument(PersonContext context, Models.Database.Person person, Models.DTO.Document document)
        {
            var newDocument = new Models.Database.Document
            {
                Person = person,
                Number = document.Number,
                TypeId = document.Type.Id,
                IssueDate = document.IssueDate,
                Issuer = document.Issuer,
                Series = document.Series
            };

            context.Documents.Add(newDocument);
        }

        /// <summary>
        /// Gets the record hash.
        /// </summary>
        /// <param name = "person" > The person.</param>
        /// <returns>System.String.</returns>
        private static string GetRecordHash(Models.DTO.Person person)
        {
            var inputDataToHash = $"{person.FirstName}{person.LastName}{person.BirthDay.GetValueOrDefault()}";

            foreach (var document in person.Documents.OrderByDescending(t => t.Number))
            {
                inputDataToHash += $"{document.Series}{document.Number}";
            }

            return inputDataToHash.EncryptWithSHA1();
        }

        /// <summary>
        /// Creates the person.
        /// </summary>
        /// <param name = "person" > The person.</param>
        public void CreatePerson(Models.DTO.Person person)
        {
            using (var context = new PersonContext())
            {
                var newPerson = new Models.Database.Person
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Patronymic = person.Patronymic,
                    BirthDay = person.BirthDay,
                    GenderId = person.Gender.Id,
                    CategoryId = person.Category.Id,
                    TypeId = person.Type.Id,
                    RecordHash = GetRecordHash(person),
                    MasterLinks = new List<Models.Database.MasterLink>(),
                    Documents = new List<Models.Database.Document>()
                };

                newPerson.MasterLinks.Add(new Models.Database.MasterLink { MasterId = person.MasterLink.MasterId, MasterSystemId = person.MasterLink.MasterSystem.Id });

                foreach (var document in person.Documents)
                {
                    var newDocument = new Models.Database.Document
                    {
                        Number = document.Number,
                        TypeId = document.Type.Id,
                        IssueDate = document.IssueDate,
                        Issuer = document.Issuer,
                        Series = document.Series
                    };
                    newPerson.Documents.Add(newDocument);
                }


                context.Persons.Add(newPerson);
                context.SaveChanges();
            }
        }
    }
}
