using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04_CRUD.Models;
using _04_CRUD.Repositories;

namespace _04_CRUD.Services
{
    public class ProductService

        /*
         * Règles métiers:
         * Le prix max d'un produit est 1000€
         * La quantité du produit pc dell est limitée à 100 dans stock
         */
    {
        private ProductRepository productRepository = new ProductRepository();

        public void Insert(Product p)
        {
            /*
            int count = FindByKey("PC Dell").Count();
            if((p.Price > 1000) || (p.Description == "PC Dell" && count == 100)){
                throw new Exception("");
            }
            */
            productRepository.Insert(p);
        }

        public void Update(Product p)
        {
            productRepository.Update(p);
        }

        public void Delete(int id)
        {
            productRepository.Delete(id);
        }

        public Product GetById(int id) { 
        return productRepository.GetById(id);
        }

        public List<Product> GetAll()
        {
            return productRepository.GetAll();
        }

        public List<Product> FindByKey(string key)
        {
            return productRepository.FindByKey(key);
        }

        public List<Product> PriceBetweenMinAndMax(double priceMin, double priceMax)
        {
            return productRepository.GetAll().Where(p => p.Price >= priceMin && p.Price <= priceMax).ToList();
        }
    }
}
