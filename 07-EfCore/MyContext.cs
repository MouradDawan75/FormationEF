using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace _07_EfCore
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source = (localdb)\MSSQLLocalDB; initial catalog=efcore;integrated security=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Contact> Contacts { get; set; }

        //FluentApi
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            base.OnModelCreating(modelBuilder);

            //Dans la version (.net framework): on peut utiliser la méthode seed() pour insérer des données de test
            //insertion de données de test
            modelBuilder.Entity<Contact>().HasData(new Contact { Id = 1 , Name = "Dawan"}, new Contact { Id = 2, Name = "Jehann"});
        }
    }
}
/*
 * Dans la version core:
 * la commande enable-migrations n'est plus nécessaire
 * 
 */