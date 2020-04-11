using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Respository
{
     public interface IRepository <T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int Id);
        void Insert(T obj);
        void Delete(int id);
        void Update(T obj);
    }
}
