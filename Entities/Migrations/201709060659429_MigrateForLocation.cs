namespace Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateForLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("COLLATERALSERVICE.COLLATERAL", "LOCATION", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("COLLATERALSERVICE.COLLATERAL", "LOCATION");
        }
    }
}
