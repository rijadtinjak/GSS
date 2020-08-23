using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSS.Web.Helper
{
    public static class Authentication
    {
        private const string LogiraniKorisnik = "logirani_korisnik";

        public static void SetLogiraniKorisnik<T>(this HttpContext context, T korisnik)
        {
            context.Session.Set(LogiraniKorisnik, korisnik);
        }

        public static T GetLogiraniKorisnik<T>(this HttpContext context)
        {
            return context.Session.Get<T>(LogiraniKorisnik);
        }

    }
}
