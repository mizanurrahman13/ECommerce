using Autofac;
using ECommerce.Web.Areas.Admin.Models;
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
            builder.RegisterType<LoginModel>()
                .AsSelf()
                .InstancePerLifetimeScope();
            builder.RegisterType<ConfirmEmailModel>()
                .AsSelf()
                .InstancePerLifetimeScope();
            builder.RegisterType<ResponseModel>()
                .AsSelf()
                .InstancePerLifetimeScope();
            builder.RegisterType<DashboardModel>()
                .AsSelf()
                .InstancePerLifetimeScope();
            builder.RegisterType<AdminLayoutModel>()
                .AsSelf()
                .InstancePerLifetimeScope();
            builder.RegisterType<CategoryListModel>()
                .AsSelf()
                .InstancePerLifetimeScope();


            base.Load(builder);
        }
    }
}
