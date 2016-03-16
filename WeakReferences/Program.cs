using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeakReferences
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Create a customer an add it to GEN 0, also add a weak reference to it");
            Console.ReadLine();



            var cachedCustomer = new Customer();
            var weakReference = new WeakReference(cachedCustomer);
            
            //do lots of work

            if (weakReference.IsAlive)
            {
                cachedCustomer = (Customer)weakReference.Target;                
            }
            else
            {
                cachedCustomer = new Customer();
            }



            cachedCustomer.Name;
            Console.ReadLine();
        }
    }
}
