namespace Sitecore.Feature.Blog.Domain.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Sitecore.Feature.Blog.CMS.Contexts;
    using Sitecore.Feature.Blog.CMS.Log;
    using Sitecore.Feature.Blog.Domain.Templates;

    public class DefaultBlogRepository : IBlogRepository
    {
        private ILogger Logger { get; }
        private IContext Context { get; }

        public DefaultBlogRepository(ILogger logger, IContext context)
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
            Context = context;
        }
        public IEnumerable<IBlogDetail> GetBlogDetails(int count, IEnumerable<IBlogCategory> categories,
            ISitecoreItem startItem)
        {
            // 1.) If no categories just return null.
            if (categories == null)
            {
                return Enumerable.Empty<IBlogDetail>();
            }

            // 2.) Create our Sitecore Fast query to pull all templates. For speed we pull relative to the
            // 
            //var query = string.Format("fast:{0}//**[@@id='{1}']//*[@@templateid='{1}']", Context.Site.StartPath, templateId.ToString("B").ToUpper(),
            //    fieldName, fieldValue);

            throw new NotImplementedException();
        }

    }
}