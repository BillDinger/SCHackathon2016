namespace Sitecore.Feature.Blog.CMS.Analytics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Sitecore.Analytics;
    using Sitecore.Feature.Blog.CMS.Log;

    public class DefaultAnalyticsService : IAnalyticsService
    {
        private ILogger Logger { get; }

        public DefaultAnalyticsService(ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            Logger = logger;
        }
        public IList<string> GetRankedTagNames()
        {

            // SUuuuuuuuper  well documented what can and can't be null.
            if (Tracker.Current == null)
            {
                return new List<string>();
            }

            if (Tracker.Current.Session == null)
            {
                return new List<string>();
            }

            if (Tracker.Current.Session.Interaction == null)
            {
                return new List<string>();
            }

            if (Tracker.Current.Session.Interaction.Profiles == null)
            {
                return new List<string>();
            }


            // 1.) Get ProfileNames
            var profiles = Tracker.Current.Session.Interaction.Profiles.GetProfileNames();

            // 2.) For each profile in the profile name, get their name and rank
            var tags = new Dictionary<string, float>();
            if (profiles != null)
            {
                foreach (var profile in profiles)
                {
                    tags.Add(profile, Tracker.Current.Session.Interaction.Profiles[profile].Total);
                }
            }

            // 3.) return out tags ranked.
            return tags.OrderBy(x => x.Value).Select(y => y.Key).ToList();
        }
    }
}