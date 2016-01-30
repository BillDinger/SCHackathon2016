namespace Sitecore.Feature.Blog.CMS
{
    using Sitecore.Configuration;

    public class DefaultSitecoreConfiguration : ISitecoreConfiguration
    {
        public int GetMaxNumberOfItemsToDisplay { get { return Settings.GetIntSetting("DefaultMaxBlogListings", 10); }
    }
}