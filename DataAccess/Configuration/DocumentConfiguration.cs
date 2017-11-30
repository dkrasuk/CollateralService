using System.Data.Entity.ModelConfiguration;
using Models.Database;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlfaBank.AlfaCollection.Services.PersonService.DataAccess.Configuration
{
    public class DocumentConfiguration : EntityTypeConfiguration<Document>
    {
        public DocumentConfiguration()
        {
            ToTable("DOCUMENTS");

            Property(t => t.TypeId)
                .HasColumnName("TYPEID")
                .IsRequired()
                .HasMaxLength(2000); 
            Property(t => t.PersonId).HasColumnName("PERSONID").IsRequired();
            Property(t => t.Id)
                .HasColumnName("ID");
            Property(t => t.Number)
                .HasColumnName("NUMBER")
                .HasMaxLength(2000);
            Property(t => t.IssueDate)
                .HasColumnName("ISSUEDATE");
            Property(t => t.Issuer)
                .HasColumnName("ISSUER")
                .HasMaxLength(2000);
            Property(t => t.Series)
                .HasColumnName("SERIES")
                .HasMaxLength(2000);

            HasKey(t => t.Id);


            HasRequired(t => t.Person)
                .WithMany(p => p.Documents)
                .HasForeignKey(k => k.PersonId);

            //HasRequired(t => t.Type)
            //    .WithMany(p => p.Documents)
            //    .HasForeignKey(k => k.Type);
        }
    }
}
