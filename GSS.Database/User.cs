using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GSS.Database
{
    public class User
    {
        public int Id { get; set; }
        [DisplayName("Organization name")]
        [Required]
        public string OrganizationName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public City City { get; set; }
        [DisplayName("City")]
        [Required]
        public int CityId { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }

        public List<Search> Searches { get; set; }
    }
}
