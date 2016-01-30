namespace Sitecore.Feature.Blog.Controllers.Exceptions
{
    using System;
    public class NoBlogListingFoundException : Exception
    {
        public NoBlogListingFoundException(string message) : base(message)
        {
        }
    }
}