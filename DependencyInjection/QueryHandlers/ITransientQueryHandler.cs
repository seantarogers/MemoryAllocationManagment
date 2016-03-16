namespace DependencyInjection.QueryHandlers
{
    using Dtos;

    public interface ITransientQueryHandler
    {
        CustomerDto Handle();
    }
}