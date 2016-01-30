//namespace Sitecore.Feature.Blog.Tests.Controllers
//{
//    using System;
//    using Castle.Core.Internal;
//    using Microsoft.VisualStudio.TestTools.UnitTesting;
//    using Moq;
//    using Sitecore.Feature.Blog.CMS.Contexts;
//    using Sitecore.Feature.Blog.CMS.Log;
//    using Sitecore.Feature.Blog.Controllers;

//    [TestClass]
//    public class BlogControllerTests
//    {
//        [TestMethod]
//        public void Constructor_ValidArgs_BlogController()
//        {
//            // arrange
//            var mockLogger = new Mock<ILogger>();
//            var mockRenderContext = new Mock<IRenderingContext>();
//            var mockContext = new Mock<IContext>();

//            // act.
//            var controller = new BlogController(mockContext.Object,
//                mockRenderContext.Object, mockLogger.Object);

//            // assert.
//            Assert.IsNotNull(controller);
//        }

//        [TestMethod]
//        [ExpectedException(typeof(ArgumentNullException))]
//        public void Constructor_NullLogger_ArgumentNullException()
//        {
//            // arrange
//            var mockLogger = new Mock<ILogger>();
//            var mockRenderContext = new Mock<IRenderingContext>();
//            var mockContext = new Mock<IContext>();

//            try
//            {
//                // act.
//                var controller = new BlogController(mockContext.Object,
//                    mockRenderContext.Object, mockLogger.Object);
//            }
//            catch (ArgumentNullException ex)
//            {
//                Assert.AreEqual("logger", ex.ParamName);
//                throw;
//            }

//        }

//        [TestMethod]
//        [ExpectedException(typeof(ArgumentNullException))]
//        public void Constructor_NullRenderingContext_ArgumentNullException()
//        {
//            // arrange
//            var mockLogger = new Mock<ILogger>();
//            var mockRenderContext = new Mock<IRenderingContext>();
//            var mockContext = new Mock<IContext>();

//            try
//            {
//                // act.
//                var controller = new BlogController(mockContext.Object,
//                    mockRenderContext.Object, mockLogger.Object);
//                Assert.IsNull(controller);
//            }
//            catch (ArgumentNullException ex)
//            {
//                Assert.AreEqual("logger", ex.ParamName);
//                throw;
//            }

//        }

//        [TestMethod]
//        [ExpectedException(typeof(ArgumentNullException))]
//        public void Constructor_NullContext_ArgumentNullException()
//        {
//            // arrange
//            var mockLogger = new Mock<ILogger>();
//            var mockRenderContext = new Mock<IRenderingContext>();

//            try
//            {
//                // act.
//                var controller = new BlogController(null,
//                    mockRenderContext.Object, mockLogger.Object);
//                Assert.IsNull(controller);
//            }
//            catch (ArgumentNullException ex)
//            {
//                Assert.AreEqual("context", ex.ParamName);
//                throw;
//            }

//        }

//    }
//}