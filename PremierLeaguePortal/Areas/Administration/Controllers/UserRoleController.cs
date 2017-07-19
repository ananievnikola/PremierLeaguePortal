using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
    public class UserRoleController : Controller, IDisposable
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new PremierLeagueContext());
        // GET: Administration/UserRole
        public ActionResult Index()
        {
            List<ApplicationUser> users = _unitOfWork.User.GetUsersNotInRole("SuperUser").ToList();
            //List<UserRoleViewModel> uvm = new List<UserRoleViewModel>();
            //foreach (var user in users)
            //{
            //    UserRoleViewModel vmpi = new UserRoleViewModel();
            //    vmpi.ApplicationUser = user;
            //    vmpi.isAuthor = user.Roles.con
            //}
            return View(users);
        }

        public ActionResult AssignAuthorRole(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //_unitOfWork.User.RemoveUserFromRole(Id, "NormalUser");
            _unitOfWork.User.AddUserToRole(Id, "Author");
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        public ActionResult AssignSuperUserRole(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //_unitOfWork.User.RemoveUserFromRole(Id, "NormalUser");
            _unitOfWork.User.AddUserToRole(Id, "SuperUser");
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public ActionResult RemoveAuthorRole(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _unitOfWork.User.RemoveUserFromRole(Id, "Author");
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public ActionResult RemoveSuperUserRole(string Id, string roleName)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _unitOfWork.User.RemoveUserFromRole(Id, roleName);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser userToDelete = _unitOfWork.User.GetById(Id);
            return View(userToDelete);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser userToDelete = _unitOfWork.User.GetById(Id);
            List<string> userToDeleteRoles = _unitOfWork.User.GetUserRoles(Id);
            foreach (var role in userToDeleteRoles)
            {
                _unitOfWork.User.RemoveUserFromRole(userToDelete.Id, role);
            }
            
            var blogPostsByUser = _unitOfWork.Blogs.GetAllByUser(Id);
            foreach (var blog in blogPostsByUser)
            {
                blog.ApplicationUser = _unitOfWork.User.GetAll().FirstOrDefault(u => u.Id == Id);
                _unitOfWork.Blogs.Delete(blog.Id);
            }
            _unitOfWork.User.Delete(Id);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}