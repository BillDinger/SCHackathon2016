using Glass.Mapper.Sc.Configuration.Attributes;

namespace Sitecore.Feature.Blog.Domain.Templates
{
    [SitecoreType(TemplateId = DataTemplateIds.BlogRenderingParameters, AutoMap = true)]
    public interface IBlogRenderingParameters : ISitecoreItem
    {
        int ItemsToDisplay { get; set; }
    }
}
