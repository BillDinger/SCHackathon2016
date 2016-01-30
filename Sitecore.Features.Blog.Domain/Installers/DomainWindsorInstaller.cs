

namespace Sitecore.Features.Blog.Domain.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class DomainWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
              .InNamespace("Sitecore.Features.Blog.Domain", true)
              .WithServiceDefaultInterfaces()
              .LifestyleTransient());
        }
    }
}
