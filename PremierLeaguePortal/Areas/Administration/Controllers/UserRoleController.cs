using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
    public class UserRoleController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new PremierLeagueContext());
        // GET: Administration/UserRole
        public ActionResult Index()
        {
            List<ApplicationUser> normalUsers = _unitOfWork.User.GetUsersInRole("NormalUser").ToList();
            return View(normalUsers);
        }

        public ActionResult AssignAuthorRole(string Id)
        {
            _unitOfWork.User.RemoveUserFromRole(Id, "NormalUser");
            _unitOfWork.User.AddUserToRole(Id, "Author");
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public ActionResult RemoveAuthorRole(string Id)
        {
            _unitOfWork.User.RemoveUserFromRole(Id, "Author");
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
            List<string> userToDeleteRoles = _unitOfWork.User.GetUserRoles(Id);
            foreach (var role in userToDeleteRoles)
            {
                _unitOfWork.User.RemoveUserFromRole(userToDelete.Id, role);//TODO: Move to the repository
            }
            //_unitOfWork.User.RemoveUserFromRole(userToDelete.Id, "Author");
            _unitOfWork.User.Delete(Id);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}