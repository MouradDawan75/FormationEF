using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04_CRUD.Models;
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
                    3- MAJ à jours un produit
                    4- Supprimer un produit
                    5- Rechercher un produit par son id
                    6- Rechercher les produits par mot clé
                    7- Quitter

                    Votre choix:

                ");

                int choix = Convert.ToInt32(Console.ReadLine());

                if (choix == 7){
                    Console.WriteLine("Fin du programme.......");
                    break;
                }

                switch (choix)
                {
                    case 1:
                        List<Product> all = service.GetAll();
                        if(all.Count == 0)
                        {
                            Console.WriteLine("No product to read..");
                        }
                        else
                        {
                            foreach(Product p in all)
                            {
                                Console.WriteLine(p.Description+" "+p.Price);
                                Console.WriteLine("============================");
                            }
                        }
                        break;

                    case 2:
                        Console.WriteLine("Nom: ");
                        string nom = Console.ReadLine();

                        Console.WriteLine("Price: ");
                        double price = Convert.ToDouble(Console.ReadLine());

                        service.Insert(new Product {  Description = nom, Price = price });
                        Console.WriteLine("Product inserted.");
                        break;


                        case 3:
                        Console.WriteLine("Id: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            if (service.GetById(id) != null)
                            {
                                Console.WriteLine("Nom: ");
                                string nom1 = Console.ReadLine();

                                Console.WriteLine("Price: ");
                                double price1 = Convert.ToDouble(Console.ReadLine());
                                service.Update(new Product { Id = id, Description = nom1, Price = price1 });
                                Console.WriteLine("Product updated....");
                              

                            }
                            else
                            {
                                Console.WriteLine("Product not found...");
                            }

                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(  ex.Message); 
                        }
                      
                        break;

                    case 4:
                        Console.WriteLine("Id: ");
                        int id_to_delete = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            if (service.GetById(id_to_delete) != null)
                            {

                                service.Delete(id_to_delete);
                                Console.WriteLine("Product deleted....");



                            }
                            else
                            {
                                Console.WriteLine("Product not found...");
                            }

                           
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e.Message);
                        }
                        break;

                    case 5:
                        Console.WriteLine("Id: ");
                        int id_to_find = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            Product prod = service.GetById(id_to_find);
                            if (prod != null)
                            {
                                Console.WriteLine(prod.Description + " " + prod.Price);

                            }
                            else
                            {
                                Console.WriteLine("Product not found...");
                            }

                           
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case 6:
                        Console.WriteLine("Mot clé: ");
                        string key = Console.ReadLine();
                        List<Product> result = service.FindByKey(key);
                        if(result.Count == 0)
                        {
                            Console.WriteLine("No product found.");
                        }
                        else
                        {
                            foreach (Product item in result)
                            {
                                Console.WriteLine(  item.Description+" "+item.Price);
                            }
                        }

                        break;
                    default:
                        Console.WriteLine("Invalide choice............");
                        break;
                }


            }


            //maintenir console active
            Console.Read();
        }
    }
}
