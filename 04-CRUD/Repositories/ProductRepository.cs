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
            context.Products.Add(p);
            context.SaveChanges();
        }

        public void Update(Product p)
        {
            Product prod = context.Products.AsNoTracking().SingleOrDefault(pr => pr.Id == p.Id);

            if(prod != null)
            {
                context.Products.Attach(p);
                context.Entry(p).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Product not found.");
            }
        }

        public void Delete(int id)
        {
            Product prod = context.Products.Find(id);
            if (prod != null)
            {
                context.Products.Remove(prod); //etat: deleted
                context.SaveChanges(); //commande sql delete
            }
            else
            {
                throw new Exception("Product not found.");
            }
        }

        public List<Product> GetAll() 
        { 
            return context.Products.AsNoTracking().ToList();
        }

        public Product GetById(int id)
        {
            Product prod = context.Products.AsNoTracking().SingleOrDefault(pr => pr.Id == id);
            if (prod != null)
            {
                return prod;
            }
            else
            {
                throw new Exception("Product not found.");
            }
        }

        public List<Product> FindByKey(string key)
        {
            return context.Products.AsNoTracking().Where(p => p.Description.Contains(key)).ToList();    
        }
    }
}
