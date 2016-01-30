namespace Sitecore.Feature.Blog.Factories
{
    using Castle.MicroKernel;

    public interface IBlogFactory
    {
        T Create<T>();

        void Initialize(IKernel kernel);
    }
}