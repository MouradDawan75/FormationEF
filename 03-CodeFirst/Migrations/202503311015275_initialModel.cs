namespace _03_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        //down() doit faire l'inverse de la méthode up()
        public override void Down()
        {
            DropTable("dbo.Contacts");
        }
    }
}
