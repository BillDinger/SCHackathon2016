namespace Sitecore.Feature.Blog.CMS.Analytics
{
    using System.Collections.Generic;

    public interface IAnalyticsService
    {
        IList<string> GetRankedTagNames();
    }
}