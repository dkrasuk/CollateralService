namespace Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "COLLATERALSERVICE.COLLATERAL",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        BODY = c.String(),
                        HISTORY = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "COLLATERALSERVICE.COLLATERALAGREEMENTS",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Number = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "COLLATERALSERVICE.CREDITAGREEMENTS",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Number = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "COLLATERALSERVICE.COLLAGREEMENTS_CREDAGREEMENTS",
                c => new
                    {
                        COLLATERALAGREEMENTID = c.String(nullable: false, maxLength: 128),
                        CREDITAGREEMENTID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.COLLATERALAGREEMENTID, t.CREDITAGREEMENTID })
                .ForeignKey("COLLATERALSERVICE.COLLATERALAGREEMENTS", t => t.COLLATERALAGREEMENTID, cascadeDelete: true)
                .ForeignKey("COLLATERALSERVICE.CREDITAGREEMENTS", t => t.CREDITAGREEMENTID, cascadeDelete: true)
                .Index(t => t.COLLATERALAGREEMENTID)
                .Index(t => t.CREDITAGREEMENTID);
            
            CreateTable(
                "COLLATERALSERVICE.COLLATERAL_COLLGREEMENTS",
                c => new
                    {
                        COLLATERALID = c.String(nullable: false, maxLength: 128),
                        COLLATERALAGREEMENTID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.COLLATERALID, t.COLLATERALAGREEMENTID })
                .ForeignKey("COLLATERALSERVICE.COLLATERAL", t => t.COLLATERALID, cascadeDelete: true)
                .ForeignKey("COLLATERALSERVICE.COLLATERALAGREEMENTS", t => t.COLLATERALAGREEMENTID, cascadeDelete: true)
                .Index(t => t.COLLATERALID)
                .Index(t => t.COLLATERALAGREEMENTID);
            
            CreateTable(
                "COLLATERALSERVICE.COLLATERAL_CREDITAGREEMENTS",
                c => new
                    {
                        COLLATERALID = c.String(nullable: false, maxLength: 128),
                        CREDITAGREEMENTID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.COLLATERALID, t.CREDITAGREEMENTID })
                .ForeignKey("COLLATERALSERVICE.COLLATERAL", t => t.COLLATERALID, cascadeDelete: true)
                .ForeignKey("COLLATERALSERVICE.CREDITAGREEMENTS", t => t.CREDITAGREEMENTID, cascadeDelete: true)
                .Index(t => t.COLLATERALID)
                .Index(t => t.CREDITAGREEMENTID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("COLLATERALSERVICE.COLLATERAL_CREDITAGREEMENTS", "CREDITAGREEMENTID", "COLLATERALSERVICE.CREDITAGREEMENTS");
            DropForeignKey("COLLATERALSERVICE.COLLATERAL_CREDITAGREEMENTS", "COLLATERALID", "COLLATERALSERVICE.COLLATERAL");
            DropForeignKey("COLLATERALSERVICE.COLLATERAL_COLLGREEMENTS", "COLLATERALAGREEMENTID", "COLLATERALSERVICE.COLLATERALAGREEMENTS");
            DropForeignKey("COLLATERALSERVICE.COLLATERAL_COLLGREEMENTS", "COLLATERALID", "COLLATERALSERVICE.COLLATERAL");
            DropForeignKey("COLLATERALSERVICE.COLLAGREEMENTS_CREDAGREEMENTS", "CREDITAGREEMENTID", "COLLATERALSERVICE.CREDITAGREEMENTS");
            DropForeignKey("COLLATERALSERVICE.COLLAGREEMENTS_CREDAGREEMENTS", "COLLATERALAGREEMENTID", "COLLATERALSERVICE.COLLATERALAGREEMENTS");
            DropIndex("COLLATERALSERVICE.COLLATERAL_CREDITAGREEMENTS", new[] { "CREDITAGREEMENTID" });
            DropIndex("COLLATERALSERVICE.COLLATERAL_CREDITAGREEMENTS", new[] { "COLLATERALID" });
            DropIndex("COLLATERALSERVICE.COLLATERAL_COLLGREEMENTS", new[] { "COLLATERALAGREEMENTID" });
            DropIndex("COLLATERALSERVICE.COLLATERAL_COLLGREEMENTS", new[] { "COLLATERALID" });
            DropIndex("COLLATERALSERVICE.COLLAGREEMENTS_CREDAGREEMENTS", new[] { "CREDITAGREEMENTID" });
            DropIndex("COLLATERALSERVICE.COLLAGREEMENTS_CREDAGREEMENTS", new[] { "COLLATERALAGREEMENTID" });
            DropTable("COLLATERALSERVICE.COLLATERAL_CREDITAGREEMENTS");
            DropTable("COLLATERALSERVICE.COLLATERAL_COLLGREEMENTS");
            DropTable("COLLATERALSERVICE.COLLAGREEMENTS_CREDAGREEMENTS");
            DropTable("COLLATERALSERVICE.CREDITAGREEMENTS");
            DropTable("COLLATERALSERVICE.COLLATERALAGREEMENTS");
            DropTable("COLLATERALSERVICE.COLLATERAL");
        }
    }
}
