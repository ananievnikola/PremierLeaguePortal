using PremierLeaguePortal.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PremierLeaguePortal.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        PremierLeagueContext _Context = null;
        private DbSet<T> entities = null;

        public GenericRepository(PremierLeagueContext context)
        {
            this._Context = context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return this.entities.ToList();
        }

        public T GetById(int id)
        {
            return this.entities.Find(id);
        }

        public void Insert(T model)
        {
            _Context.Entry(model).State = EntityState.Added;
        }

        public void Update(T model)
        {
            _Context.Entry(model).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            T existing = this.entities.Find(id);
            this.entities.Remove(existing);
        }

        public void Save()
        {
            _Context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}