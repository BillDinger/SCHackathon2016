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
        private readonly IKernel _kernel;
        private IKernel Kernel { get { return _kernel; } }
        private readonly ILogger _logger;
        private ILogger Logger { get { return _logger; } }

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

            _kernel = kernel;
            _logger = logger;
        }


        public override void ReleaseController(IController controller)
        {
            _kernel.ReleaseComponent(controller);
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
                return (IController)_kernel.Resolve(controllerType);
            }
            catch (Exception ex)
            {
                Logger.Debug($"Unable to resolve controllerType: {controllerType}\r\n{ex}", this);
                return base.GetControllerInstance(requestContext, controllerType);
            }
        }
    }
}