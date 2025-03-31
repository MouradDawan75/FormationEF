namespace _03_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFournisseurClasse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fournisseurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            //Insérer des données dans la table
            Sql("INSERT INTO Fournisseurs(Nom) VALUES ('Carrefour')");
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fournisseurs");
        }
    }
}
