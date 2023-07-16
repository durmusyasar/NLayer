using Autofac;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository;
using NLayer.Repository.Repositories;
using NLayer.Repository.UnitOfWorks;
using NLayer.Service.Mapping;
using NLayer.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace NLayer.API.Modules
{
    /// <summary>
    /// Built-in Container'dan daha yeteneklidir. Autofac'in farkı constructor ve method injection'ın yanında property injection'da sağlar.
    /// Autofac Dinamik olarak nesne ekleme özelliği katar.
    /// </summary>
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(ServiceWithDto<,>)).As(typeof(IServiceWithDto<,>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<ProductServiceWithDto>().As<IProductServiceWithDto>().InstancePerLifetimeScope();

            var apiAssemply = Assembly.GetExecutingAssembly();
            var repoAssemply = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssemply = Assembly.GetAssembly(typeof(MapProfile));

            builder
                .RegisterAssemblyTypes(apiAssemply, repoAssemply, serviceAssemply)
                .Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder
                .RegisterAssemblyTypes(apiAssemply, repoAssemply, serviceAssemply)
                .Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
