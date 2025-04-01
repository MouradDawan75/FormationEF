// See https://aka.ms/new-console-template for more information
using _07_EfCore;

Console.WriteLine("Hello, World!");
/*
 * Différences avec la version .net framework de Entity Framework:
 * 
 ** 2 dépendences nuget:
 * entityframeworkcore.nom_base_de_données
 * entityframeworkcore.tools: à ajouter quelque soit la BD utilisée
 * 
 * Seule l'approche code first est possible avec EF Core
 * 
 * Pas besoin de la commande Enable-Migrations
 * Pas de méthode seed(). Pour insérer des données dans une table:
 * Le faire dans la FuentApi via la méthode HasData()
 * 
 */

var context = new MyContext();

var c = context.Contacts.Find(1);

Console.WriteLine(c.Name);