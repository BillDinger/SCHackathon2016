namespace Sitecore.Feature.Blog.CMS.Analytics
{
    using System;
    using System.Collections.Generic;
    using Sitecore.Analytics;

    public class DefaultAnalyticsService : IAnalyticsService
    {
        public IList<string> GetRankedTagNames()
        {
            var nepis = Tracker.Current.Session.Interaction.Profiles.GetProfileNames();

            var teno = Tracker.Current.Session.Interaction.Profiles[nepis[0]];

            throw new NotImplementedException();
        }
    }
}