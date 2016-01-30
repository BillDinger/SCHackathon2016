namespace Sitecore.Feature.Blog.Domain.Repositories
{
    using System;
    using System.Collections.Concurrent;
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

        /// <summary>
        /// NOTE: Performant heavy. Will require refactor to use solr or lucene search indexes and/or caching of data
        /// under high load
        /// </summary>
        /// <param name="count">Number of parameters</param>
        /// <param name="categories">Categories to search on</param>
        /// <param name="startItem">Relative path to serach to limit our hit on the database</param>
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
            foreach (var category in categories)
            {
                var first = categories.FirstOrDefault();
                if (category == first)
                {
                    sb.Append($"@Category='%{category.Id.ToString("B")}%'");
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
            // 1.) retrieve from our analytics provider the top scored

            throw new NotImplementedException();
        }
    }
}