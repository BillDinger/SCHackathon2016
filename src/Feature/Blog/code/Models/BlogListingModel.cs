namespace Sitecore.Feature.Blog.Models
{
    using System.Collections.Generic;
    using Sitecore.Feature.Blog.Domain.Templates;
    using System.Linq;

    public class BlogListingModel
    {
        public IList<BlogSummaryModel> BlogSummaryModels { get; }

        public BlogListingModel(IBlogListing blogListing, int number)
        {
            if (blogListing == null)
            {
                BlogSummaryModels = new List<BlogSummaryModel>();
            }
            else
            {
                BlogSummaryModels = blogListing.DisplayedCategories.Take(number)
                    .Select(x => new BlogSummaryModel()).ToList();
            }

        }
    }
}