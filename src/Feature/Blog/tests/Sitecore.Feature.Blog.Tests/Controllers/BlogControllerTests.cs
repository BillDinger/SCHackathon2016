namespace Sitecore.Feature.Blog.Tests.Controllers
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Sitecore.Feature.Blog.Controllers;
    using Sitecore.Feature.Blog.Factories;
    using Sitecore.Feature.Blog.Factories.Exceptions;

    [TestClass]
    public class BlogControllerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ContainerNotFoundException))]
        public void Constructor_Void_ContainerNotFoundException()
        {

            var controller = new BlogController();

            Assert.IsNull(controller);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Initialize_NullBlogFactory_ArgumentNullException()
        {


            BlogController.Init(null);

        }

        [TestMethod]
        public void Initialize_Blogfactory_BlogController()
        {
            // arrange
            var mockFactory = new Mock<IBlogFactory>();
            BlogController.Init(mockFactory.Object);

            // act
            var blogController = new BlogController();

            // assert.
            Assert.IsNotNull(blogController);
        }

    }
}