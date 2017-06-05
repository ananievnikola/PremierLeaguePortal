using PremierLeaguePortal.Context;
using PremierLeaguePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PremierLeaguePortal.Repository
{
    public class UnitOfWork : IDisposable
    {
        private PremierLeagueContext _Context;// = new PremierLeagueContext();
        private GenericRepository<Blog> _Blogs;
        private GenericRepository<Image> _Image;
        //private GenericRepository<Course> courseRepository;
        public UnitOfWork(PremierLeagueContext context)
        {
            this._Context = context;
        }
        public GenericRepository<Blog> Blogs
        {
            get
            {

                if (this._Blogs == null)
                {
                    this._Blogs = new GenericRepository<Blog>(_Context);
                }
                return _Blogs;
            }
        }

        public GenericRepository<Image> Images
        {
            get
            {

                if (this._Image == null)
                {
                    this._Image = new GenericRepository<Image>(_Context);
                }
                return _Image;
            }
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