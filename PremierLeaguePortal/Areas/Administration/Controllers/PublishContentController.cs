using AutoMapper;
using Microsoft.AspNet.Identity;
using PremierLeaguePortal.Areas.Administration.Models;
using PremierLeaguePortal.DAL.Context;
using PremierLeaguePortal.Models;
using PremierLeaguePortal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PremierLeaguePortal.Areas.Administration.Controllers
{
    [Authorize(Roles = "SuperUser")]
    public class PublishContentController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new PremierLeagueContext());
        // GET: Administration/PublishContent
        public ActionResult Index()
        {
            List<Blog> unpub = _unitOfWork.Blogs.GetAllUnpublished().ToList();
            List<BlogViewModel> bvm = Mapper.Map<List<BlogViewModel>>(unpub);
            return View(bvm);
        }

        public ActionResult Publish(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = null;
            blog = _unitOfWork.Blogs.GetById((int)id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            BlogViewModel bvm = Mapper.Map<BlogViewModel>(blog);
            return View(bvm);
        }

        [HttpPost, ActionName("Publish")]
        [ValidateAntiForgeryToken]
        public ActionResult PublishConfirmed(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _unitOfWork.Blogs.Publish((int)id);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}