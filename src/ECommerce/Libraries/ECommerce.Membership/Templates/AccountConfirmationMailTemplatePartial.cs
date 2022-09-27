namespace ECommerce.Membership.Templates
{
    public partial class AccountConfirmationMailTemplate
    {
        private string VerificationLink { get; set; }
        public AccountConfirmationMailTemplate(string verificationLink)
        {
            VerificationLink = verificationLink;
        }
    }
}
