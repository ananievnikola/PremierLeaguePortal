using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PremierLeaguePortal.Context;
using PremierLeaguePortal.Models;
using PremierLeaguePortal.Areas.Administration.Models;
using AutoMapper;

namespace PremierLeaguePortal.Areas.Administration.Controllers
{
    public class PlayerController : Controller
    {
        private PremierLeagueContext db = new PremierLeagueContext();
        //private readonly IMapper _mapper;

        public PlayerController()
        {
            //_mapper = mapper;
        }

        // GET: Administration/Player
        public ActionResult Index()
        {
            var players = db.Players.ToList();
            var pvm = Mapper.Map<IEnumerable<PlayerViewModel>>(players);
            //var wheelsVm = Mapper.Map<IEnumerable<WheelViewModel>>(wheels);
            //Player pl = db.Players;
            //p = _mapper.Map<PlayerViewModel>(pl);
            // p = Mapper.Map<Player, PlayerViewModel>();
            return View(pvm);
        }

        // GET: Administration/Player/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            var pvm = Mapper.Map<PlayerViewModel>(player);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(pvm);
        }

        // GET: Administration/Player/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Player/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlayerViewModel player)
        {
            if (ModelState.IsValid)
            {
                Player dbPlayer = Mapper.Map<Player>(player);
                dbPlayer.CreatedOn = DateTime.Now;
                db.Players.Add(dbPlayer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(player);
        }

        // GET: Administration/Player/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            PlayerViewModel pvm = Mapper.Map<PlayerViewModel>(player);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(pvm);
        }

        // POST: Administration/Player/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PlayerViewModel player)
        {
            if (ModelState.IsValid)
            {
                Player dbPlayer = Mapper.Map<Player>(player);
                //dbPlayer.CreatedOn = DateTime.Now;
                db.Entry(dbPlayer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(player);
        }

        // GET: Administration/Player/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Administration/Player/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = db.Players.Find(id);
            db.Players.Remove(player);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
