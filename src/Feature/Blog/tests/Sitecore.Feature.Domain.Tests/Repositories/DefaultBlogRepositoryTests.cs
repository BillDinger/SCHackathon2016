namespace Sitecore.Feature.Domain.Tests.Repositories
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Sitecore.Feature.Blog.CMS.Contexts;
    using Sitecore.Feature.Blog.CMS.Log;
    using Sitecore.Feature.Blog.Domain.Repositories;

    [TestClass]
    public class DefaultBlogRepositoryTests
    {
        [TestMethod]
        public void Constructor_ValidArgs_DefaultBlogRepository()
        {
            // arrange
            var mockLogger = new Mock<ILogger>();
            var mockContext = new Mock<IContext>();

            // act.
            var repository = new DefaultBlogRepository(mockLogger.Object, mockContext.Object);

            // assert.
            Assert.IsNotNull(repository);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullLogger_ArgumentNullException()
        {
            // arrange
            var mockContext = new Mock<IContext>();

            try
            {
                // act.
                var repository = new DefaultBlogRepository(null, mockContext.Object);
                Assert.IsNull(repository);
            }
            catch (ArgumentNullException ex)
            {
                // assert.
                Assert.AreEqual("logger", ex.ParamName);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullContext_ArgumentNullException()
        {
            // arrange
            var mockLogger = new Mock<ILogger>();

            try
            {
                // act.
                var repository = new DefaultBlogRepository(mockLogger.Object, null);
                Assert.IsNull(repository);
            }
            catch (ArgumentNullException ex)
            {
                // assert.
                Assert.AreEqual("context", ex.ParamName);
                throw;
            }
        }

    }
}