namespace Sitecore.Feature.Blog.Factories
{
    using System;
    using Castle.MicroKernel;
    using Sitecore.Feature.Blog.Factories.Exceptions;

    public class DefaultBlogFactory : IBlogFactory
    {
        private static IKernel Kernel { get; set; }

        public T Create<T>()
        {
            return Kernel.Resolve<T>();
        }

        void IBlogFactory.Initialize(IKernel kernel)
        {
            if (kernel == null)
            {
                throw new ArgumentNullException("kernel");
            }

            if (Kernel != null)
            {
                throw new ContainerAlreadyInitializedException("The Kernel has already been initialized!");
            }

            Kernel = kernel;
        }
    }
}