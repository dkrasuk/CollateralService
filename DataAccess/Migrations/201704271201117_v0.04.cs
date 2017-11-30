namespace AlfaBank.AlfaCollection.Services.PersonService.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v004 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("PERSONSERVICE.DOCUMENTS", "Person_Id", "PERSONSERVICE.PERSONS");
            DropIndex("PERSONSERVICE.DOCUMENTS", new[] { "Person_Id" });
            DropColumn("PERSONSERVICE.DOCUMENTS", "PERSONID");
            RenameColumn(table: "PERSONSERVICE.DOCUMENTS", name: "Person_Id", newName: "PERSONID");
            AlterColumn("PERSONSERVICE.DOCUMENTS", "PERSONID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("PERSONSERVICE.DOCUMENTS", "PERSONID", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("PERSONSERVICE.DOCUMENTS", "PERSONID");
            AddForeignKey("PERSONSERVICE.DOCUMENTS", "PERSONID", "PERSONSERVICE.PERSONS", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("PERSONSERVICE.DOCUMENTS", "PERSONID", "PERSONSERVICE.PERSONS");
            DropIndex("PERSONSERVICE.DOCUMENTS", new[] { "PERSONID" });
            AlterColumn("PERSONSERVICE.DOCUMENTS", "PERSONID", c => c.String(maxLength: 128));
            AlterColumn("PERSONSERVICE.DOCUMENTS", "PERSONID", c => c.Guid(nullable: false));
            RenameColumn(table: "PERSONSERVICE.DOCUMENTS", name: "PERSONID", newName: "Person_Id");
            AddColumn("PERSONSERVICE.DOCUMENTS", "PERSONID", c => c.Guid(nullable: false));
            CreateIndex("PERSONSERVICE.DOCUMENTS", "Person_Id");
            AddForeignKey("PERSONSERVICE.DOCUMENTS", "Person_Id", "PERSONSERVICE.PERSONS", "ID");
        }
    }
}
