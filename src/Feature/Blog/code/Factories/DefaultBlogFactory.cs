namespace Sitecore.Feature.Blog.Factories
{
    using System;
    using Castle.MicroKernel;
    using Sitecore.Feature.Blog.Factories.Exceptions;

    public class DefaultBlogFactory : IBlogFactory, IDisposable
    {
        private static IKernel Kernel { get; set; }

        public T Create<T>()
        {
            return Kernel.Resolve<T>();
        }

        public void Initialize(IKernel kernel)
        {
            if (kernel == null)
            {
                throw new ArgumentNullException(nameof(kernel));
            }

            if (Kernel != null)
            {
                throw new ContainerAlreadyInitializedException("The Kernel has already been initialized!");
            }

            Kernel = kernel;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Kernel != null)
                {
                    Kernel.Dispose();
                    Kernel = null;
                }
            }
        }
    }
}