namespace Sitecore.Feature.Blog.Controllers
{
    using System;
    using System.Web.Mvc;
    using Castle.MicroKernel;
    using Sitecore.Feature.Blog.CMS.Contexts;
    using Sitecore.Feature.Blog.CMS.Log;
    using Sitecore.Feature.Blog.Domain.Templates;
    using Sitecore.Feature.Blog.Factories;

    public class BlogController : Controller
    {
        private static IBlogFactory BlogFactory { get; set; }

        public static void Init(IBlogFactory blogFactory)
        {
            if (blogFactory == null)
            {
                throw new ArgumentNullException(nameof(blogFactory));
            }
            BlogFactory = blogFactory;
        }

        private IContext Context { get; set; }

        private IRenderingContext RenderingContext { get; set; }

        private ILogger Logger { get; set; }

        public BlogController()
        {
            Context = BlogFactory.Create<IContext>();
            RenderingContext = BlogFactory.Create<IRenderingContext>();
            Logger = BlogFactory.Create<ILogger>();

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

        public ActionResult Index()
        {
            // 1.) Retrieve our current item from our context.
            var listing = Context.GetCurrentItem<IBlogListing>();
            if (listing == null)
            {
                // TODO throw exception!
            }

            // 2.) get our rendering parameters
            var parameters = RenderingContext.GetRenderingParameters<IBlogRenderingParameters>();
            if (parameters == null)
            {
                // TODO throw exceptions.
            }

            // 3.) Create our view.

            // 4.) Return our controller.

            throw new NotImplementedException();
        }

        public ActionResult BlogDetail()
        {
            throw new NotImplementedException();
        }
    }
}