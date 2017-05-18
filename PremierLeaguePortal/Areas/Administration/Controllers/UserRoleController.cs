using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PremierLeaguePortal.Areas.Administration.Controllers
{
    [Authorize(Roles = "SuperUser,Author")]
    public class UserRoleController : Controller
    {
        // GET: Administration/UserRole
        public ActionResult Index()
        {
            return View();
        }
    }
}