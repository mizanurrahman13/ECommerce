using DevSkill.Http.Emails.Services;
using DevSkill.Http.Utilities;
using ECommerce.Membership.BusinessObjects;

namespace ECommerce.Membership.Services
{
    public class MailSenderService : IMailSenderService
    {
        private IUrlService _urlService;
        private IQueuedEmailService _queuedEmailService;
        private const string confirmationEmailSubject = "Confirmation Email";

        public MailSenderService(IUrlService urlService, IQueuedEmailService queuedEmailService)
        {
            _urlService = urlService;
            _queuedEmailService = queuedEmailService;
        }

        public void Dispose()
        {

        }

        public async Task SendEmailConfirmationEmailAsync(ApplicationUser user, string verificationCode)
        {
            if (user is null ||
                string.IsNullOrWhiteSpace(verificationCode))
            {
                throw new InvalidOperationException("User with valid email and verification code must be provided");
            }

            var verificationLink = _urlService.GenerateAbsoluteUrl("Account", "ConfirmEmail",
                new { userName = user.UserName, code = verificationCode, area = "" });

            //var accountConfirmationEmail = new AccountConfirmationMailTemplate(verificationLink);
            //var emailBody = accountConfirmationEmail.TransformText();

            await _queuedEmailService.SendSingleEmailAsync(user.UserName, user.Email, confirmationEmailSubject, "");
        }
    }
}
