using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04_CRUD.Services;

namespace _04_CRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductService service = new ProductService();

            while (true)
            {

                Console.WriteLine(@"

                    Menu:
                    1- Afficher tous les produits
                    2- Insérer un produit
                    3- MAJ à jours u produit
                    4- Supprimer un produit
                    5- Rechercher un produit par son id
                    6- Rechercher les produits par mot clé
                    7- Quitter

                    Votre choix:

                ");

                int choix = Convert.ToInt32(Console.ReadLine());

                if (choix == 7){
                    break;
                }

                switch (choix)
                {
                    case 1:

                        break;
                    default:
                        Console.WriteLine("Choix invalide............");
                        break;
                }


            }


            //maintenir console active
            Console.Read();
        }
    }
}
