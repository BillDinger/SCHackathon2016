namespace Sitecore.Feature.Blog.CMS.Contexts
{
    using Sitecore.Mvc.Presentation;

    public class DefaultRenderingContext : IRenderingContext
    {
        public string DataSource { get { return RenderingContext.Current.Rendering.DataSource; } }
    }
}