using Glass.Mapper.Sc.Configuration.Attributes;
using System.Collections.Generic;

namespace Sitecore.Feature.Blog.Domain.Templates
{
    [SitecoreType(TemplateId = DataTemplateIds.BlogCategory, AutoMap = true)]
    public interface IBlogCategory : ISitecoreItem
    {
        string CategoryName { get; set; }
        IEnumerable<IBlogCategory> Categories { get; set; }
    }
}
