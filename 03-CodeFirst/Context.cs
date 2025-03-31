using System;
using System.Data.Entity;
using System.Linq;

namespace _03_CodeFirst
{
    public class Context : DbContext
    {
   
        public Context()
            : base("name=Context")
        {
        }

        //Un DbSet pour chaque classe objet
        public DbSet<Contact> Contacts { get; set; }
        //public DbSet<Fournisseur> Fournisseurs { get; set; }

    }
    /*
     * Etapes de code first:
     * 1- dans app.config -> modifier le nom de la base de données
     * 2- Un DbSet pour chaque classe objet
     * 3- Vérifer que le projet est sélectionné par défaut dans la solution
     * 4- Dans la console de gestionnaire de packages:  outils -> gestionnaire de packages -> affichez la console
     * 5- Choisir le projet dans la console de gestionnaire de packages
     * 6- Commande à exécuter qu'1 seule fois: enable-migrations
     * 7- Toute modification des classes objets, implique une migration: Add-Migration nom_migration
     * 8- Pour appliquer les modifications en BD: commade update-database
     * 
     * 9- Pour faire des reverts: Update-Database -TargetMigration: nom_migration
     * 
     * Important: ne pas supprimer les migrations appliquées en base de données
     * 
     * 
     * 
     * 
     */


}