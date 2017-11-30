using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Configuration
{
    class CollateralAgreementConfiguration : EntityTypeConfiguration<CollateralAgreement>
    {
        public CollateralAgreementConfiguration()
        {
            ToTable("COLLATERALAGREEMENTS");

            Property(t => t.Id)
                .HasColumnName("ID");
            Property(t => t.Number)
                .HasMaxLength(2000);
            Property(t => t.OpenDate)
                .HasColumnName("OPENDATE")
                .HasColumnType("DATE");
            Property(t => t.CloseDate)
                .HasColumnName("CLOSEDATE")
                .HasColumnType("DATE");
            Property(t => t.PersonId)
                .HasColumnName("PERSONID")
                .HasMaxLength(40);

            HasMany(t => t.Collateral);

            HasMany(t => t.CreditAgreements)
                .WithMany(tt => tt.CollateralAgreements)
                .Map(x =>
                {
                    x.MapLeftKey("COLLATERALAGREEMENTID");
                    x.MapRightKey("CREDITAGREEMENTID");
                    x.ToTable("COLLAGREEMENTS_CREDAGREEMENTS");
                });
        }
    }
}
