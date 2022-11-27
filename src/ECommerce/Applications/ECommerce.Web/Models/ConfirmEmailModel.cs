using Autofac;

namespace ECommerce.Web.Models
{
    public class ConfirmEmailModel : BaseModel
    {
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public string StatusMessage { get; set; }
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        public bool IsSuccess { get; set; }

        private ILifetimeScope _lifetimeScope;

        public ConfirmEmailModel()
        {
        }

        public override void Resolve(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;

            base.Resolve(_lifetimeScope);
        }
    }
}
