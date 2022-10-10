namespace ECommerce.Infrastructure.Services
{
    public interface ICurrentUserService
    {
        Task<string> GetUsername();
    }
}
