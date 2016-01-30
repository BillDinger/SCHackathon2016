namespace Sitecore.Feature.Blog.CMS.Tests.Contexts
{
    using System;
    using Glass.Mapper.IoC;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using App_Start;
    using CMS.Contexts;

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

        [TestCleanup]
        public void Cleanup()
        {
            // wipe our context.
            Glass.Mapper.Context.Contexts.Clear();
            Sitecore.Context.SetActiveSite("website");
        }

    }
}