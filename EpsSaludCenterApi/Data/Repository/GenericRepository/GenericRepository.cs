using Data.Models;
using Data.Respository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        public epsContext _context = null;
        private DbSet<T> _table = null;

        public GenericRepository() {
            this._context = new epsContext();
            this._table = this._context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {

            return this._table.ToList();
        }

        public T GetById(int id)
        {
            return this._table.Find(id);
        }
        public void Insert(T obj)
        {
            this._table.Add(obj);
        }
        public void Update(T obj)
        {
            this._table.Attach(obj);
            this._context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
        }

        public void Save() {
            _context.SaveChanges();
        }
    }
}
