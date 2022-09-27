using Autofac;
using DevSkill.Http.Emails.Services;
using ECommerce.Infrastructure.DbContexts;
using ECommerce.Membership.BusinessObjects;
using ECommerce.Membership.Services;

namespace ECommerce.Membership
{
    public class MembershipModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public MembershipModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<UserManager>().AsSelf();

            builder.RegisterType<UrlService>().As<IUrlService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<HtmlEmailService>().As<IQueuedEmailService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SignInManagerAdapter>().As<ISignInManagerAdapter<ApplicationUser>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserManagerAdapter>().As<IUserManagerAdapter<ApplicationUser>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<MailSenderService>().As<IMailSenderService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}