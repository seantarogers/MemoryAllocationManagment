namespace DependencyInjection.Services
{
    using Dtos;

    public class TransientService : ITransientService
    {
        public CustomerDto GetCustomer()
        {
            var customerDto = new CustomerDto
            {
                Name = "sean",
                AddressLine1 = "asddddddddddddddddddassssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss",
                AddressLine2 = "asddddddddddddddddddassssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss",
                AddressLine3 = "asddddddddddddddddddassssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss",
                AddressLine4 = "asddddddddddddddddddassssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss",
                AddressLine5 = "asddddddddddddddddddassssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss",
                PostCode = "asddddddddddddddddddassssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss",
            };
            return customerDto;
        }
    }
}