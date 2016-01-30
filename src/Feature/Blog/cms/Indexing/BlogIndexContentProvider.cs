namespace Sitecore.Feature.Blog.CMS.Indexing
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Sitecore.ContentSearch.SearchTypes;
    using Sitecore.Data;
    using Sitecore.Foundation.Indexing.Infrastructure;
    using Sitecore.Foundation.Indexing.Models;

    public class BlogIndexContentProvider : IndexContentProviderBase
    {
        public override string ContentType { get; }
        public override IEnumerable<ID> SupportedTemplates { get; }
        public override Expression<Func<SearchResultItem, bool>> GetQueryPredicate(IQuery query)
        {
            return null;
        }

        public override void FormatResult(SearchResultItem item, ISearchResult formattedResult)
        {
        }
    }
}