namespace Sitecore.Feature.Blog.CMS.Factories
{
    using System;
    using Castle.MicroKernel;

    public class DefaultCmsFactory : ICmsFactory
    {
        public T Create<T>() where T : class
        {
            return null;
        }

        public void Initialize(IKernel kernel)
        {
            if (kernel == null)
            {
                throw new ArgumentNullException(nameof(kernel));
            }
        }
    }
}