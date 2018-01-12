using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    
    public class Operation
    {
        public int Id { get; set; }
        public bool ToSum { get; set; }
        public double Summ { get; set; }

        public DateTime date { get; set; }
        private Operation()
        {


        }

        public Operation(double summ, Account owner)
        {
            date = DateTime.Now;
            if (summ>0)
            {
                Summ = summ;
                ToSum = true;
            }
            else
            {
                Summ = Math.Abs(summ);
            }
            Operate(owner.Id);
        }

        public void Operate(int id) {
            using (UserContext db = new UserContext())
            {

                Account owner = db.Accounts.Where(x=>x.Id==id).First();
            if (ToSum)
                {
                    owner.Cash += Summ;
                  
                }
                else {
                    if (owner.Cash - Summ < 0)
                    {
                        throw new NotEnoughMoneyException();
                      
                    }
                    else
                    {
                        owner.Cash -= Summ;
                    
                    }

                }

                db.SaveChanges();
            }
        }
    }
}
