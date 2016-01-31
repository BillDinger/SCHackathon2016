namespace Sitecore.Feature.Blog.Models
{
    using System;
    using System.Collections.Generic;
    using Sitecore.Feature.Blog.CMS.Managers;
    using Sitecore.Feature.Blog.Domain.Templates;

    public class BlogListingModel
    {
        public IList<IBlogDetail> Blogs { get; } 
        
        public ILinkManager LinkManager { get; }

        public IBlogListing Listing { get; }

        public BlogListingModel(ILinkManager manager, IList<IBlogDetail> blogs, IBlogListing listing)
        {
            if (manager == null)
            {
                throw new ArgumentNullException(nameof(manager));
            }
            if (blogs == null)
            {
                throw new ArgumentNullException(nameof(blogs));
            }


            Blogs = blogs;
            LinkManager = manager;
            if (listing != null)
            {
                Listing = listing;
            }
        }
    }
}