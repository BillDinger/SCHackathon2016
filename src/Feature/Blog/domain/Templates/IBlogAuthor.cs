using Glass.Mapper.Sc.Configuration.Attributes;

namespace Sitecore.Feature.Blog.Domain.Templates
{
    [SitecoreType(TemplateId = DataTemplateIds.BlogAuthor, AutoMap = true)]
    public interface IBlogAuthor : ISitecoreItem
    {
    }
}
