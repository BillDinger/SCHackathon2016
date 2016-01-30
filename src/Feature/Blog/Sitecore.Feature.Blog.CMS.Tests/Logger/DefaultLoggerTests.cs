namespace Sitecore.Feature.Blog.CMS.Tests.Logger
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Log;

    [TestClass]
    public class DefaultLoggerTests
    {
        [TestMethod]
        public void Info_RandomString_Void()
        {
            // arrange.

            var test = new DefaultLogger();

            // act.
            test.Info("yay", this);

            // assert.
            Assert.IsNotNull(test);

        }

        [TestMethod]
        public void Audit_RandomString_Void()
        {
            // arrange.

            var test = new DefaultLogger();

            // act.
            test.Audit("yay", this);

            // assert.
            Assert.IsNotNull(test);

        }
        [TestMethod]
        public void Debug_RandomString_Void()
        {
            // arrange.

            var test = new DefaultLogger();

            // act.
            test.Debug("yay", this);

            // assert.
            Assert.IsNotNull(test);

        }

        [TestMethod]
        public void Error_RandomString_Void()
        {
            // arrange.

            var test = new DefaultLogger();

            // act.
            test.Error("yay", new Exception(), this);

            // assert.
            Assert.IsNotNull(test);

        }

        [TestMethod]
        public void Fatal_RandomString_Void()
        {
            // arrange.

            var test = new DefaultLogger();

            // act.
            test.Fatal("yay", this);

            // assert.
            Assert.IsNotNull(test);

        }

        [TestMethod]
        public void Warn_RandomString_Void()
        {
            // arrange.

            var test = new DefaultLogger();

            // act.
            test.Warn("yay", this);

            // assert.
            Assert.IsNotNull(test);

        }
    }
}