using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04_CRUD.Models;

namespace _04_CRUD.Repositories
{
    public class ProductRepository
    {
        private MyContext context = new MyContext();

        public void Insert(Product p)
        {

        }

        public void Update(Product p)
        {

        }

        public void Delete(int id)
        {

        }

        public List<Product> GetAll() 
        { 
            return null;
        }

        public Product GetById(int id)
        {
            return null;
        }

        public List<Product> FindByKey(string key)
        {
            return null;
        }
    }
}
