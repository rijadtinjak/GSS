using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GSS.Database;
using GSS.Web.Helper;
using GSS.Web.Viewmodels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;


namespace eUniverzitet.Web.Helper
{

    public class AuthorizationAttribute : TypeFilterAttribute
    {
        public AuthorizationAttribute(bool superuser = false, bool organizacija = false)
            : base(typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] { superuser, organizacija };
        }
    }


    public class MyAuthorizeImpl : IAsyncActionFilter
    {
        public MyAuthorizeImpl(bool superuser, bool organizacija)
        {
            _superuser = superuser;
            _organizacija = organizacija;
        }
        private readonly bool _superuser;
        private readonly bool _organizacija;
        public async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            var k = filterContext.HttpContext.GetLogiraniKorisnik<LoggedInUser>();
            if (k == null)
            {
                if (filterContext.Controller is Controller controller)
                {
                    controller.TempData["error_poruka"] = "Niste logirani";
                }

                filterContext.Result = new RedirectToActionResult("Index", "Login", new { @area = "" });
                return;
            }

            if (_superuser && k.Role == typeof(Superuser))
            {
                await next(); //ok - ima pravo pristupa
                return;
            }

            if (_organizacija && k.Role == typeof(User))
            {
                await next();//ok - ima pravo pristupa
                return;
            }

            if (filterContext.Controller is Controller c1)
            {
                c1.TempData["error_poruka"] = "Nemate pravo pristupa";
            }
            filterContext.Result = new RedirectToActionResult("Index", "Home", new { @area = "" });
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // throw new NotImplementedException();
        }
    }
}
