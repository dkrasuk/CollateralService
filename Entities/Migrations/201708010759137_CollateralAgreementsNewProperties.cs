namespace Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollateralAgreementsNewProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("COLLATERALSERVICE.COLLATERALAGREEMENTS", "OPENDATE", c => c.DateTime());
            AddColumn("COLLATERALSERVICE.COLLATERALAGREEMENTS", "CLOSEDATE", c => c.DateTime());
            AddColumn("COLLATERALSERVICE.COLLATERALAGREEMENTS", "PERSONID", c => c.String(maxLength: 40));
        }
        
        public override void Down()
        {
            DropColumn("COLLATERALSERVICE.COLLATERALAGREEMENTS", "PERSONID");
            DropColumn("COLLATERALSERVICE.COLLATERALAGREEMENTS", "CLOSEDATE");
            DropColumn("COLLATERALSERVICE.COLLATERALAGREEMENTS", "OPENDATE");
        }
    }
}
