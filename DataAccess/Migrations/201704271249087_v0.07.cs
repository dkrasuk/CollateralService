namespace AlfaBank.AlfaCollection.Services.PersonService.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v007 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("PERSONSERVICE.MASTERLINKS", "INTERNALID", "PERSONSERVICE.PERSONS");
            DropForeignKey("PERSONSERVICE.DOCUMENTS", "PERSONID", "PERSONSERVICE.PERSONS");
            DropPrimaryKey("PERSONSERVICE.DOCUMENTS");
            DropPrimaryKey("PERSONSERVICE.PERSONS");
            DropPrimaryKey("PERSONSERVICE.MASTERLINKS");
            AlterColumn("PERSONSERVICE.DOCUMENTS", "ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("PERSONSERVICE.PERSONS", "ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("PERSONSERVICE.MASTERLINKS", "ID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("PERSONSERVICE.DOCUMENTS", "ID");
            AddPrimaryKey("PERSONSERVICE.PERSONS", "ID");
            AddPrimaryKey("PERSONSERVICE.MASTERLINKS", "ID");
            AddForeignKey("PERSONSERVICE.MASTERLINKS", "INTERNALID", "PERSONSERVICE.PERSONS", "ID", cascadeDelete: true);
            AddForeignKey("PERSONSERVICE.DOCUMENTS", "PERSONID", "PERSONSERVICE.PERSONS", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("PERSONSERVICE.DOCUMENTS", "PERSONID", "PERSONSERVICE.PERSONS");
            DropForeignKey("PERSONSERVICE.MASTERLINKS", "INTERNALID", "PERSONSERVICE.PERSONS");
            DropPrimaryKey("PERSONSERVICE.MASTERLINKS");
            DropPrimaryKey("PERSONSERVICE.PERSONS");
            DropPrimaryKey("PERSONSERVICE.DOCUMENTS");
            AlterColumn("PERSONSERVICE.MASTERLINKS", "ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("PERSONSERVICE.PERSONS", "ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("PERSONSERVICE.DOCUMENTS", "ID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("PERSONSERVICE.MASTERLINKS", "ID");
            AddPrimaryKey("PERSONSERVICE.PERSONS", "ID");
            AddPrimaryKey("PERSONSERVICE.DOCUMENTS", "ID");
            AddForeignKey("PERSONSERVICE.DOCUMENTS", "PERSONID", "PERSONSERVICE.PERSONS", "ID", cascadeDelete: true);
            AddForeignKey("PERSONSERVICE.MASTERLINKS", "INTERNALID", "PERSONSERVICE.PERSONS", "ID", cascadeDelete: true);
        }
    }
}
