using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PremierLeaguePortal.Repository
{
    interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(int Id);

        void Insert(T model);

        void Update(T model);

        void Delete(int id);

        void Save();
    }
}