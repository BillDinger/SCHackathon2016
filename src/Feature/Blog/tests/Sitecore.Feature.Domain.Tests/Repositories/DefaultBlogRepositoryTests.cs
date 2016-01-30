namespace Sitecore.Feature.Domain.Tests.Repositories
{
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

    }
}