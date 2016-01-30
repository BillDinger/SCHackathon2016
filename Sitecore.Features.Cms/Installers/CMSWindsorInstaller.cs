namespace Sitecore.Features.Cms.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.Resolvers.SpecializedResolvers;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class CmsWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .InNamespace("Sitecore.Features.Cms", true)
                .WithServiceDefaultInterfaces()
                .LifestyleTransient());

            container.Kernel.Resolver.AddSubResolver(new ListResolver(container.Kernel));
        }
    }
}