using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ModelFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new Model1Container();

            Blog b1 = new Blog {Id = 1, Nom = "c#" };
            Blog b2 = new Blog {Id = 2,  Nom = "java" };

            context.BlogSet.Add(b1);
           context.BlogSet.Add(b2);

            context.SaveChanges();

            Post p1 = new Post { Contenu = "post1", BlogId = 1 };
            Post p2 = new Post { Contenu = "post2", BlogId = 2 };

            context.PostSet.Add(p1);
            context.PostSet.Add(p2);

            context.SaveChanges();

            Console.WriteLine("Données insérées......");



            //maintenir la console active
            Console.Read();
        }
    }
}
