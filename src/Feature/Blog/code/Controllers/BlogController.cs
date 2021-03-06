﻿namespace Sitecore.Feature.Blog.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Sitecore.Feature.Blog.CMS;
    using Sitecore.Feature.Blog.CMS.Contexts;
    using Sitecore.Feature.Blog.CMS.Log;
    using Sitecore.Feature.Blog.CMS.Managers;
    using Sitecore.Feature.Blog.Domain.Repositories;
    using Sitecore.Feature.Blog.Domain.Templates;
    using Sitecore.Feature.Blog.Factories;
    using Sitecore.Feature.Blog.Factories.Exceptions;
    using Sitecore.Feature.Blog.Models;

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

        private ILinkManager LinkManager { get; }

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
            LinkManager = BlogFactory.Create<ILinkManager>();
        }


        public ActionResult Index()
        {
            // 1.) Retrieve our current item from our context.
            var listing = Context.GetItem<IBlogListing>(RenderingContext.DataSource);
            if (listing == null)
            {
                Logger.Debug("No listings found, returning empty list.", this);
                return View("BlogListing", new BlogListingModel(LinkManager, new List<IBlogDetail>(), null));
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
            return View("BlogListing", new BlogListingModel(LinkManager, items, listing));
        }

        public ActionResult BlogDetail()
        {
            var blogDetail = Context.GetCurrentItem<IBlogDetail>();
            if (blogDetail != null)
            {

                return View(blogDetail);
            }
            else
            {
                return Content("No datasource set");
            }
        }

        public ActionResult RankedIndex()
        {
            // call our analytics service for our ranked item.
            var result = Repository.GetBlogDetailsByScore(ItemsToDisplay);

            return View("BlogListing", new BlogListingModel(LinkManager, result, null));
        }
    }
}