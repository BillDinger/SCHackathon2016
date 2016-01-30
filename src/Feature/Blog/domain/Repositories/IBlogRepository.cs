namespace Sitecore.Feature.Blog.Domain.Repositories
{
    using System.Collections.Generic;
    using Sitecore.Feature.Blog.Domain.Templates;

    public interface IBlogRepository
    {
        IList<IBlogDetail> GetBlogDetails(int count, IEnumerable<IBlogCategory> categories,
            ISitecoreItem startItem);

        IList<IBlogDetail> GetBlogDetailsByScore(int count);
    }
}