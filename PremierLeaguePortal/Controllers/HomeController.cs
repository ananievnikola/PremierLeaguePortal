using AutoMapper;
using PremierLeaguePortal.DAL.Context;
using PremierLeaguePortal.Models;
using PremierLeaguePortal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PremierLeaguePortal.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new PremierLeagueContext());
        public ActionResult Index()
        {
            IEnumerable<Blog> blogs = _unitOfWork.Blogs.GetAll();

            List<HomeViewModel> hvm = Mapper.Map<List<HomeViewModel>>(blogs);
            return View(hvm);
        }

        public ActionResult More(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}