using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeaguePortal.Repository
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        //public void Create(T entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(T entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public T GetById(long id)
        //{
        //    throw new NotImplementedException();
        //}

        //public T GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update(T entity)
        //{
        //    throw new NotImplementedException();
        //}
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
