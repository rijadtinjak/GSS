using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GSS.Model
{
    public class User
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public string Email { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }
        public string UserRole { get => "User"; }
    }
}
