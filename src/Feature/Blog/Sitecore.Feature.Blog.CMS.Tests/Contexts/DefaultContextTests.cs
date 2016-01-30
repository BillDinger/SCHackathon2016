namespace Sitecore.Feature.Blog.CMS.Tests.Contexts
{
    using Glass.Mapper.IoC;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Sitecore.Data.Managers;
    using Sitecore.Feature.Blog.App_Start;
    using Sitecore.Feature.Blog.CMS.Contexts;

    [TestClass]
    public class DefaultContextTests
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
        public void Language_Void_ContextLanguageName()
        {
            // arrange.
            var context = new DefaultContext();

            // act.
            string language = context.Language;

            // assert.
            Assert.AreEqual("en", language);
        }

    }
}