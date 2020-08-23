using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSS.Web.Viewmodels
{
    public class LoggedInUser
    {
        public int Id { get; set; }
        public Type Role { get; set; }
        public string Name { get; set; }
    }
}
