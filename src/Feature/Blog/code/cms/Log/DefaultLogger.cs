namespace Sitecore.Feature.Blog.CMS.Log
{
    using System;

    public class DefaultLogger : ILogger
    {
        private const string LogPrepend = "[BLOG]";

        public void Audit(string message, object owner)
        {
            var formattedMessage = $"{LogPrepend} {message}";
            Diagnostics.Log.Audit(formattedMessage, owner);
        }

        public void Debug(string message, object owner)
        {
            var formattedMessage = $"{LogPrepend} {message}";
            Diagnostics.Log.Debug(formattedMessage, owner);
            Diagnostics.Tracer.Debug(formattedMessage);
        }

        public void Error(string message, Exception ex, object owner)
        {
            var formattedMessage = $"{LogPrepend} {message}";
            Diagnostics.Log.Error(formattedMessage, ex, owner);
            Diagnostics.Tracer.Error(formattedMessage);
        }

        public void Fatal(string message, object owner)
        {
            var formattedMessage = $"{LogPrepend} {message}";
            Diagnostics.Log.Fatal(formattedMessage, owner);
            Diagnostics.Tracer.Fatal(formattedMessage);
        }

        public void Info(string message, object owner)
        {
            var formattedMessage = $"{LogPrepend} {message}";

            Diagnostics.Log.Info(formattedMessage, owner);
            Diagnostics.Tracer.Info(formattedMessage, owner);
        }

        public void Warn(string message, object owner)
        {
            var formattedMessage = $"{LogPrepend} {message}";
            Diagnostics.Log.Warn(formattedMessage, owner);
            Diagnostics.Tracer.Warning(formattedMessage, owner);
        }
    }
}