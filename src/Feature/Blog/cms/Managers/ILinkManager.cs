using System;

namespace Sitecore.Feature.Blog.CMS.Managers
{
    public interface ILinkManager
    {
        /// <summary>
        /// Retrieve Item Url by the guid of the sitecore item
        /// </summary>
        /// <param name="itemId">The ID of the sitecore item</param>
        /// <returns>a string URL</returns>
        string GetItemUrl(Guid itemId);
    }
}