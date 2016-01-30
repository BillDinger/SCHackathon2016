namespace Sitecore.Feature.Blog.CMS.Analytics
{
    using System;
    using System.Collections.Generic;
    using Sitecore.Analytics;

    public class DefaultAnalyticsService : IAnalyticsService
    {
        public IList<string> GetRankedTagNames()
        {
           
            // 1.) Get ProfileNames
            var profiles = Tracker.Current.Session.Interaction.Profiles.GetProfileNames();

            // 2.) For each profile in the profile name, get their name and rank
            var tags = new Dictionary<string, float>();
            if(profiles != null)
            {
                foreach (var profile in profiles)
                {
                    tags.Add(profile, Tracker.Current.Session.Interaction.Profiles[profile].Total);
                }
            }


            // 3.) return out tags

            throw new NotImplementedException();
        }
    }
}