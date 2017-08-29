﻿using AutoMapper;
using PremierLeaguePortal.DAL.Context;
using PremierLeaguePortal.Models;
using PremierLeaguePortal.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PremierLeaguePortal.Controllers
{
    public class BlogCategoryController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new PremierLeagueContext());

        public ActionResult Analysis()
        {
            IEnumerable<Blog> blogs = _unitOfWork.Blogs.GetAllByCategoty(EBlogCategory.Analysis).OrderByDescending(b => b.PublishedOn);

            List<HomeViewModel> hvm = Mapper.Map<List<HomeViewModel>>(blogs).ToList();
            return View(hvm);
        }

        public ActionResult News()
        {
            IEnumerable<Blog> blogs = _unitOfWork.Blogs.GetAllByCategoty(EBlogCategory.News).OrderByDescending(b => b.PublishedOn);

            List<HomeViewModel> hvm = Mapper.Map<List<HomeViewModel>>(blogs).ToList();
            return View(hvm);
        }


        public ActionResult Transfers()
        {
            IEnumerable<Blog> blogs = _unitOfWork.Blogs.GetAllByCategoty(EBlogCategory.Transfers).OrderByDescending(b => b.PublishedOn);

            List<HomeViewModel> hvm = Mapper.Map<List<HomeViewModel>>(blogs).ToList();
            return View(hvm);
        }

        public ActionResult BlogDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = _unitOfWork.Blogs.GetById((int)id);

            HomeViewModel hvm = Mapper.Map<HomeViewModel>(blog);
            List<Blog> othersInCat = _unitOfWork.Blogs.GetAllByCategotyExceptCurrent(blog.Category, (int)id).OrderByDescending(b => b.PublishedOn).Take(3).ToList();
            hvm.OthersInCategory = Mapper.Map<List<HomeViewModel>>(othersInCat);
            return View(hvm);
        }

    }
}