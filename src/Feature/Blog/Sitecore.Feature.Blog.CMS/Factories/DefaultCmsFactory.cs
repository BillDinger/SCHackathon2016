namespace Sitecore.Feature.Blog.CMS.Factories
{
    public class DefaultCmsFactory : ICmsFactory
    {
        public T Create<T>() where T : class
        {
            return null;
        }
    }
}