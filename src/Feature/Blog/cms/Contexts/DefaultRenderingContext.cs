namespace Sitecore.Feature.Blog.CMS.Contexts
{
    using System;
    using Sitecore.Feature.Blog.CMS.Log;
    using Sitecore.Mvc.Presentation;

    public class DefaultRenderingContext : IRenderingContext
    {
        private readonly ILogger _logger;
        private ILogger Logger { get { return _logger; } }

        public DefaultRenderingContext(ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            _logger = logger;
        }
        public string DataSource { get { return RenderingContext.Current.Rendering.DataSource; } }

        public T GetRenderingParameters<T>() where T : class
        {
            // 1.) Attempt to Resplve our current rendering parameters
            string renderingParams = RenderingContext.CurrentOrNull.Rendering["Parameters"];
            if (string.IsNullOrEmpty(renderingParams))
            {
                Logger.Warn("Unable to resolve the rendering context parameters for the item {0}", this);
                return null;
            }
            throw new NotImplementedException();
        }
    }
}