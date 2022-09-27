using Autofac;

namespace ECommerce.Web.Models
{
    public class ConfirmEmailModel : BaseModel
    {
        public string StatusMessage { get; set; }
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
