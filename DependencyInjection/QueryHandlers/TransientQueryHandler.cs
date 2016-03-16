namespace DependencyInjection.QueryHandlers
{
    using DependencyInjection.Services;

    using Dtos;

    public class TransientQueryHandler : ITransientQueryHandler
    {
        private readonly ITransientService transientService;

        public TransientQueryHandler(ITransientService transientService)
        {
            this.transientService = transientService;
        }

        public CustomerDto Handle()
        {
            var customerDto = transientService.GetCustomer();
            return customerDto;
        }
    }
}