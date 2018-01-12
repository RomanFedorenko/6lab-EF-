using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class UserContext : DbContext
    {
        public UserContext()
            : base("DBConnection")
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contribution> Contributions { get; set; }
        public DbSet<Operation> Operations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(x => x.Accounts).WithOptional().WillCascadeOnDelete(true);
            modelBuilder.Entity<Account>().HasMany(x => x.Contributions).WithOptional().WillCascadeOnDelete(true);
            modelBuilder.Entity<Contribution>().HasMany(x => x.Operations).WithOptional().WillCascadeOnDelete(true);

        }

    }
}
