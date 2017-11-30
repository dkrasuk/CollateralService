using System.Data.Entity.ModelConfiguration;
using System.Security.Claims;
using Models.Database;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlfaBank.AlfaCollection.Services.PersonService.DataAccess.Configuration
{
    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            ToTable("PERSONS");

            Property(t => t.Id)
                .HasColumnName("ID");
            Property(t => t.BirthDay).HasColumnName("BIRTHDAY");
            Property(t => t.CategoryId)
                .HasColumnName("CATEGORYID")
                .IsRequired()
                .HasMaxLength(2000);
            Property(t => t.FirstName)
                .HasColumnName("FIRSTNAME")
                .HasMaxLength(2000);
            Property(t => t.GenderId)
                .HasColumnName("GENDERID")
                .IsRequired()
                .HasMaxLength(2000);
            Property(t => t.LastName)
                .HasColumnName("LASTNAME")
                .HasMaxLength(2000);
            Property(t => t.Patronymic)
                .HasColumnName("PATRONYMIC")
                .HasMaxLength(2000);
            Property(t => t.RecordHash)
                .HasColumnName("RECORDHASH")
                .HasMaxLength(2000);
            Property(t => t.TypeId)
                .HasColumnName("TYPEID")
                .IsRequired()
                .HasMaxLength(2000);

            HasKey(t => t.Id);

            //HasRequired(t => t.Category)
            //    .WithMany(p => p.Persons)
            //    .HasForeignKey(k => k.Category);

            //HasRequired(t => t.Type)
            //    .WithMany(p => p.Persons)
            //    .HasForeignKey(k => k.Type);

            //HasRequired(t => t.Gender)
            //    .WithMany(p => p.Persons)
            //    .HasForeignKey(k => k.Gender);

            //HasMany(t => t.Documents)
            //    .WithRequired(p => p.Person)
            //    .HasForeignKey(k => k.Person);

            //HasMany(t => t.MasterLinks)
            //    .WithRequired(p => p.Person)
            //    .HasForeignKey(k => k.InternalId);
        }
    }
}
