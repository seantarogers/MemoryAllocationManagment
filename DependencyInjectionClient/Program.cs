namespace DependencyInjectionClient
{
    using System;
    using System.Net.Http;

    using Dtos;

    using Newtonsoft.Json;

    static class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();

            int i = 0;
            while (i < 5000000)
            {
                var response = httpClient.GetAsync("http://localhost:8094/api/transient")
                    .Result;

                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync()
                        .Result;

                    var customerDto = JsonConvert.DeserializeObject<CustomerDto>(json);
                }
                Console.WriteLine("received customer: {0}", i);
                i++;
            }
        }
    }
}
