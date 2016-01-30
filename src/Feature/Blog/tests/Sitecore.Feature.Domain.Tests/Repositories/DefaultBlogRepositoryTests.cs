namespace Sitecore.Feature.Domain.Tests.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Glass.Mapper.Sc.IoC;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Sitecore.Feature.Blog.App_Start;
    using Sitecore.Feature.Blog.CMS.Analytics;
    using Sitecore.Feature.Blog.CMS.Contexts;
    using Sitecore.Feature.Blog.CMS.Log;
    using Sitecore.Feature.Blog.Domain.Repositories;
    using Sitecore.Feature.Blog.Domain.Templates;


    [TestClass]
    public class DefaultBlogRepositoryTests
    {
        [TestInitialize]
        public void SetupContextLock()
        {
            //Creates a Glass Context, otherwise these tests don't work
            var mockResolver = new Mock<IDependencyResolver>();
            Glass.Mapper.Context.Create(mockResolver.Object);

            // start Glass.Mapper.
            GlassMapperSc.Start();
        }

        [TestMethod]
        public void Constructor_ValidArgs_DefaultBlogRepository()
        {
            // arrange
            var mockLogger = new Mock<ILogger>();
            var mockContext = new Mock<IContext>();
            var mockService = new Mock<IAnalyticsService>();

            // act.
            var repository = new DefaultBlogRepository(mockLogger.Object, mockContext.Object, mockService.Object);

            // assert.
            Assert.IsNotNull(repository);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullLogger_ArgumentNullException()
        {
            // arrange
            var mockContext = new Mock<IContext>();
            var mockService = new Mock<IAnalyticsService>();
            try
            {
                // act.
                var repository = new DefaultBlogRepository(null, mockContext.Object, mockService.Object);
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
            var mockService = new Mock<IAnalyticsService>();
            try
            {
                // act.
                var repository = new DefaultBlogRepository(mockLogger.Object, null, mockService.Object);
                Assert.IsNull(repository);
            }
            catch (ArgumentNullException ex)
            {
                // assert.
                Assert.AreEqual("context", ex.ParamName);
                throw;
            }
        }

        [TestMethod]
        public void GetBlogDetails_NullCategories_EmptyList()
        {
            // arrange
            var mockLogger = new Mock<ILogger>();
            var mockContext = new Mock<IContext>();
            var mockService = new Mock<IAnalyticsService>();
            var repository = new DefaultBlogRepository(mockLogger.Object, mockContext.Object, mockService.Object);

            // act.
            IList<IBlogDetail> blogs = repository.GetBlogDetails(10, null, null);

            // assert.
            Assert.AreEqual(0, blogs.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetBlogDetails_NullStartItem_ArgumentNullException()
        {
            // arrange
            var mockLogger = new Mock<ILogger>();
            var mockContext = new Mock<IContext>();
            var mockService = new Mock<IAnalyticsService>();
            var repository = new DefaultBlogRepository(mockLogger.Object, mockContext.Object, mockService.Object);

            // setup our mock categories
            var mockCategory = new Mock<IBlogCategory>();
            mockCategory.Setup(x => x.CategoryName).Returns("STUFFS");
            var mockCategories = Enumerable.Repeat(mockCategory.Object, 3);

            try
            {
                // act.
                IList<IBlogDetail> blogs = repository.GetBlogDetails(10, mockCategories, null);
                Assert.IsNull(blogs);
            }
            catch (ArgumentNullException ex)
            {
                // assert.
                Assert.AreEqual("startItem", ex.ParamName);
                throw;
            }
        }

        [TestMethod]
        public void GetBlogDetails_ValidCategoriesAndStartItem_BlogDetails()
        {
            // setup our mock categories
            var mockCategory = new Mock<IBlogCategory>();
            mockCategory.Setup(x => x.CategoryName).Returns("STUFFS");
            var mockCategories = Enumerable.Repeat(mockCategory.Object, 3);

            // setup our start item
            var mockItem = new Mock<ISitecoreItem>();
            mockItem.Setup(x => x.Id).Returns(() => Guid.NewGuid());

            // setup fake results
            var detail = new Mock<IBlogDetail>();
            detail.Setup(x => x.BlogDetailBody).Returns("BodyS");
            var blogDetails = Enumerable.Repeat(detail.Object, 55);

            // setup our context
            var mockContext = new Mock<IContext>();
            mockContext.Setup(x => x.Query<IBlogDetail>(It.IsAny<string>(), false, false)).Returns(blogDetails);
            mockContext.Setup(x => x.SiteStartPath).Returns("/blah/blah");
            // setup the repo
            var mockLogger = new Mock<ILogger>();
            var mockService = new Mock<IAnalyticsService>();
            var repository = new DefaultBlogRepository(mockLogger.Object, mockContext.Object, mockService.Object);

            // act
            var result = repository.GetBlogDetails(2, mockCategories, mockItem.Object);

            // assert.
            Assert.AreEqual(2, result.Count);
        }



    }
}