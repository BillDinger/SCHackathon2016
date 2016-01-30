using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;

namespace Sitecore.Feature.Blog.Domain.Templates
{
    [SitecoreType(TemplateId = DataTemplateIds.BlogDetail, AutoMap = true)]
    public interface IBlogDetail : ISitecoreItem
    {
        DateTime BlogDetailDate { get; set; }
        string BlogDetailTitle { get; set; }
        string BlogDetailAbstract { get; set; }
        string BlogDetailBody { get; set; }
        Image BlogDetailImage { get; set; }
    }
}
