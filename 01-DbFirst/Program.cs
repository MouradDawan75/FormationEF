using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DbFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Connexion à la DB
            var context = new cnxstring();
            employe e = new employe { nom = "DUPONT", prenom = "Jean" };

            context.employe.Add(e); // état de e dans le context = Added

            /*
             * la méthode saveChages(): génère une commande sql selon l'état de l'objet dans le context
             * Etat = Added -> commande sql insert
             * Etat = Modified -> update
             * Etat = Deleted -> delete
             * 
             */
            Console.WriteLine("Etat de e dans le context: "+context.Entry(e).State);

            context.SaveChanges(); //nécessaire pour les écritures en BD

            employe e1 = context.employe.Find(1);

            Console.WriteLine("Etat de e1 dans le context: " + context.Entry(e1).State); //Unchanged
            e1.nom = "DAWAN";

            Console.WriteLine("Etat de e1 dans le context: " + context.Entry(e1).State); //Modified

            context.SaveChanges();
            /*
            employe e2 = context.employe.Find(2);   
            context.employe.Remove(e2);

            Console.WriteLine("Etat de e2 dans le context: " + context.Entry(e2).State); //Deleted
            context.SaveChanges();
            */

            //Charger les données dans le context sans les conserver dans le cache du context
            employe e3 = context.employe.AsNoTracking().SingleOrDefault(emp => emp.Id == 3);
            employe e4 = context.employe.AsNoTracking().FirstOrDefault(emp => emp.nom.Contains("t"));

            Console.WriteLine("Etat de e3 dans le context: " + context.Entry(e3).State); //detached
            e3.nom = "new_name";
            Console.WriteLine("Etat de e3 dans le context: " + context.Entry(e3).State);

            context.SaveChanges(); //aucune modification en BD -> état = detached

            context.Entry(e3).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();


            //Maintenir la console active:
            Console.ReadLine();
        }
    }
}
