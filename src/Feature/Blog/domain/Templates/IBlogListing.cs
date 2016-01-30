using Glass.Mapper.Sc.Configuration.Attributes;

namespace Sitecore.Feature.Blog.Domain.Templates
{
    using System.Collections.Generic;

    [SitecoreType(TemplateId = DataTemplateIds.BlogListing, AutoMap = true)]
    public interface IBlogListing : ISitecoreItem
    {
        IEnumerable<IBlogCategory> DisplayedCategories { get; set; }
        string BlogListingTitle { get; set; }

    }
}
