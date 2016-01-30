using System;

namespace Sitecore.Feature.Blog.Factories.Exceptions
{
    public class ContainerAlreadyInitializedException : Exception
    {
        public ContainerAlreadyInitializedException(string message) : base(message)
        {
        }
    }
}