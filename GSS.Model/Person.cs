using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSS.Model
{
    [Serializable]
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public PersonStatus PersonStatus { get; set; }
    }
    public enum PersonStatus
    {
        NotFound = 0,
        FoundAlive = 1,
        FoundDead = 2
    }
}
