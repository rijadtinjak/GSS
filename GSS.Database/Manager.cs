using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSS.Database
{
    public class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Search Search { get; set; }
        public int SearchId { get; set; }
    }
}
