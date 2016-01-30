namespace Sitecore.Feature.Blog.Domain.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Sitecore.Feature.Blog.CMS.Log;
    using Sitecore.Feature.Blog.Domain.Repositories;

    public class DomainWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IBlogRepository>()
                .ImplementedBy(typeof(DefaultBlogRepository))
                .LifestyleSingleton(),
                Classes.FromThisAssembly()
              .InNamespace("Sitecore.Feature.Blog.Domain", true)
              .WithServiceDefaultInterfaces()
              .LifestyleTransient());
        }
    }
}