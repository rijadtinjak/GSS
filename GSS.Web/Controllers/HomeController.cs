using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GSS.Web.Models;
using GSS.Web.Helper;
using GSS.Web.Viewmodels;
using GSS.Database;

namespace GSS.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var k = HttpContext.GetLogiraniKorisnik<LoggedInUser>();
            if (k != null)
            {
                if (k.Role == typeof(User))
                    return RedirectToAction("Index", "Managers", new { Id = k.Id });
                if (k.Role == typeof(Superuser))
                    return RedirectToAction("Index", "Users");
            }

            return RedirectToAction("Index", "Login");
        }

    }
}
