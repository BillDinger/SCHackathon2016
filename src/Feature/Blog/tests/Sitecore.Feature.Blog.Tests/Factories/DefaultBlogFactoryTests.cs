using System;

namespace Sitecore.Feature.Blog.CMS.Tests.Factories
{
    using Castle.MicroKernel;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Sitecore.Feature.Blog.Domain.Templates;
    using Sitecore.Feature.Blog.Factories;
    using Sitecore.Feature.Blog.Factories.Exceptions;

    [TestClass]
    public class DefaultBlogFactoryTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Initialize_NullKernel_ArgumentNullException()
        {
            // arrange
            var factory = new DefaultBlogFactory();

            try
            {
                // act         
                factory.Initialize(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("kernel", ex.ParamName);
                throw;
            }


        }

        [TestMethod]
        [ExpectedException(typeof(ContainerAlreadyInitializedException))]
        public void Initialize_CalledTwice_ContainerAlreadyInitializedException()
        {
            // arrange
            var mockKernel = new Mock<IKernel>();

            using (var factory = new DefaultBlogFactory())
            {
                factory.Initialize(mockKernel.Object);

                // act
                factory.Initialize(mockKernel.Object);
            }
        }

        [TestMethod]
        public void Create_Void_IBloglisting()
        {
            // arrange
            var mockKernel = new Mock<IKernel>();
            var factory = new DefaultBlogFactory();
            factory.Initialize(mockKernel.Object);
            var mockBlog = new Mock<IBlogListing>();
            mockKernel.Setup(x => x.Resolve<IBlogListing>()).Returns(mockBlog.Object);

            // act.
            var result = factory.Create<IBlogListing>();

            // assert.
            Assert.IsNotNull(result);


        }

    }
}
