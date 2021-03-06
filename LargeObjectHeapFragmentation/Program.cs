﻿namespace LargeObjectHeapFragmentation
{
    using System;
    using System.Diagnostics;
    using System.Runtime;

    public static class Program
    {
        static Customer customerOne;
        static Customer customerTwo;
        static Customer customerThree;
        
        //Lesson - it is cheaper to allocate more memory, than find a slot in a fragmented heap

        //notes
        //1. fragmentation doesnt happen the first time around, they all slot in after each other
        //2. when GC has happened and picked up some of them, then it leaves holes

        //steps
        //1. allocate 5 large objects
        //2. 3 will be picked up when you grab a snapshot, leaving 3 holes
        //3. allocte 2 more of the same size and they should fit in.
        //4. if you over allocate you will force a redrawing of boundaries which is slow, you see this in the generation loh max.

        private static void Main(string[] args)
        {
            ShowFragmentationAndReuseOfSegmentsWithSmallerObjects();
            ShowFragmentationAndTheUseOfStandardBufferSizes();
            ShowProgramaticCompactionOfHeap();
            ShowPerformanceOfRandomSizeAllocationsTotheHeap();
            ShowPerformanceOfManagedSizeAllocationsTotheHeap();
        }

        private static void ShowPerformanceOfRandomSizeAllocationsTotheHeap()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            int i = 0;
            int newObjectSize = 10;
            while (i <= 100000)
            {
                //1. allocate 1 large customers so that the object does not fit
                customerOne = CreateCustomer(0);

                //keep shifting the size
                customerTwo = null;
                if (IsOdd(i))
                {
                    newObjectSize = newObjectSize - 7500000;
                    customerTwo = CreateCustomer(newObjectSize);
                }
                else
                {
                    newObjectSize = newObjectSize + 7500000;
                    customerTwo = CreateCustomer(newObjectSize);
                }

                customerThree = CreateCustomer(0);
                Console.WriteLine("allocation iteration: {0}", i);
                i++;
            }

            stopwatch.Stop();
            Console.WriteLine(
                "time taken to allocate/deallocate 200000 to a fragmented LOH: {0}",
                stopwatch.Elapsed);
            Console.ReadLine();
        }


        private static void ShowPerformanceOfManagedSizeAllocationsTotheHeap()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var i = 0;
            while (i <= 100000)
            {
                //1. allocate 1 large customers
                customerOne = CreateCustomer(0);

                if (PDFIsBiggerThanStandard())
                {
                    customerTwo = CreateCustomer(1000000);
                }

                customerThree = CreateCustomer(0);

                Console.WriteLine("allocation iteration: {0}", i);                
                i++;
            }

            stopwatch.Stop();
            Console.WriteLine(
                "time taken to allocate/deallocate 200000 to a fragmented LOH: {0}",
                stopwatch.Elapsed);
            Console.ReadLine();
        }

        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

        private static void ShowFragmentationAndTheUseOfStandardBufferSizes()
        {
            Console.WriteLine("take a snapshot, then press any key to allocate first set of objects");
            Console.ReadLine();
            
            //1. allocate 1 large customers
            customerOne = CreateCustomer(0);

            Console.WriteLine("Take a snapshot and verify no fragmentation in the LOH");
            Console.ReadLine();

            if (PDFIsBiggerThanStandard())
            {
                // allocate a second customer which has a larger PDF by 50%, but double that allocation to be 2mb
                customerThree = CreateCustomer(1000000);
            }

            customerTwo = CreateCustomer(0);

            Console.WriteLine(
                "Take a snapshot and verify no fragmentation but the heap has increased in size and has 3 object on it");
            Console.ReadLine();

            //allocate a second pdf with the same large buffer size
            customerThree = null;
            
            Console.WriteLine("Take a snapshot and verify there is fragmentation in the middle");
            Console.ReadLine();

            if (PDFIsBiggerThanStandard())
            {
                // allocate a second customer which has a larger PDF by 50%, but double that allocation to be 2mb
                customerThree = CreateCustomer(1000000);
            }

            Console.WriteLine("Take a snapshot and verify there is no fragmentation");
            Console.ReadLine();
        }

        private static bool PDFIsBiggerThanStandard()
        {
            return true;
        }


        private static void ShowProgramaticCompactionOfHeap()
        {
            Console.WriteLine("take a snapshot, then press any key to allocate first set of objects");
            Console.ReadLine();

            customerOne = CreateCustomer(0);
            customerTwo = CreateCustomer(0);

            Console.WriteLine("Take a snapshot and verify no fragmentation in the LOH");
            Console.ReadLine();

            //reallocate - so create 1 new slots and leave 1 empty
            customerOne = CreateCustomer(0);

            Console.WriteLine("Take a snapshot and verify there is now fragmentation LOH");
            Console.WriteLine("The click, to programatically compact heap and then take a further snapshot");
            Console.ReadLine();

            GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;

            Console.WriteLine("Compaction done");
            Console.ReadLine();
        }

        private static void ShowFragmentationAndReuseOfSegmentsWithSmallerObjects()
        {
            Console.WriteLine("take a snapshot, then press any key to allocate first set of objects");
            Console.ReadLine();

            customerOne = CreateCustomer(0);
            customerTwo = CreateCustomer(0);

            Console.WriteLine("Take a snapshot and verify no fragmentation in the LOH");
            Console.ReadLine();

            //reallocate - so create 1 new slots and leave 1 empty
            customerOne = CreateCustomer(0);

            Console.WriteLine("Take a snapshot and verify there is now fragmentation LOH");
            Console.ReadLine();

            customerOne = CreateSmallerCustomer();

            Console.WriteLine("Take a snapshot and verify the fragmentation has been filled in");
            Console.ReadLine();
        }

        private static Customer CreateCustomer(int increment)
        {
            return new Customer(1000000 + increment);
        }

        private static Customer CreateSmallerCustomer()
        {
            return new Customer(9000000);
        }
    }
}
