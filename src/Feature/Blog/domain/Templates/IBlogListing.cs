using Glass.Mapper.Sc.Configuration.Attributes;

namespace Sitecore.Feature.Blog.Domain.Templates
{
    [SitecoreType(TemplateId=DataTemplateIds.BlogListing, AutoMap = true)]
    public interface IBlogListing
    {
        string DisplayedCategories { get; set; }
        string BlogListingTitle { get; set; }
    }
}
