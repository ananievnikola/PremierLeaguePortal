using PremierLeaguePortal.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PremierLeaguePortal.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PremierLeagueContext _context;

        public UnitOfWork(PremierLeagueContext context)
        {
            _context = context;
            Blogs = new BlogRepository(_context);
            Images = new ImageRepository(_context);
        }

        public IImageRepository Images { get; private set; }
        public IBlogRepository Blogs { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}