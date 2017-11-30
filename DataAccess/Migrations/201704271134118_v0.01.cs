namespace AlfaBank.AlfaCollection.Services.PersonService.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "PERSONSERVICE.DOCUMENTS",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        SERIES = c.String(maxLength: 2000),
                        NUMBER = c.String(maxLength: 2000),
                        ISSUEDATE = c.DateTime(),
                        ISSUER = c.String(maxLength: 2000),
                        TYPEID = c.String(nullable: false, maxLength: 2000),
                        PERSONID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("PERSONSERVICE.PERSONS", t => t.PERSONID, cascadeDelete: true)
                .Index(t => t.PERSONID);
            
            CreateTable(
                "PERSONSERVICE.PERSONS",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        RECORDHASH = c.String(maxLength: 2000),
                        FIRSTNAME = c.String(maxLength: 2000),
                        LASTNAME = c.String(maxLength: 2000),
                        PATRONYMIC = c.String(maxLength: 2000),
                        BIRTHDAY = c.DateTime(),
                        CATEGORYID = c.String(nullable: false, maxLength: 2000),
                        TYPEID = c.String(nullable: false, maxLength: 2000),
                        GENDERID = c.String(nullable: false, maxLength: 2000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "PERSONSERVICE.MASTERLINKS",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        MASTERID = c.String(maxLength: 2000),
                        MASTERSYSTENID = c.String(nullable: false, maxLength: 2000),
                        INTERNALID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("PERSONSERVICE.PERSONS", t => t.INTERNALID, cascadeDelete: true)
                .Index(t => t.INTERNALID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("PERSONSERVICE.MASTERLINKS", "INTERNALID", "PERSONSERVICE.PERSONS");
            DropForeignKey("PERSONSERVICE.DOCUMENTS", "PERSONID", "PERSONSERVICE.PERSONS");
            DropIndex("PERSONSERVICE.MASTERLINKS", new[] { "INTERNALID" });
            DropIndex("PERSONSERVICE.DOCUMENTS", new[] { "PERSONID" });
            DropTable("PERSONSERVICE.MASTERLINKS");
            DropTable("PERSONSERVICE.PERSONS");
            DropTable("PERSONSERVICE.DOCUMENTS");
        }
    }
}
