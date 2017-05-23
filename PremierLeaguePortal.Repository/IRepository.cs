using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeaguePortal.Repository
{
    public interface IRepository<T> where T : EntityBase

    {
        T Get(int id);
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}
