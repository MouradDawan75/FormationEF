namespace _03_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameFournisseurPropertyNom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fournisseurs", "Name", c => c.String());

            //MAJ de la nouvelle colonne à partir de l'ancienne avant sa suppression
            Sql("Update Fournisseurs Set Name=Nom");

            DropColumn("dbo.Fournisseurs", "Nom");

            //RenameColumn("dbo.Fournisseurs", "Nom", "Name"); ligne qui remplace les 3 premières
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fournisseurs", "Nom", c => c.String());

            Sql("Update Fournisseurs Set Nom=Name");

            DropColumn("dbo.Fournisseurs", "Name");
        }
    }
}
