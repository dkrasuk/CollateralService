using System.Data.Entity;
using DataAcces.Configuration;
using Models.Database;

namespace AlfaBank.AlfaCollection.Services.PersonService.DataAccess
{
    public class PersonContext : DbContext
    {
        public PersonContext()
            :base("PersonContext")
        {
            
        }
        public DbSet<Person> Persons { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DbSet<MasterLink> MasterLinks { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("PERSONSERVICE");

            modelBuilder.Configurations.Add(new PersonConfiguration());
            modelBuilder.Configurations.Add(new DocumentConfiguration());
            modelBuilder.Configurations.Add(new MasterLinkConfiguration());
        }
    }
}
