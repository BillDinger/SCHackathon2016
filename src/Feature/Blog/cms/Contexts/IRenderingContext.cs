namespace Sitecore.Feature.Blog.CMS.Contexts
{
    public interface IRenderingContext
    {
        string DataSource { get; }

        T GetRenderingParameters<T>() where T : class;
    }
}