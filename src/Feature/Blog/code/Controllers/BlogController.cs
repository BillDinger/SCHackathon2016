namespace Sitecore.Feature.Blog.Controllers
{
    using System;
    using System.Web.Mvc;
    using Castle.MicroKernel;
    using Sitecore.Feature.Blog.CMS.Contexts;
    using Sitecore.Feature.Blog.CMS.Log;
    using Sitecore.Feature.Blog.Domain.Templates;

    public class BlogController : Controller
    {
        private static IKernel _kernel;

        public static void Init(IKernel kernel)
        {
            _kernel = kernel;
        }

        private IContext Context { get; set; }

        private IRenderingContext RenderingContext { get; set; }

        private ILogger Logger { get; set; }

        public BlogController()
        {
            Context = _kernel.Resolve<IContext>();
            RenderingContext = _kernel.Resolve<IRenderingContext>();
            Logger = _kernel.Resolve<ILogger>();

        }

        //public BlogController(IContext context, IRenderingContext renderingContex, ILogger logger) 
        //{
        //    if (context == null)
        //    {
        //        throw new ArgumentNullException("context");
        //    }
        //    if (renderingContex == null)
        //    {
        //        throw new ArgumentNullException("renderingContex");
        //    }
        //    if (logger == null)
        //    {
        //        throw new ArgumentNullException("logger");
        //    }
        //    _logger = logger;
        //    _context = context;
        //    _renderingContext = renderingContex;
        //}

        public ActionResult BlogListing()
        {
            // 1.) Retrieve our current item from our context.
            var detailSource = RenderingContext.DataSource;
            var listing = Context.GetItem<IBlogListing>(detailSource);

            if (!String.IsNullOrEmpty(listing))
            {
                var blogDetail = Context.GetItem<IBlogListing>(detailSource);
                // 2.) get our rendering parameters
                var parameters = RenderingContext.GetRenderingParameters<IBlogRenderingParameters>();
                if (parameters == null)
                {
                    // TODO throw exceptions.
                }
                return View(blogDetail);
            }
            else
            {
                return Content("No datasource set");
            }
        }

        public ActionResult BlogDetail()
        {
            var detailSource = RenderingContext.DataSource;
            if (!String.IsNullOrEmpty(detailSource))
            {
                var blogDetail = Context.GetItem<IBlogDetail>(detailSource);
                return View(blogDetail);
            }
            else
            {
                return Content("No datasource set");
            }
        }
    }
}