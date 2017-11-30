using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Configuration
{
    public class CreditAgreementConfiguration : EntityTypeConfiguration<CreditAgreement>
    {
        public CreditAgreementConfiguration()
        {
            ToTable("CREDITAGREEMENTS");

            Property(t => t.Id)
                .HasColumnName("ID");
            Property(t => t.Number)
                .HasMaxLength(2000);
            HasMany(t => t.CollateralAgreements);
            HasMany(t => t.OtherProperty);
        }
    }
}
