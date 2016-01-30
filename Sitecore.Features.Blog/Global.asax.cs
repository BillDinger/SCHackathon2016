using System;

namespace Sitecore.Features.Blog
{
    using Castle.Windsor;

    public class Global : System.Web.HttpApplication
    {
        private static IWindsorContainer Container { get; set; }

        protected void Application_Start(object sender, EventArgs e)
        {
            // 1.) Setup Castle Windsor.
            Container = BootstrapContainer();
        }

        private IWindsorContainer BootstrapContainer()
        {
            // 1.) Create our base Windsor container for the entire application.
            var container = new WindsorContainer();

            // 2.) call our individual containers.
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}