using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{

    public delegate void GreetingDelegate(string name);


    public class DelegateClass
    {

        public event GreetingDelegate MakeGreeting;
        public void GreetPeople(string name)
        {
            if (MakeGreeting!=null)
            {
                MakeGreeting(name);
            }
            
        }


    }
}
