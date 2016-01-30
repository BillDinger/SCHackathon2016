namespace Sitecore.Feature.Blog.Controllers
{
    using System;
    using System.Web.Mvc;
    using Sitecore.Feature.Blog.CMS;
    using Sitecore.Feature.Blog.CMS.Contexts;
    using Sitecore.Feature.Blog.CMS.Log;
    using Sitecore.Feature.Blog.Controllers.Exceptions;
    using Sitecore.Feature.Blog.Domain.Repositories;
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

        private IContext Context { get; }

        private IRenderingContext RenderingContext { get; }

        private ILogger Logger { get; set; }

        private IBlogRepository Repository { get; }

        private int ItemsToDisplay { get; }

        public BlogController()
        {
            if (BlogFactory == null)
            {
                throw new ContainerNotFoundException("No di container was found, unable to start the controller!");
            }
            Context = BlogFactory.Create<IContext>();
            RenderingContext = BlogFactory.Create<IRenderingContext>();
            Logger = BlogFactory.Create<ILogger>();
            Repository = BlogFactory.Create<IBlogRepository>();
            ItemsToDisplay = BlogFactory.Create<ISitecoreConfiguration>().GetMaxNumberOfItemsToDisplay;
        }


        public ActionResult Index()
        {
            // 1.) Retrieve our current item from our context.
            var listing = Context.GetItem<IBlogListing>(RenderingContext.DataSource);
            if (listing == null)
            {
                throw new NoBlogListingFoundException("No blog listing found attached to the current item.");
            }

            // 2.) get our rendering parameters
            var parameters = RenderingContext.GetRenderingParameters<IBlogRenderingParameters>();
            int returnCount = ItemsToDisplay;
            if (parameters != null)
            {
                returnCount = parameters.ItemsToDisplay;
            }


            // 3.) query for our items.
            var items = Repository.GetBlogDetails(returnCount, listing.DisplayedCategories, listing.StartItem);

            // 4.) Return our view
            return View("BlogListing", items);
        }

        public ActionResult BlogDetail()
        {
            throw new NotImplementedException();
        }
    }
}