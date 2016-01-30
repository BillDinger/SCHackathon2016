namespace Sitecore.Feature.Blog.Domain.Services
{
    using System.Collections.Generic;
    using Templates;

    public interface IBlogService
    {
        IList<IBlogDetail> Blogs(int count, IEnumerable<IBlogCategory> DisplayedCategories);
    }
}