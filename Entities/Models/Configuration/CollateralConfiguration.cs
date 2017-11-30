using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Configuration
{
    class CollateralConfiguration : EntityTypeConfiguration<Collateral>
    {
        public CollateralConfiguration()
        {
            ToTable("COLLATERAL");
            Property(t => t.Id)
                .HasColumnName("ID");
            Property(t => t.Body)
                .HasColumnName("BODY");
            Property(t => t.History)
                .HasColumnName("HISTORY");
            Property(t => t.Location)
                .HasColumnName("LOCATION");
            //Property(t => t.EvaluationHistory)
            //    .HasColumnName("EVALUATIONHISTORY");
            HasMany(t => t.CollateralAgreements)
                .WithMany(tt => tt.Collateral)
                .Map(x =>
                {
                    x.MapLeftKey("COLLATERALID");
                    x.MapRightKey("COLLATERALAGREEMENTID");
                    x.ToTable("COLLATERAL_COLLGREEMENTS");
                });
            HasMany(t => t.CreditAgreements)
                .WithMany(tt => tt.OtherProperty)
                .Map(x =>
                {
                    x.MapLeftKey("COLLATERALID");
                    x.MapRightKey("CREDITAGREEMENTID");
                    x.ToTable("COLLATERAL_CREDITAGREEMENTS");
                });
                
        }
    }
}
