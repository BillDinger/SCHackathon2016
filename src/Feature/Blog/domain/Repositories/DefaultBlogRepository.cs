namespace Sitecore.Feature.Blog.Domain.Services
{
    using System;
    using System.Collections.Generic;
    using Sitecore.Feature.Blog.CMS.Contexts;
    using Sitecore.Feature.Blog.CMS.Log;
    using Sitecore.Feature.Blog.Domain.Templates;

    public class DefaultBlogService : IBlogService
    {
        private ILogger Logger { get; }

        public DefaultBlogService(ILogger logger, IContext context)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            Logger = logger;
        }

        public IList<IBlogDetail> Blogs(int count, IEnumerable<IBlogCategory> DisplayedCategories)
        {
            // 1.) If no categories, don't display any
            if (DisplayedCategories == null)
            {
                return new List<IBlogDetail>();
            }

            // 2.) Build a dynamic query based on how many 
            // example: fast://sitecore/content///*[@@templateid='{066160AE-9C16-4CE8-89A9-74E05020E3A8}' and @SubProgramId='12345']
            var query = string.Format("fast:{0}//*[@{1}='{2}']", Context.Site.RootPath, Iblo);


        }
    }
}