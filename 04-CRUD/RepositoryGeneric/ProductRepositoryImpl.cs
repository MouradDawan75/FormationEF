using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04_CRUD.Models;
using _04_CRUD.Repositories;

namespace _04_CRUD.RepositoryGeneric
{
    public class ProductRepositoryImpl<T> : IRepositoryGeneric<T> where T : class
    {
        private MyContext context;
        private DbSet<T> dbSet;

        public ProductRepositoryImpl(MyContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }


        public void Delete(int id)
        {
            var obj = dbSet.Find(id);
            if (context.Entry(obj).State == EntityState.Detached) {
                dbSet.Attach(obj);               
            }
            dbSet.Remove(obj);
            context.SaveChanges();
        }


        public void Insert(T obj)
        {
            dbSet.Add(obj);
            context.SaveChanges();

        }


        public void Update(T obj)
        {
            dbSet.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges() ;
        }

        List<T> IRepositoryGeneric<T>.GetAll()
        {
            return dbSet.ToList();
        }

        T IRepositoryGeneric<T>.GetById(int id)
        {
            return dbSet.Find(id);
        }
    }
}
