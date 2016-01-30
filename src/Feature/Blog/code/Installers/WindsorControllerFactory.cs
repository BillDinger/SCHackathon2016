namespace Sitecore.Feature.Blog.Installers
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Castle.MicroKernel;
    using Sitecore.Feature.Blog.CMS.Log;

    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private IKernel Kernel { get; }
        private ILogger Logger { get; }

        public WindsorControllerFactory(IKernel kernel, ILogger logger)
        {
            if (kernel == null)
            {
                throw new ArgumentNullException(nameof(kernel));
            }
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            Kernel = kernel;
            Logger = logger;
        }


        public override void ReleaseController(IController controller)
        {
            Kernel.ReleaseComponent(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404,
                    $"The controller for path '{requestContext.HttpContext.Request.Path}' could not be found.");
            }
            try
            {
                return (IController)Kernel.Resolve(controllerType);
            }
            catch (Exception ex)
            {
                Logger.Debug($"Unable to resolve controllerType: {controllerType}\r\n{ex}", this);
                return base.GetControllerInstance(requestContext, controllerType);
            }
        }
    }
}