using PremierLeaguePortal.DAL.Context;
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
        private BlogRepository _Blogs;
        private ImageRepository _Image;
        private ApplicationUserRepository _User;
        //private GenericRepository<Course> courseRepository;
        public UnitOfWork(PremierLeagueContext context)
        {
            this._Context = context;
        }
        public BlogRepository Blogs
        {
            get
            {

                if (this._Blogs == null)
                {
                    this._Blogs = new BlogRepository(_Context);
                }
                return _Blogs;
            }
        }

        public ImageRepository Images
        {
            get
            {

                if (this._Image == null)
                {
                    this._Image = new ImageRepository(_Context);
                }
                return _Image;
            }
        }
        public ApplicationUserRepository User
        {
            get
            {

                if (this._User == null)
                {
                    this._User = new ApplicationUserRepository(_Context);
                }
                return _User;
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