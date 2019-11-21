using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSS.Database
{
    public class User
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }

        public List<Search> Searches { get; set; }
    }
}
