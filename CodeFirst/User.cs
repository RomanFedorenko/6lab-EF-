using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Account> Accounts { get; set; }

        public User()
        {
            Accounts = new List<Account>();
        }
    }
}
