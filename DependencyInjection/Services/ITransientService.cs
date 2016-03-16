namespace DependencyInjection.Services
{
    using Dtos;

    public interface ITransientService
    {
        CustomerDto GetCustomer();
    }
}