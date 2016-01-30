namespace Sitecore.Feature.Blog.CMS.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Log;

    public class CmsWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ILogger>()
                .ImplementedBy(typeof(DefaultLogger))
                .LifestyleSingleton(),
                Classes.FromThisAssembly()
                  .InNamespace("Sitecore.Feature.Blog.CMS", true)
                  .WithServiceDefaultInterfaces()
                  .LifestyleTransient());
        }
    }
}