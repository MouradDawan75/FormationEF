using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _06_FluentApi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new MyContext();

            /*
             * IList est une collection el lecture/écriture
             * IEnumerable: est une collection en lecture (liste constante)
             */

            IList<Author> authors = context.Authors.ToList();
            
            IEnumerable<Author> authors2 = context.Authors.ToList();
            /*
             * Chargement des relations:
             * Lazy Loading: chargement tardif - à la demande
             * Eager Loading: chargeùent immédiat
             * 
             */

            Console.WriteLine(">>>>>> Chargement des relations:");

            Console.WriteLine("** Many:");
            //var author1 = context.Authors.Find(1);

            //les relations many: sont en Lazy par défaut

            //Pour la demande explicite: utilisez la méthode include
            var author1 = context.Authors.Include(a => a.Courses).SingleOrDefault(a => a.Id == 1);

            foreach (var course in author1.Courses)
            {
                Console.WriteLine(course.Name);
            }

            Console.WriteLine("** One:");

            //Les relations One sont en mode Eager par défaut

            var course1 = context.Courses.Find(1);
            Console.WriteLine(course1.Author.Name);


            //Many Tag: demande explicite via la méthode include()
            course1 = context.Courses.Include(c => c.Tags).SingleOrDefault(c => c.Id == 1);

            foreach (var t in course1.Tags)
            {
                Console.WriteLine(t.Name);
            }

            #region LINQ

            Console.WriteLine(">>>>>>>>>>>> LINQ:");
            /*
             * LINQ: Language Integrated Query: propre à Microsoft et permettant d'interoger n'importe quelle
             * source de données: base de données, fichiers, collections.....
             * 
             * 2 façons de l'utiliser:
             * via sa syntaxe: proche de sql
             * via chainage d'appelles de méthodes
             * 
             */

            Console.WriteLine(">>>>>>>>>>>>> Syntaxe LINQ:");
            /*
             * Syntaxe de LINQ: adéquate pour ceux qui utilisent SQL
             * 
             * un select renvoie une collection
             */

            Console.WriteLine("__restriction:");

            //restriction: author dont id = 1
            var query1 = from a in context.Authors
                        where a.Id == 1
                        select a;

            foreach (var item in query1) {
                Console.WriteLine(item.Name);
                    }


            Console.WriteLine("__orderby:");
            //order: liste des courses de author1 orderby courseName
            var query2 = from c in context.Courses
                        where c.AuthorId == 1
                        orderby c.Name descending //ascending
                        select c;

            foreach (var item in query2)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("__projections:");

            //course name de author1 + author name

            var query3 = from c in context.Courses
                         where c.AuthorId == 1

                         /*
                          * option1:
                          * créer classe contenant les infos à extraire
                          * 
                          * option2:
                          * utiliser le type anonyme
                          * 
                          */
                         //select new CourseAuthor { CourseName = c.Name, AuthorName = c.Author.Name };

                         select new {CourseName = c.Name, AuthorName = c.Author.Name};

            //le type anonyme: pratique pour stocker des données de manière temporaire
            var student = new { Id = 1, Name = "Marc" };
            Console.WriteLine(student.Id);
            Console.WriteLine(student.Name);

            //student.Name = "Jean"; impossible de modifier le contenu d'un objet anonyme

            //sous type anonyme

            var student2 = new
            {
                Name = "David",
                Adresse = new { rue = "5 rue Machin", codePostal = 75010 }
            };

            foreach (var item in query3) {

                Console.WriteLine(item.CourseName+" "+item.AuthorName);
            }

            Console.WriteLine("__groupby:");

            //Regrouper les courses par prix

            var query4 = from c in context.Courses
                         group c by c.FullPrice
                         into g
                         select g; //liste de groupes

            foreach (var group in query4)
            {
                //la clé de groupage (FullPrice)
                Console.WriteLine("Prix: "+group.Key);
                foreach(var c in group)
                {
                    Console.WriteLine("\t"+c.Name);
                }
            }

            Console.WriteLine("__jointures:");

            //inner join, group join, cross join

            var query5 = from a in context.Authors
                         join c in context.Courses on a.Id equals c.AuthorId
                         select new { CourseName = c.Name, AuthorName = a.Name };


            //Group join:

            var query6 = from a in context.Authors
                         join c in context.Courses on a.Id equals c.AuthorId into g
                         select new { AutorName = a.Name, NbCourses = g.Count() };

            //Cross: toutes les ignes de la table de gauche avec chaque ligne de la table de droite

             var query7 = from a in context.Authors
                          from c in context.Courses
                          select new { CourseName = c.Name, AuthorName= a.Name };


            Console.WriteLine(">>>>>>>>>>>>> Chainage de méthodes:");

            Console.WriteLine("__restriction:");

            List<Course> coursesAuthor1 = context.Courses.Where(c => c.AuthorId == 1).ToList();

            Console.WriteLine("__projection:");

            var result = context.Courses.Where(c => c.AuthorId == 1)
                .Select(c => new { CourseName = c.Name, AythorName = c.Author.Name });


            #endregion



            //maintenir la console active
            Console.ReadLine();
        }
    }
}
