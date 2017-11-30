using Entities.Models;
using Entities.Models.Configuration;
using Repository.Pattern.Ef6;
using Entities.Models;
using System.Configuration;
using System.Data.Entity;

namespace Entities
{
    public class Context : DataContext
    {
        public Context()
            :base("Context")
        {
            
        }

        public DbSet<Collateral> Collateral { get; set; }
        public DbSet<CollateralAgreement> CollateralAgreements { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(ConfigurationManager.AppSettings["DatabaseSchema"]);

            modelBuilder.Configurations.Add(new CollateralConfiguration());
            modelBuilder.Configurations.Add(new CollateralAgreementConfiguration());
            modelBuilder.Configurations.Add(new CreditAgreementConfiguration());
        }

        public System.Data.Entity.DbSet<Entities.Models.CreditAgreement> CreditAgreements { get; set; }
    }
}
