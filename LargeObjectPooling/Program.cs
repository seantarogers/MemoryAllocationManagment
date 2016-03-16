namespace LargeObjectPooling
{
    using System;
    using System.Diagnostics;

    //1. run allocate each time and see the number of collections in the LOH
    //2. run single allocation and updates and see low collection in LOH
    //3. collect in pefview to see number of collections
    

    public static class Program
    {
        private const int PdfSize = 1000000;
        private const string Name = "sean";
        private const string Mobile = "07765067136";
        private static Customer customer;
        
        private static void Main(string[] args)
        {
            AllocateEachTimeToTheLargeObjectHeap();
            //AllocateOnceAndUpdateTheReference();
        }

        private static void AllocateOnceAndUpdateTheReference()
        {
            var i = 0;
            customer = CreateCustomer(i, PdfSize, Name, Mobile);

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            while (i <= 200000)
            {
                customer.UpdateName(Name);
                customer.UpdateName(Mobile);
                Console.WriteLine("updating customer on the LOH {0} ", i);
                i++;
            }

            stopwatch.Stop();
            
            Console.WriteLine("one allocation on the LOH allocations and 500000 updates took : {0}", stopwatch.Elapsed.Seconds);
            Console.ReadLine();
        }

        private static void AllocateEachTimeToTheLargeObjectHeap()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var i = 0;
            while (i <= 200000)
            {
                customer = CreateCustomer(i, PdfSize, Name, Mobile);
                Console.WriteLine("allocating {0} to LOH", i);
                i++;
            }

            stopwatch.Stop();

            Console.WriteLine("500000 LOH allocations and collections took : {0}", stopwatch.Elapsed);
            Console.ReadLine();
        }

        private static Customer CreateCustomer(int i, int increment, string name, string mobile)
        {
            return new Customer(100000 + increment, name, mobile);
        }
    }
}
