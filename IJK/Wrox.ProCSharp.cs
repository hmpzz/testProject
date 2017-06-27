using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrox.ProCSharp
{
    public interface IBankAccount
    {
        void PayIn(decimal amount);
        bool Withdraw(decimal amount);
        decimal Balance { get; }
    }
}

namespace Wrox.ProCSharp.VenusBank
{

    public class SaverAccount : IBankAccount
    {
        private decimal balance;
        public void PayIn(decimal amount)
        {
            balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if (balance>=amount)
            {
                balance -= amount;
                return true;
            }
            Console.WriteLine("Withdrawal attemp failed");
            return false;
        }


		public decimal Balance
        {
            get
            {
                return balance;
            }
        }

        public override string ToString()
        {
            return String.Format("Venus Bank Saver:balance={0,6:C}", balance);
        }

    }
}


namespace Wrox.ProCSharp.JupiterBank
{
    public class GoldAccount : IBankAccount
    {
      
            private decimal balance;
            public void PayIn(decimal amount)
            {
                balance += amount;
            }

            public bool Withdraw(decimal amount)
            {
                if (balance >= amount)
                {
                    balance -= amount;
                    return true;
                }
                Console.WriteLine("余额不足");
                return false;
            }


            public decimal Balance
            {
                get
                {
                    return balance;
                }
            }

            public override string ToString()
            {
                return String.Format("余额={0,6:C}", balance);
            }
        }
}