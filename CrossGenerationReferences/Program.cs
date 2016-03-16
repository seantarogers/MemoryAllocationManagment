namespace CrossGenerationReferences
{
    using System;

    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Create an order and it gets put into GEN 0");
            Console.ReadLine();
            var order = new Order { Id = Guid.NewGuid(), Name = "orderName" };

            Console.WriteLine("Take snapshot and trigger a GC and it will put the order into GEN 1");
            Console.WriteLine(
                "Create a customer and add the order to the customer. Now the customer is in GEN0 and the order in GEN 1");
            Console.ReadLine();

            var customer = new Customer();
            customer.AddOrder(order);

            Console.WriteLine("Post GC, Customer should now be in GEN 1 and order in GEN 2");
            Console.ReadLine();

            customer.UpdateName("sean");

            Console.WriteLine(
                "Take another snap shot and they both should be collected, but GC has had to do a partial traverse of GEN 2");
            Console.ReadLine();
        }
    }
}
