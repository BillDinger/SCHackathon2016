namespace Sitecore.Feature.Blog.Domain.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Sitecore.Feature.Blog.CMS.Analytics;
    using Sitecore.Feature.Blog.CMS.Contexts;
    using Sitecore.Feature.Blog.CMS.Log;
    using Sitecore.Feature.Blog.Domain.Templates;

    public class DefaultBlogRepository : IBlogRepository
    {

        private ILogger Logger { get; }
        private IContext Context { get; }

        private IAnalyticsService AnalyticsService { get; }

        public DefaultBlogRepository(ILogger logger, IContext context, IAnalyticsService analyticsService)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (analyticsService == null)
            {
                throw new ArgumentNullException(nameof(analyticsService));
            }

            Logger = logger;
            Context = context;
            AnalyticsService = analyticsService;
        }

        /// <summary>
        /// NOTE: Performant heavy. Will require refactor to use solr or lucene search indexes and/or caching of data
        /// under high load
        /// </summary>
        /// <param name="count">Number of parameters</param>
        /// <param name="categories">Categories to search on</param>
        /// <param name="startItem">Relative path to search to limit our hit on the database</param>
        /// <returns></returns>
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

            // 1.) We need every blog that has that tag associated with it. Tags are stored as GUIDs like this in
            // the categories field == {imaguid} | {imanotherguid} | {moreguidsss} so we do a gigantic
            // like query depending on how many tags we get in.
            var sb = new System.Text.StringBuilder();
            var performantCategories = categories.ToList();
            foreach (var category in performantCategories)
            {
                var first = performantCategories.FirstOrDefault();
                if (category == first)
                {
                    if (category != null)
                    {
                        sb.Append($"@Category='%{category.Id.ToString("B")}%'");
                    }
                }
                else
                {
                    sb.Append($" or @Category='%{category.Id.ToString("B")}%'");
                }
            }

            // 2.) Query relative to the start item
            var query = string.Format("fast:{0}//*[@@id='{1}']//*[@@templateid='{2}' and ({3})]", Context.SiteStartPath,
                startItem.Id, DataTemplateIds.BlogDetail.ToUpper(), sb.ToString());
            Logger.Debug(string.Format("Running the query {0}", query), this);


            // 3.) Query our context with our query
            var items = Context.Query<IBlogDetail>(query).Take(count).OrderBy(x => x.BlogDetailDate).ToList();
            Logger.Debug(string.Format("Found {0} items for our query {1}, returning {2}",
                items.Count(), query, count), this);

            // 4.) Return
            return items;

        }

        public IList<IBlogDetail> GetBlogDetailsByScore(int count)
        {
            // 1.) retrieve from our analytics provider the names of hte top scored items.
            IList<string> tagNames = AnalyticsService.GetRankedTagNames();


            var returnList = new Queue<IBlogDetail>();
            foreach (var tag in tagNames)
            {
                // 2.) Create our query per tag.
                var query = string.Format("fast:{0}//*[@@templateid='{2}' and @@name='{3}')]", Context.SiteStartPath,
                    DataTemplateIds.BlogDetail.ToUpper(), tag);
                Logger.Debug(string.Format("Running the query {0}", query), this);
                var queryResult = Context.Query<IBlogDetail>(query);
                if (queryResult != null)
                {
                    foreach (var result in queryResult)
                    {
                        returnList.Enqueue(result);
                    }
                }

                // 3.) If we're over our query return list, yes I should perform this ahead of time but we're
                // like a few minutes from deadline!
                if (queryResult.Count() > count)
                {
                    return queryResult.Take(count).ToList();
                }

            }
        }
    }
}