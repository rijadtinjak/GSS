using System;
using System.Collections.Generic;
using System.Text;

namespace GSS.Database
{
    public class Search
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateClosed { get; set; }

        public List<Zone> Zones { get; set; }
        public List<Manager> Managers { get; set; }
    }
}
