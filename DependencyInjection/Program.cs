namespace DependencyInjection
{
    using System;

    using DependencyInjection.QueryHandlers;
    using DependencyInjection.Services;

    using SimpleInjector;
    using SimpleInjector.Extensions.LifetimeScoping;

    static class Program
    {
        private static void Main(string[] args)
        {
            var container = new Container();

            container.Register<ITransientService, TransientService>(new LifetimeScopeLifestyle());
            container.Register<ITransientQueryHandler, TransientQueryHandler>(new LifetimeScopeLifestyle());

            Console.WriteLine("begin resolving from the container");
            Console.ReadLine();
            while (true)
            {
                using (container.BeginLifetimeScope())
                {
                    var queryHandler = container.GetInstance<ITransientQueryHandler>();
                    var dto = queryHandler.Handle();
                }
            }



            //const string HttpLocalhost = "http://localhost:8094";
            //using (WebApp.Start(HttpLocalhost))
            //{
            //    Console.WriteLine("Web api started on 8094");
            //    Console.ReadLine();
            //}
        }
    }
}
