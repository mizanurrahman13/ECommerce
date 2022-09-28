using ECommerce.Membership.BusinessObjects;

namespace ECommerce.Membership.Services
{
    public interface IMailSenderService
    {
        Task SendEmailConfirmationEmailAsync(ApplicationUser user, string verificationCode);
    }
}
