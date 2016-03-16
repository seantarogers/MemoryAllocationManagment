using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structs
{
    using System.Diagnostics;

    class Program
    {
        //Less GCs 
        //Less memory used as structs dont have the overhead 24bytes for 64 bit processes.
        //quicker to access properties as not a dereference.

        //private static CustomerClass customerClass;
        //private static CustomerStruct customerStruct;

        static void Main(string[] args)
        {
            //Allocate a large customer object - does it need to be large?

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            //var customerClass = new CustomerClass();
            var customerClasses = new CustomerClass[1000001];
            int i = 0;
            while (i <= 1000000)
            {
                Console.WriteLine("allocating class: {0}", i);
                var customerClass = new CustomerClass { AddressLine = "12345678910", Name = "abcdef" };
                //customerClasses[i] = customerClass;
                i++;
            }

            stopwatch.Stop();
            Console.WriteLine("Local Classes: {0}", stopwatch.Elapsed);
            Console.ReadLine();
            //customerClass.DoSomething();

            stopwatch = new Stopwatch();
            stopwatch.Start();
            //var customerStruct = new CustomerStruct();
            var customerStructs = new CustomerStruct[1000001];
            i = 0;
            while (i <= 1000000)
            {
                Console.WriteLine("allocating struct: {0}", i);
                var customerStruct = new CustomerStruct { AddressLine = "12345678910", Name = "abcdef" };
                //customerStructs[i] = customerStruct;
                i++;
            }
            stopwatch.Stop();
            Console.WriteLine("Local structs: {0}", stopwatch.Elapsed);
            //customerStruct.DoSomething();
            
            Console.ReadLine();
        }


        //private static void ShowPerformanceOfRandomSizeAllocationsTotheHeap()
        //{
        //    var stopwatch = new Stopwatch();
        //    stopwatch.Start();

        //    int i = 0;
        //    int newObjectSize = 10;
        //    while (i <= 100000)
        //    {
        //        //1. allocate 1 large customers
        //        customerOne = CreateCustomer(0);

        //        customerTwo = null;
        //        if (IsOdd(i))
        //        {
        //            newObjectSize = newObjectSize - 7500000;
        //            customerTwo = CreateCustomer(newObjectSize);
        //        }
        //        else
        //        {
        //            newObjectSize = newObjectSize + 7500000;
        //            customerTwo = CreateCustomer(newObjectSize);
        //        }

        //        customerThree = CreateCustomer(0);
        //        Console.WriteLine("allocation iteration: {0}", i);
        //        i++;
        //    }

        //    stopwatch.Stop();
        //    Console.WriteLine(
        //        "time taken to allocate/deallocate 200000 to a fragmented LOH: {0}",
        //        stopwatch.Elapsed);
        //    Console.ReadLine();
        //}
    }
}
