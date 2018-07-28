using Sitecore.Shell.Applications.ContentEditor;
using System;

namespace Sitecore.SharedSource.Customizations
{
    public class LanguageSelectorList : MultilistEx
    {
        private void AvailableSiteLanguages()
        {
            try
            {
                var contextItem = Sitecore.Context.ContentDatabase.GetItem(ItemID);
                // Get context site info...
                var siteInfo = CustomHelper.GetSiteInfo(contextItem);
                // Get home item...
                var contextHomeItem = Sitecore.Context.ContentDatabase.GetItem(siteInfo.RootPath + siteInfo.StartItem);
                if(contextHomeItem != null)
                {
                    // To get language versions that are available as part of home item...
                    var availableLanguages = CustomHelper.LanguagesWithContent(contextHomeItem);
                    if (availableLanguages!=null)
                    {
                        var includedLanguages = "";
                        var languageCount = 1;
                        foreach (var selectedLanguage in availableLanguages)
                        {
                            if (languageCount>1)
                            {
                                includedLanguages += " or" + " @@name = '" + selectedLanguage + "'";
                            }
                            else
                            {
                                includedLanguages = includedLanguages + "@@name = '" + selectedLanguage + "'";
                            }
                            languageCount++;
                        }
                        Source = "query:" + this.Source + "/*[" + includedLanguages + "]";
                    }
                }
                else
                {
                    Source = this.Source;
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error("Error while loading available languages in Language Selector field type", ex.Message);
                Source = this.Source;
            }
        }

        protected override void DoRender(System.Web.UI.HtmlTextWriter output)
        {
            this.AvailableSiteLanguages();
            base.DoRender(output);
        }
    }
}