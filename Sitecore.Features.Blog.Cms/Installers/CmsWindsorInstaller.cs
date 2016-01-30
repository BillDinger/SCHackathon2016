

namespace Sitecore.Features.Blog.Cms.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class CmsWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
              .InNamespace("Sitecore.Features.Blog.Cms", true)
              .WithServiceDefaultInterfaces()
              .LifestyleTransient());
        }
    }
}
