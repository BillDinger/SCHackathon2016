namespace Sitecore.Feature.Blog.Factories.Exceptions
{
    using System;
    public class ContainerNotFoundException : Exception
    {
        public ContainerNotFoundException(string message) : base(message)
        {
        }
    }
}