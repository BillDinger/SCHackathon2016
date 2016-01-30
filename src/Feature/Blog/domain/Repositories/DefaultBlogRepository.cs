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
        public IList<IBlogDetail> GetBlogDetails(int count, IEnumerable<IBlogCategory> categories,
            ISitecoreItem startItem)
        {
            // 1.) If no categories just return null.
            if (categories == null)
            {
                return new List<IBlogDetail>();
            }
            if (startItem == null)
            {
                // should be impossible!
                throw new ArgumentNullException(nameof(startItem));
            }

            // 2.) Create our Sitecore Fast query to pull all templates. For speed we pull relative to the
            // start item the user specifies
            var query = string.Format("fast:{0}//**[@@id='{1}']//*[@@templateid='{2}']", Context.SiteStartPath,
                startItem.Id, DataTemplateIds.BlogDetail.ToUpper());
            Logger.Debug(string.Format("Running the query {0}", query), this);

            // 3.) Query our context
            var items = Context.Query<IBlogDetail>(query).Take(count).OrderBy(x => x.BlogDetailDate).ToList();
            Logger.Debug(string.Format("Found {0} items for our query {1}, returning {2}",
                items.Count(), query, count), this);

            return items;
        }

        public IList<IBlogDetail> GetBlogDetailsByScore(int count)
        {
            // 1.) retrieve from our analytics provider the top scored

            throw new NotImplementedException();
        }
    }
}