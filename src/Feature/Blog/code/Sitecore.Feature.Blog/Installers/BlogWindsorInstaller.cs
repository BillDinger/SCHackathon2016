namespace Sitecore.Feature.Blog.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class BlogWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
  .InNamespace("Sitecore.Feature.Blog", true)
  .WithServiceDefaultInterfaces()
  .LifestyleTransient());
        }
    }
}