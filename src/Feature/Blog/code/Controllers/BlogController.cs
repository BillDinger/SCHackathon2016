namespace Sitecore.Feature.Blog.Controllers
{
    using System;
    using System.Web.Mvc;
    using Sitecore.Feature.Blog.CMS.Contexts;
    using Sitecore.Feature.Blog.CMS.Log;
    using Sitecore.Feature.Blog.Controllers.Exceptions;
    using Sitecore.Feature.Blog.Domain.Templates;
    using Sitecore.Feature.Blog.Factories;
    using Sitecore.Feature.Blog.Factories.Exceptions;

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
            if (BlogFactory == null)
            {
                throw new ContainerNotFoundException("No di container was found, unable to start the controller!");
            }
            Context = BlogFactory.Create<IContext>();
            RenderingContext = BlogFactory.Create<IRenderingContext>();
            Logger = BlogFactory.Create<ILogger>();
        }


        public ActionResult Index()
        {
            // 1.) Retrieve our current item from our context.
            var listing = Context.GetCurrentItem<IBlogListing>();
            if (listing == null)
            {
                throw new NoBlogListingFoundException("No blog listing found attached to the current item.");
            }

            // 2.) get our rendering parameters
            var parameters = RenderingContext.GetRenderingParameters<IBlogRenderingParameters>();
            if (parameters == null)
            {
                throw new RenderingParametersNotFoundException("No rendering parameters found for the item!");
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