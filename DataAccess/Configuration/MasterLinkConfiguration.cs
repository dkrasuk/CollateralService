using System.Data.Entity.ModelConfiguration;
using Models.Database;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlfaBank.AlfaCollection.Services.PersonService.DataAccess.Configuration
{
    public class MasterLinkConfiguration : EntityTypeConfiguration<MasterLink>
    {
        public MasterLinkConfiguration()
        {
            ToTable("MASTERLINKS");

            Property(t => t.MasterSystemId)
                .HasColumnName("MASTERSYSTENID")
                .IsRequired()
                .HasMaxLength(2000);
            Property(t => t.InternalId).HasColumnName("INTERNALID").IsRequired();
            Property(t => t.Id)
                .HasColumnName("ID");
            Property(t => t.MasterId)
                .HasColumnName("MASTERID")
                .HasMaxLength(2000);

            //HasRequired(t => t.MasterSystem)
            //    .WithMany(p => p.MasterLinks)
            //    .HasForeignKey(k => k.MasterSystem);

            HasRequired(t => t.Person)
                .WithMany(p => p.MasterLinks)
                .HasForeignKey(k => k.InternalId);
        }
    }
}
