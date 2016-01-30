namespace Sitecore.Feature.Blog.CMS.Contexts
{
    using System;
    using Glass.Mapper.Sc;
    using Sitecore.Sites;

    public interface IContext : ISitecoreContext
    {
        Guid CurrentItemId { get; }

        string Language { get; }

        SiteContext Site { get; }

    }
}