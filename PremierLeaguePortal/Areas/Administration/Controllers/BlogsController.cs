using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PremierLeaguePortal.Models;
using PremierLeaguePortal.Utilities.FileUtils;
using System.IO;
using PremierLeaguePortal.Areas.Administration.Models;
using AutoMapper;
using PremierLeaguePortal.Repository;
using PremierLeaguePortal.DAL.Context;
using Microsoft.AspNet.Identity;

namespace PremierLeaguePortal.Areas.Administration.Controllers
{
    [Authorize(Roles = "SuperUser,Author")]
    public class BlogsController : Controller, IDisposable
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new PremierLeagueContext());


        // GET: Administration/Blogs
        public ActionResult Index()
        {
            return View(_unitOfWork.Blogs.GetAll());
        }

        // GET: Administration/Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = _unitOfWork.Blogs.GetById((int)id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Administration/Blogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BlogViewModel model)
        {           
            HttpPostedFileBase upload = model.HeaderImageFile;
            var user = _unitOfWork.User.GetById(User.Identity.GetUserId());
            Blog blog = Mapper.Map<Blog>(model);
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    string fileName = upload.FileName.Split('.')[0] + Guid.NewGuid() + "." + upload.FileName.Split('.')[1];
                    string serverPath = Server.MapPath("~/Images/" + fileName);
                    string physicalPath = Path.Combine("Images/", fileName);

                    CustomHttpPostedFile f = new CustomHttpPostedFile(upload.InputStream, "jpg", serverPath);
                    f.SaveAs(serverPath);

                    Image image = new Image()
                    {
                        ImageName = upload.FileName,
                        ImagePhysicalPath = physicalPath,
                        ImageServerPath = serverPath,
                        CreatedOn = DateTime.Now,
                        Type = EImageType.HeaderImage
                    };

                    blog.HeaderImage = image;

                }
                blog.CreatedOn = DateTime.Now;
                blog.ModifiedOn = DateTime.Now;
                blog.ApplicationUser = user;
                _unitOfWork.Blogs.Insert(blog);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(blog);
        }

        // GET: Administration/Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            Blog blog = _unitOfWork.Blogs.GetById((int)id);
            
            if (blog == null)
            {
                return HttpNotFound();
            }
            BlogViewModel bvm = Mapper.Map<BlogViewModel>(blog);
            return View(bvm);
        }

        // POST: Administration/Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BlogViewModel model)
        {
            HttpPostedFileBase upload = model.HeaderImageFile;
            Blog blog = Mapper.Map<Blog>(model);
            if (ModelState.IsValid)
            {
                blog.ModifiedOn = DateTime.Now;
                if (upload != null && upload.ContentLength > 0)
                {
                    if (blog.HeaderImage != null)
                    {
                        try
                        {

                            System.IO.File.Delete(blog.HeaderImage.ImageServerPath);
                        }
                        catch (IOException ex)
                        {
                            //TODO
                        }
                    }
                    string fileName = upload.FileName.Split('.')[0] + Guid.NewGuid() + "." + upload.FileName.Split('.')[1];
                    string serverPath = Server.MapPath("~/Images/" + fileName);
                    string physicalPath = Path.Combine("Images/", fileName);
                    CustomHttpPostedFile f = new CustomHttpPostedFile(upload.InputStream, "jpg", serverPath);
                    f.SaveAs(serverPath);
                    Image image = new Image()
                    {
                        Id = model.HeaderImage.Id,
                        ImageName = upload.FileName,
                        ImagePhysicalPath = physicalPath,
                        ImageServerPath = serverPath,
                        CreatedOn = DateTime.Now,
                        Type = EImageType.HeaderImage
                    };
                    blog.HeaderImage = image;
                    _unitOfWork.Images.Update(image);
                }
                _unitOfWork.Blogs.Update(blog);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Administration/Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = _unitOfWork.Blogs.GetById((int)id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Administration/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = _unitOfWork.Blogs.GetById((int)id);
            Image image = blog.HeaderImage;
            if (image != null)
            {
                try
                {

                    System.IO.File.Delete(blog.HeaderImage.ImageServerPath);
                    _unitOfWork.Images.Delete(image.Id);
                }
                catch (IOException ex)
                {
                    //TODO
                }

            }

            _unitOfWork.Blogs.Delete(blog.Id);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
