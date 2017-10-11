using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using HelloIoC.DAL.Facade;
using HelloIoC.DAL.Query;
using HelloIoC.DAL.Repository;

namespace HelloIoC.DAL._Installer
{
    public class DALInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly().BasedOn(typeof(IQuery<>))
                                          .OrBasedOn(typeof(IFirstLevelQuery<>))
                                          .OrBasedOn(typeof(IFilterQuery<,>))
                                          .WithServiceSelf()
                                          .LifestyleTransient(),

                Classes.FromThisAssembly().BasedOn(typeof(IRepository<>))
                                          .LifestyleSingleton()
                                          .WithServiceAllInterfaces(),

                Component.For<Mapper>().LifestyleSingleton()
                );

            container.AddFacility<TypedFactoryFacility>();
        }
    }

    public class BLInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ContactListFacade>().LifestyleTransient(),
                Component.For<ContactListApp>().LifestyleTransient()

                );
        }
    }
}