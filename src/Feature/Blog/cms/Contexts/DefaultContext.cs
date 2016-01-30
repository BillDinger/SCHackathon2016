namespace Sitecore.Feature.Blog.CMS.Contexts
{
    using System;
    using Glass.Mapper.Sc;
    using Sitecore.Sites;


    public class DefaultContext : SitecoreContext, IContext
    {
        public Guid CurrentItemId
        {
            get { return Context.Item.ID.Guid; }
        }

        public string Language
        {
            get { return Context.Language.Name; }
        }


        public string SiteStartPath
        {
            get { return Context.Site.StartPath; }
        }
    }
}