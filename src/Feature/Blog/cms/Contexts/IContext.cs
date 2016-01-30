namespace Sitecore.Feature.Blog.CMS.Contexts
{
    using System;
    using Glass.Mapper.Sc;

    public interface IContext : ISitecoreContext
    {
        Guid CurrentItemId { get; }

        string Language { get; }
    }
}