using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSS.Database
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public PersonStatus PersonStatus { get; set; }

        public Search Search { get; set; }
        public int SearchId { get; set; }

        [Column(TypeName = "decimal(8,6)")]
        public decimal Lat { get; set; }
        [Column(TypeName = "decimal(9,6)")]
        public decimal Lng { get; set; }
    }
    public enum PersonStatus
    {
        NotFound = 0,
        FoundAlive = 1,
        FoundDead = 2
    }
}
