using System;

namespace Sitecore.Feature.Blog
{
    using System.Web;
    using System.Web.Mvc;
    using Castle.Windsor;
    using Sitecore.Feature.Blog.CMS.Installers;
    using Sitecore.Feature.Blog.CMS.Log;
    using Sitecore.Feature.Blog.Controllers;
    using Sitecore.Feature.Blog.Domain.Installers;
    using Sitecore.Feature.Blog.Installers;

    public class MvcApplication : HttpApplication
    {
        private static IWindsorContainer Container { get; set; }

        protected void Application_Start(object sender, EventArgs e)
        {

            // 1.) Setup Castle Windsor.
            Container = BootstrapContainer();
        }

        protected IWindsorContainer BootstrapContainer()
        {
            // 1.) Create our base Windsor container for the entire application.
            var container = new WindsorContainer();

            // 2.) Add our Windsor installers to the container.
            container.Install(new BlogWindsorInstaller(),
                new DomainWindsorInstaller(),
                new CmsWindsorInstaller());

            var logger = container.Resolve<ILogger>();
            logger.Info("starting", this);

            // 3.) Setup MVC to use Windsor's controller factory.
            //   var controllerFactory = new WindsorControllerFactory(container.Kernel, container.Resolve<ILogger>());
            // ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            BlogController.Init(container.Kernel);
            // 4.) Return our fresh container.
            return container;
        }


        protected void Application_End(object sender, EventArgs e)
        {
            if (Container != null)
            {
                Container.Dispose();
            }
        }
    }
}