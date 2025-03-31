using System;
using System.Data.Entity;
using System.Linq;
using _04_CRUD.Models;

namespace _04_CRUD.Repositories
{
    public class MyContext : DbContext
    {
        
        public MyContext()
            : base("name=MyContext")
        {
        }
        public DbSet<Product> Products { get; set; }

    }
    /*
     * Enable-Migrations
     * Add-Migration initialModel
     * Update-Database
     * 
     */
   
}