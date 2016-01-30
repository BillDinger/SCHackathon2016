namespace Sitecore.Feature.Blog.CMS.Factories
{
    using Castle.MicroKernel;

    public interface ICmsFactory
    {
        T Create<T>() where T : class;

        void Initialize(IKernel kernel);
    }
}