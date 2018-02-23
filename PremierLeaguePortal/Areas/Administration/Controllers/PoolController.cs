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
using System.ComponentModel.DataAnnotations;

namespace PremierLeaguePortal.Areas.Administration.Controllers
{
    [Authorize(Roles = "SuperUser")]
    public class PoolController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new PremierLeagueContext());

        // GET: Administration/Pool
        public ActionResult Index()
        {
            IEnumerable<Pool> pools = _unitOfWork.Pool.GetAll();
            List<PoolViewModel> bvm = Mapper.Map<List<PoolViewModel>>(pools);
            return View(bvm);
        }

        // GET: Administration/Pool/Details/5
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

        // GET: Administration/Pool/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Pool/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PoolName,Items")] PoolViewModel poolViewModel)
        {
            Pool pool = Mapper.Map<Pool>(poolViewModel);
            if (!ValidatePoolItems(pool))
            {
                poolViewModel.PoolItemsValidationMessage = "Всички отговори за анкетата трябва да бъдат попълнени";
            }
            //List<PoolItem> poolItems = Mapper.Map<List<PoolItem>>(poolViewModel.Items);
            
            var user = _unitOfWork.User.GetById(User.Identity.GetUserId());
            if (ModelState.IsValid)
            {
                pool.CreatedOn = DateTime.Now;
                pool.ModifiedOn = DateTime.Now;
                pool.Author = user;
                for (int i = 0; i < pool.Items.Count; i++)
                {
                    //if (string.IsNullOrEmpty(pool.Items[i].Label))
                    //{
                    //    pool.Items.Remove(pool.Items[i]);
                    //    continue;
                    //}
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

        // GET: Administration/Pool/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Administration/Pool/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PoolViewModel poolViewModel)
        {
            //Pool pool = Mapper.Map<Pool>(poolViewModel);
            
            //var user = _unitOfWork.User.GetById(User.Identity.GetUserId());
            if (ModelState.IsValid)
            {
                Pool pool = _unitOfWork.Pool.GetById(poolViewModel.Id);
                
                if (pool != null)
                {
                    pool.ModifiedOn = DateTime.Now;
                    if (pool.Items != null)
                    {
                        int index = pool.Items.Count;
                        int[] ids = new int[index];
                        for (int i = 0; i < index; i++)
                        {
                            ids[i] = pool.Items[i].Id;
                        }
                        for (int i = 0; i < index; i++)
                        {
                            _unitOfWork.PoolItem.Delete(ids[i]);
                        }
                        pool.Items.Clear();
                        List<PoolItem> poolItems = Mapper.Map<List<PoolItem>>(poolViewModel.Items);
                        pool.Items = poolItems;
                    }
                    _unitOfWork.Save();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Administration/Pool/Delete/5
        public ActionResult Delete(int? id)
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

        public ActionResult Activate(int id)
        {
            Pool pool = _unitOfWork.Pool.GetById(id);
            pool.IsActive = true;
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Deactivate(int id)
        {
            Pool pool = _unitOfWork.Pool.GetById(id);
            pool.IsActive = false;
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        // POST: Administration/Pool/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List<PoolItem> items = _unitOfWork.PoolItem.GetAllPoolItemsByParentId(id);
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    _unitOfWork.PoolItem.Delete(item.Id);
                }
            }                      
            _unitOfWork.Pool.Delete(id);
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
            for (int i = 0; i < model.Items.Count; i++)
            {
                if (string.IsNullOrEmpty(model.Items[i].Label))
                {
                    ModelState.AddModelError("model.Items" + i, "label is required");
                    validationResult = false;
                }
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
