using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PremierLeaguePortal.Areas.Administration.Models;
using PremierLeaguePortal.DAL.Context;
using PremierLeaguePortal.Repository;
using PremierLeaguePortal.Models;
using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Net;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace PremierLeaguePortal.Areas.Administration.Controllers
{
    [Authorize(Roles = "SuperUser")]
    public class PoolController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new PremierLeagueContext());
        private string _poolItemValMsg = "Анкетата трябва да има поне две попълнени опции!";

        public ActionResult Index()
        {
            IEnumerable<Pool> pools = _unitOfWork.Pool.GetAll();
            List<PoolViewModel> bvm = Mapper.Map<List<PoolViewModel>>(pools);
            return View(bvm);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pool pool = _unitOfWork.Pool.GetById((int)id);
            PoolViewModel poolViewModel = Mapper.Map<PoolViewModel>(pool);
            if (poolViewModel == null)
            {
                return HttpNotFound();
            }
            return View(poolViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PoolName,Items")] PoolViewModel poolViewModel)
        {
            Pool pool = Mapper.Map<Pool>(poolViewModel);
            if (!ValidatePoolItems(pool))
            {
                poolViewModel.PoolItemsValidationMessage = _poolItemValMsg;
            }

            var user = _unitOfWork.User.GetById(User.Identity.GetUserId());
            if (ModelState.IsValid)
            {
                pool.CreatedOn = DateTime.Now;
                pool.ModifiedOn = DateTime.Now;
                pool.Author = user;
                pool.Items = pool.Items.Where(item => !string.IsNullOrEmpty(item.Label)).ToList();
                for (int i = 0; i < pool.Items.Count; i++)
                {
                    pool.Items[i].CreatedOn = DateTime.Now;
                    pool.Items[i].Number = i + 1;
                }
                _unitOfWork.Pool.Insert(pool);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            if (!string.IsNullOrEmpty(poolViewModel.PoolItemsValidationMessage))
            {
                return View(poolViewModel);
            }
            return View();
        }

        public ActionResult Activate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pool pool = _unitOfWork.Pool.GetById((int)id);
            if (pool == null)
            {
                return HttpNotFound();
            }
            pool.IsActive = true;
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Deactivate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pool pool = _unitOfWork.Pool.GetById((int)id);
            if (pool == null)
            {
                return HttpNotFound();
            }
            pool.IsActive = false;
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pool pool = _unitOfWork.Pool.GetById((int)id);
            if (pool == null)
            {
                return HttpNotFound();
            }
            List<PoolItem> items = _unitOfWork.PoolItem.GetAllPoolItemsByParentId((int)id);
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    _unitOfWork.PoolItem.Delete(item.Id);
                }
            }                      
            _unitOfWork.Pool.Delete((int)id);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        private bool ValidatePoolItems(Pool model)
        {
            bool validationResult = true;
            if (model.Items == null || model.Items.Count <= 0)
            {
                validationResult = false;
                return validationResult;
            }
            int counter = 0;
            for (int i = 0; i < model.Items.Count; i++)
            {
                if (string.IsNullOrEmpty(model.Items[i].Label))
                {
                    counter++;
                }
            }
            if (counter > 8)
            {
                ModelState.AddModelError("Too few valid items", "at least 2 options are required!");
                validationResult = false;
            }
            return validationResult;
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
