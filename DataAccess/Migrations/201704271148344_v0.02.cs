namespace AlfaBank.AlfaCollection.Services.PersonService.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v002 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("PERSONSERVICE.DOCUMENTS", "PERSONID", "PERSONSERVICE.PERSONS");
            DropForeignKey("PERSONSERVICE.MASTERLINKS", "INTERNALID", "PERSONSERVICE.PERSONS");
            DropIndex("PERSONSERVICE.DOCUMENTS", new[] { "PERSONID" });
            DropIndex("PERSONSERVICE.MASTERLINKS", new[] { "INTERNALID" });
            DropPrimaryKey("PERSONSERVICE.DOCUMENTS");
            DropPrimaryKey("PERSONSERVICE.PERSONS");
            DropPrimaryKey("PERSONSERVICE.MASTERLINKS");
            AlterColumn("PERSONSERVICE.DOCUMENTS", "ID", c => c.Guid(nullable: false));
            AlterColumn("PERSONSERVICE.DOCUMENTS", "PERSONID", c => c.Guid(nullable: false));
            AlterColumn("PERSONSERVICE.PERSONS", "ID", c => c.Guid(nullable: false));
            AlterColumn("PERSONSERVICE.MASTERLINKS", "ID", c => c.Guid(nullable: false));
            AlterColumn("PERSONSERVICE.MASTERLINKS", "INTERNALID", c => c.Guid(nullable: false));
            AddPrimaryKey("PERSONSERVICE.DOCUMENTS", "ID");
            AddPrimaryKey("PERSONSERVICE.PERSONS", "ID");
            AddPrimaryKey("PERSONSERVICE.MASTERLINKS", "ID");
            CreateIndex("PERSONSERVICE.DOCUMENTS", "PERSONID");
            CreateIndex("PERSONSERVICE.MASTERLINKS", "INTERNALID");
            AddForeignKey("PERSONSERVICE.DOCUMENTS", "PERSONID", "PERSONSERVICE.PERSONS", "ID", cascadeDelete: true);
            AddForeignKey("PERSONSERVICE.MASTERLINKS", "INTERNALID", "PERSONSERVICE.PERSONS", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("PERSONSERVICE.MASTERLINKS", "INTERNALID", "PERSONSERVICE.PERSONS");
            DropForeignKey("PERSONSERVICE.DOCUMENTS", "PERSONID", "PERSONSERVICE.PERSONS");
            DropIndex("PERSONSERVICE.MASTERLINKS", new[] { "INTERNALID" });
            DropIndex("PERSONSERVICE.DOCUMENTS", new[] { "PERSONID" });
            DropPrimaryKey("PERSONSERVICE.MASTERLINKS");
            DropPrimaryKey("PERSONSERVICE.PERSONS");
            DropPrimaryKey("PERSONSERVICE.DOCUMENTS");
            AlterColumn("PERSONSERVICE.MASTERLINKS", "INTERNALID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("PERSONSERVICE.MASTERLINKS", "ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("PERSONSERVICE.PERSONS", "ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("PERSONSERVICE.DOCUMENTS", "PERSONID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("PERSONSERVICE.DOCUMENTS", "ID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("PERSONSERVICE.MASTERLINKS", "ID");
            AddPrimaryKey("PERSONSERVICE.PERSONS", "ID");
            AddPrimaryKey("PERSONSERVICE.DOCUMENTS", "ID");
            CreateIndex("PERSONSERVICE.MASTERLINKS", "INTERNALID");
            CreateIndex("PERSONSERVICE.DOCUMENTS", "PERSONID");
            AddForeignKey("PERSONSERVICE.MASTERLINKS", "INTERNALID", "PERSONSERVICE.PERSONS", "ID", cascadeDelete: true);
            AddForeignKey("PERSONSERVICE.DOCUMENTS", "PERSONID", "PERSONSERVICE.PERSONS", "ID", cascadeDelete: true);
        }
    }
}
