using Autofac;
using ECommerce.Web.Models;

namespace ECommerce.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterModel>()
                .AsSelf()
                .InstancePerLifetimeScope();
            builder.RegisterType<ConfirmEmailModel>()
                .AsSelf()
                .InstancePerLifetimeScope();
            builder.RegisterType<ResponseModel>()
                .AsSelf()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
