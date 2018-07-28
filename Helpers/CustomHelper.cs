using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Sites;
using Sitecore.Web;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sitecore.SharedSource.Customizations
{
    public static class CustomHelper
    {
        /// <summary>
        /// To return list of languages versions which are available as part of specific item.
        /// </summary>
        /// <param name="item">Selected item</param>
        /// <returns>list of languages</returns>
        public static List<string> LanguagesWithContent(this Item item)
        {
            var result = ItemManager.GetContentLanguages(item).Select(lang => new {
                lang.Name,
                Versions = ItemManager.GetVersions(item, lang).Count
            }).Where(t => t.Versions > 0).Select(t => t.Name).ToList();
            return result;
        }

        /// <summary>
        /// To return context site item.
        /// </summary>
        /// <param name="item">Selected item</param>
        /// <returns>Context Site</returns>
        public static SiteInfo GetSiteInfo(this Item item)
        {
            return SiteContextFactory.Sites
              .Where(siteInfo => !string.IsNullOrWhiteSpace(siteInfo.RootPath) && item.Paths.FullPath.StartsWith(siteInfo.RootPath, StringComparison.InvariantCultureIgnoreCase))
              .OrderByDescending(siteInfo => siteInfo.RootPath.Length)
              .FirstOrDefault();
        }
    }
}