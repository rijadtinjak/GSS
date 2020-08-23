﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSS.Database
{
    public class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        [DisplayName("Organization")]
        public int UserId { get; set; }
        public bool Active { get; set; }
    }
}
