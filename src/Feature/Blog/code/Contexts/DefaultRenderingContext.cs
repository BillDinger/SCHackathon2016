namespace Sitecore.Feature.Blog.CMS.Contexts
{
    using Glass.Mapper.Sc;
    using Sitecore.Mvc.Presentation;

    public class DefaultRenderingContext : IRenderingContext
    {

        public string DataSource { get { return RenderingContext.Current.Rendering.DataSource; } }

        public T GetRenderingParameters<T>() where T : class
        {
            // 1.) Attempt to Resolve our current rendering parameters
            string renderingParams = RenderingContext.CurrentOrNull.Rendering["Parameters"];
            if (string.IsNullOrEmpty(renderingParams))
            {
                return default(T);
            }

            // 2.) create a new glass context
            var glassHtml = new GlassHtml(new SitecoreContext());

            // 3.) Return our rendering parameters
            return glassHtml.GetRenderingParameters<T>(RenderingContext.Current.Rendering.Parameters.ToString());
        }
    }
}