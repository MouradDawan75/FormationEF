using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04_CRUD.Models;
using _04_CRUD.Repositories;

namespace _04_CRUD.Services
{
    public class ProductService
    {
        private ProductRepository productRepository = new ProductRepository();

        public void Insert(Product p)
        {
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
    }
}
