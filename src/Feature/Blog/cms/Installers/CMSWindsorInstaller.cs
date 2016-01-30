namespace Sitecore.Feature.Blog.CMS.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Log;
    using Contexts;
    using Sitecore.Feature.Blog.CMS.Analytics;

    public class CmsWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ISitecoreConfiguration>()
                .ImplementedBy(typeof(DefaultSitecoreConfiguration))
                .LifestyleSingleton(),
                Component.For<ILogger>()
                .ImplementedBy(typeof(DefaultLogger))
                .LifestyleSingleton(),
                Component.For<IContext>()
                .ImplementedBy(typeof(DefaultContext))
                .LifestyleSingleton(),
                Component.For<IRenderingContext>()
                .ImplementedBy(typeof(DefaultRenderingContext))
                .LifestyleSingleton(),
               Component.For<IAnalyticsService>()
                .ImplementedBy(typeof(DefaultAnalyticsService))
                .LifestyleSingleton(),
                Classes.FromThisAssembly()
                  .InNamespace("Sitecore.Feature.Blog.CMS", true)
                  .WithServiceDefaultInterfaces()
                  .LifestyleTransient());
        }
    }
}