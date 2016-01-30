namespace Sitecore.Feature.Blog.Controllers
{
    using System;
    using System.Web.Mvc;
    using Sitecore.Feature.Blog.CMS.Contexts;
    using Sitecore.Feature.Blog.CMS.Log;

    public class BlogController : Controller
    {
        private readonly IContext _context;
        private IContext Context { get { return _context; } }

        private readonly IRenderingContext _renderingContext;
        private IRenderingContext RenderingContext { get { return _renderingContext; } }

        private readonly ILogger _logger;
        private ILogger Logger { get { return _logger; } }

        public BlogController(IContext context, IRenderingContext renderingContex, ILogger logger)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (renderingContex == null)
            {
                throw new ArgumentNullException("renderingContex");
            }
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            _logger = logger;
            _context = context;
            _renderingContext = renderingContex;
        }

        public ActionResult Index()
        {

        }

        public ActionResult BlogDetail()
        {
            
        }
    }
}