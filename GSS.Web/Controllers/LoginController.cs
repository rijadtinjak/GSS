using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using GSS.Web.Helper;
using GSS.Database;
using GSS.Web.Viewmodels;

namespace GSS.Web.Controllers
{
    public class LoginController : Controller
    {
        private GSSContext _db;

        public LoginController(GSSContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.SetLogiraniKorisnik<object>(null);
            return RedirectToAction("Index");
        }

        public ActionResult Provjera(string email, string password)
        {
            var Organizacija = _db.Users.Where(x => x.Email == email && BCrypt.Net.BCrypt.Verify(password, x.Password, false, BCrypt.Net.HashType.SHA384) && x.Active).FirstOrDefault();

            if (Organizacija != null)
            {
                HttpContext.SetLogiraniKorisnik(new LoggedInUser
                {
                    Id = Organizacija.Id,
                    Role = typeof(User),
                    Name = Organizacija.OrganizationName
                });
                return RedirectToAction("Index", "Managers", new { Id = Organizacija.Id });
            }

            var Superuser = _db.Superusers.Where(x => x.Email == email && BCrypt.Net.BCrypt.Verify(password, x.Password, false, BCrypt.Net.HashType.SHA384) && x.Active).FirstOrDefault();
            if (Superuser != null)
            {
                HttpContext.SetLogiraniKorisnik(new LoggedInUser
                {
                    Id = Superuser.Id,
                    Role = typeof(Superuser),
                    Name = Superuser.Name
                });
                return RedirectToAction("Index", "Users");
            }

            TempData["error_poruka"] = "Neispravni pristupni podaci";
            return RedirectToAction("Index", "Login");
        }
    }
}
