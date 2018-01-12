using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CodeFirst
{
    public class NotEnoughMoneyException : ApplicationException
    {
        public NotEnoughMoneyException() { }

        public NotEnoughMoneyException(string message) : base(message) { }

        public NotEnoughMoneyException(string message, Exception inner) : base(message, inner) { }

        protected NotEnoughMoneyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
    public static class Methods
    {
        public static User FindUser(string id) {

            UserContext db = new UserContext();

                return db.Users.Where(x=>x.Name==id).First();
         
        }
        public static void AddUser(User user) {
            using (UserContext db = new UserContext())
            {
                db.Users.Add(user);
                db.SaveChanges();

            }
        }
        public static void AddAccount(User user, Account account)
        {
            
            using (UserContext db = new UserContext())
            {
                
                User us = db.Users.Where(x => x.Id == user.Id).FirstOrDefault();
                us.Accounts.Add(account);

                db.SaveChanges();

            }
        }

        public static void AddContribution(Account account, Contribution contribution)
        {
        
            using (UserContext db = new UserContext())
            {
                Account acc = db.Accounts.Where(x => x.Id == account.Id).FirstOrDefault();
                acc.Contributions.Add(contribution);            
                db.SaveChanges();

            }
        }

        public static void AddOperation(Contribution contribution, Account account, double summ)
        {
      
            using (UserContext db = new UserContext())
            {
                Contribution contr = db.Contributions.Where(x => x.Id == contribution.Id).First();
                contr.Operations.Add(new Operation(summ, account));
                db.SaveChanges();

            }
        }

        public static void RemoveUser(string id) {
            using (UserContext db = new UserContext())
            {
             
                User remove = db.Users.Where(x=>x.Name==id).First();

                db.Users.Remove(remove);
                db.SaveChanges();

            }
        }

        public static void RemoveAccount(int id)
        {
            using (UserContext db = new UserContext())
            {
                Account todelete = db.Accounts.Where(x => x.AccNumber == id).First() ;

                db.Accounts.Remove(todelete);
                db.SaveChanges();

            }
        }

        public static List<Contribution> GetAccContributions(int accnumber)
        {

            using (UserContext db = new UserContext())
            {
                Account owner = db.Accounts.Where(x=>x.AccNumber==accnumber).First();

                return owner.Contributions.ToList();

            }
        }

        public static List<User> GetAllUsers()
        {
            using (UserContext db = new UserContext())
            {
               return  db.Users.ToList();

            }
        }

        public static List<Account> GetAllAccounts()
        {
            using (UserContext db = new UserContext())
            {
                return db.Accounts.ToList();

            }
        }

        public static List<Account> GetUserAccounts(string userid)
        {
            using (UserContext db = new UserContext())
            {
                User owner = FindUser(userid);

                return owner.Accounts.ToList();
                
            }
        }

        public static List<Contribution> GetAllContributions()
        {
            using (UserContext db = new UserContext())
            {
                return db.Contributions.ToList();

            }
        }

        public static List<Operation> GetAllOperations()
        {
            using (UserContext db = new UserContext())
            {
                return db.Operations.ToList();

            }
        }

        public static Account FindAccOwner(int accnumber)
        {
            UserContext db = new UserContext();
            return db.Accounts.Where(x => x.AccNumber == accnumber).First();
        }

        public static void RemoveContribution(int accnumber, string contribution)
        {
            using (UserContext db = new UserContext())
            {
                Account owner = db.Accounts.Where(x => x.AccNumber == accnumber).First();
                Contribution todelete = owner.Contributions.Where(x => x.Name == contribution).First();

                db.Contributions.Remove(todelete);
                db.SaveChanges();

            }
        }

        public static void TransferMoney(int fromacc, int toacc, double summ)
        {
            using (UserContext db = new UserContext())
            {
                Account from = db.Accounts.Where(x => x.AccNumber == fromacc).First();
                Account to = db.Accounts.Where(x => x.AccNumber == toacc).First();
                Contribution fromcontr, tocontr;
                if (from.Contributions.Find(x=>x.Name=="Transfer")==null)
                {
                    fromcontr = new Contribution { Name = "Transfer" };
                    
                }
                else
                {
                    fromcontr = from.Contributions.Where(x => x.Name == "Transfer").First();
                   
                }
                if (to.Contributions.Find(x => x.Name == "Transfer") == null)
                {
                    tocontr = new Contribution { Name = "Transfer" };

                }
                else
                {
                    tocontr = to.Contributions.Where(x => x.Name == "Transfer").First();

                }
                                
                from.Contributions.Add(fromcontr);
                to.Contributions.Add(tocontr);
                db.SaveChanges();
                


               
                
                try
                {
                    AddOperation(fromcontr, from, -summ);
                    AddOperation(tocontr, to, summ);
                }
                catch (NotEnoughMoneyException)
                {

                    throw new NotEnoughMoneyException();
                }
               


            }

                
        }
    }
}
