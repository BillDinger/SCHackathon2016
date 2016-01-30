using System;


namespace Sitecore.Feature.Blog.Controllers.Exceptions
{
    public class RenderingParametersNotFoundException : Exception
    {
        public RenderingParametersNotFoundException(string message) : base(message)
        {
        }
    }
}