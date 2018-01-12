using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class Account
    {
        public int Id { get; set; }
        public double Cash { get; set; }

        [Index(IsUnique = true)]
        public int AccNumber { get; set; }
        public virtual List<Contribution> Contributions { get; set; }
    }
}
