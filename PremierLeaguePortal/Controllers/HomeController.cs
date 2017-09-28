using AutoMapper;
using PremierLeaguePortal.DAL.Context;
using PremierLeaguePortal.Models;
using PremierLeaguePortal.Repository;
using PremierLeaguePortal.Utils.MailService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace PremierLeaguePortal.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new PremierLeagueContext());
        private CustomEmailService _emailService = new CustomEmailService();
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(EmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                EmailMessage message = Mapper.Map<EmailMessage>(model);
                try
                {
                    _emailService.SendMail(message);
                }
                catch (HttpRequestValidationException htmlEx)
                {
                    return RedirectToAction("HtmlNotAllowed");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("HtmlNotAllowed");
                }   
                return RedirectToAction("Sent");
            }
            return View(model);
        }
        public ActionResult Sent()
        {
            return View();
        }

        public ActionResult HtmlNotAllowed()
        {
            ViewBag.Message = "You nasty...";

            return View();
        }
    }
}