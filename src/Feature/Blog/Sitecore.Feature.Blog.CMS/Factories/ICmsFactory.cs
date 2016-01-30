namespace Sitecore.Feature.Blog.CMS.Factories
{
    public interface ICmsFactory
    {
        T Create<T>() where T : class;
    }
}