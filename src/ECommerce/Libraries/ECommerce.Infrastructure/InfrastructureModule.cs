using Autofac;
using ECommerce.Infrastructure.DbContexts;
using ECommerce.Infrastructure.Entities;
using ECommerce.Infrastructure.Repositories;
using ECommerce.Infrastructure.Services;
using ECommerce.Infrastructure.UnitOfWorks;
using Microsoft.AspNetCore.Hosting;

namespace ECommerce.Infrastructure
{
    public class InfrastructureModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public InfrastructureModule(string connectionString,
                                    string migrationAssemblyName,
                                    IWebHostEnvironment webHostEnvironment)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
            _webHostEnvironment = webHostEnvironment;
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

            builder.RegisterType<ECommerceUnitOfWork>().As<IECommerceUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<CategoryService>().As<ICategoryService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CurrentUserService>().As<ICurrentUserService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}