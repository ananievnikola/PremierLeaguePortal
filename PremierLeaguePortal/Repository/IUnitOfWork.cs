using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PremierLeaguePortal.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IBlogRepository Blogs { get; }
        int Complete();
    }
}