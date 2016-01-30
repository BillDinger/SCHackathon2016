namespace Sitecore.Feature.Blog.CMS.Log
{
    using System;

    public interface ILogger
    {
        void Audit(string message, object owner);
        void Debug(string message, object owner);
        void Error(string message, Exception ex, object owner);
        void Fatal(string message, object owner);
        void Info(string message, object owner);
        void Warn(string message, object owner);
    }
}