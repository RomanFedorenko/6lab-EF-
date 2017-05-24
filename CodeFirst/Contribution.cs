﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class Contribution
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Operation> Operations { get; set; }

    }
}
