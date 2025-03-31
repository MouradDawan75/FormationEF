namespace _03_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteFournisseurTable : DbMigration
    {
        public override void Up()
        {
            //Faire une sauvegarde de la table avant sa suppression
            CreateTable(
                "dbo._Fournisseurs",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO _Fournisseurs(Name) SELECT Name From Fournisseurs");

            DropTable("dbo.Fournisseurs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Fournisseurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO Fournisseurs(Name) SELECT Name From _Fournisseurs");

            DropTable("dbo._Fournisseurs");

        }
    }
}
