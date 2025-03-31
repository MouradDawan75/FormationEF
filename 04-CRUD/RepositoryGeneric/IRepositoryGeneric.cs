using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_CRUD.RepositoryGeneric
{
    public interface IRepositoryGeneric<T> where T : class
    {
        List<T> GetAll();
        void Delete(int id);
        void Insert(T obj);
        void Update(T obj);
        T GetById(int id);
    }
}
