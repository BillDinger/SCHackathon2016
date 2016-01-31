namespace Sitecore.Feature.Blog.CMS.Managers
{
    using System;
    using Sitecore.Data.Items;
    using Sitecore.Feature.Blog.CMS.Contexts;
    using Sitecore.Links;


    public class DefaultLinkManager : ILinkManager
    {
        public DefaultLinkManager(IContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            Context = context;
        }

        private IContext Context { get; }

        public string GetItemUrl(Guid itemId)
        {
            if (itemId == Guid.Empty)
            {
                throw new ArgumentNullException("itemId", "guid cannot be guid.empty!");
            }

            // 1.) resolve our item from Glass context
            var item = Context.GetItem<Item>(itemId);

            // 2.) Fall back to Link manager
            return LinkManager.GetItemUrl(item);
        }
    }
}