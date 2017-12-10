﻿using Portal.CMS.Web.Architecture.Helpers;
using System.Web.Optimization;

namespace Portal.CMS.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;
            BundleTable.EnableOptimizations = true;

            var cdnRootAddress = SettingHelper.Get("CDN Address");

            bundles.Add(new ScriptBundle("~/Resources/JavaScript/Framework").Include("~/Content/Scripts/Framework/*.js"));

            bundles.Add(new ScriptBundle("~/Resources/JavaScript/Framework/Administration").Include("~/Content/Scripts/Administration/*.js"));

            bundles.Add(GenerateCDNScriptBundle("~/Resources/JavaScript/Framework/Editor", "/Content/Scripts/Editor/QuickAccess.js", cdnRootAddress));

            bundles.Add(new ScriptBundle("~/Resources/JavaScript/Bootstrap", "https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js").Include("~/Content/Scripts/Bootstrap/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/Resources/JavaScript/JQueryUI", "https://code.jquery.com/ui/1.12.0-beta.1/jquery-ui.min.js").Include("~/Content/Scripts/JQuery/jquery.ui.min.js"));

            bundles.Add(new ScriptBundle("~/Resources/JavaScript/JQuery", "https://code.jquery.com/jquery-2.2.1.min.js").Include("~/Content/Scripts/JQuery/jquery-2.2.1.min.js"));

            bundles.Add(GenerateCDNScriptBundle("~/Resources/JavaScript/JQueryTouch", "/Content/Scripts/JQuery/jquery.ui.touch-punch.min.js", cdnRootAddress));

            bundles.Add(new ScriptBundle("~/Resources/JavaScript/Bootstrap/Plugins/Popover").Include("~/Content/Scripts/Bootstrap/initialise.js").Include("~/Content/Scripts/Bootstrap/bootstrap-confirmation.min.js"));

            bundles.Add(GenerateCDNScriptBundle("~/Resources/JavaScript/Bootstrap/Plugins/Popover/Editable", "/Content/Scripts/EditablePopover/editable.popover.js", cdnRootAddress));
           
            bundles.Add(new ScriptBundle("~/Resources/JavaScript/Plugins/ImageSelector").Include("~/Content/Scripts/ImageSelector/*.js"));

            bundles.Add(GenerateCDNScriptBundle("~/Resources/JavaScript/Plugins/FAQ", "/Content/Scripts/Components/component.expand.js", cdnRootAddress));

            bundles.Add(GenerateCDNScriptBundle("~/Resources/JavaScript/Plugins/Pagination", "/Content/Scripts/Framework/pagination.js", cdnRootAddress));

            bundles.Add(GenerateCDNScriptBundle("~/Resources/JavaScript/Plugins/Sliders", "/Content/Scripts/Administration/ThemeManager-Admin.js", cdnRootAddress));

            bundles.Add(new StyleBundle("~/Resources/CSS/Bootstrap", "https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css").Include("~/Content/Styles/Bootstrap/bootstrap.min.css", new CssRewriteUrlTransform()));         

            bundles.Add(GenerateCDNStyleBundle("~/Resources/CSS/JQuery/JQueryUI", "/Content/Styles/JQuery/jquery-ui.min.css", cdnRootAddress));

            bundles.Add(new StyleBundle("~/Resources/CSS/Framework").Include("~/Content/Styles/Framework/*.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Resources/CSS/Framework/Administration").Include("~/Content/Styles/Administration/*.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Resources/CSS/Framework/Editor").Include("~/Content/Styles/Administration/AppDrawers/*.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Resources/CSS/Plugins/Effects").Include("~/Content/Styles/Animate/animate.min.css").Include("~/Content/Styles/Hover/hover-min.css"));

            RegisterPlugins(bundles, cdnRootAddress);
        }

        private static void RegisterPlugins(BundleCollection bundles, string cdnRootAddress)
        {
            bundles.Add(new ScriptBundle("~/Plugins/Spectrum/Scripts").Include("~/Content/Plugins/Spectrum/spectrum.min.js").Include("~/Content/Plugins/Spectrum/initialise.js"));
            bundles.Add(GenerateCDNStyleBundle("~/Plugins/Spectrum/Styles", "/Content/Plugins/Spectrum/spectrum.css", cdnRootAddress));

            bundles.Add(new ScriptBundle("~/Plugins/C3Graphing/Scripts").Include("~/Content/Plugins/C3Graphing/c3.min.js").Include("~/Content/Plugins/C3Graphing/d3.min.js"));
            bundles.Add(GenerateCDNStyleBundle("~/Plugins/C3Graphing/Styles", "/Content/Plugins/C3Graphing/c3.css", cdnRootAddress));

            bundles.Add(GenerateCDNScriptBundle("~/Plugins/FontAwesome/Scripts", "/Content/Plugins/FontAwesome/fontawesome-iconpicker.min.js", cdnRootAddress));
            bundles.Add(GenerateCDNStyleBundle("~/Plugins/FontAwesome/Styles", "/Content/Plugins/FontAwesome/font-awesome.min.css", cdnRootAddress));
            bundles.Add(GenerateCDNStyleBundle("~/Plugins/FontAwesome/Styles/Picker", "/Content/Plugins/FontAwesome/fontawesome-iconpicker.min.css", cdnRootAddress));

            bundles.Add(new ScriptBundle("~/Plugins/FancyBox/Scripts").Include("~/Content/Plugins/FancyBox/jquery.fancybox.js").Include("~/Content/Plugins/FancyBox/jquery.fancybox-thumbs.js").Include("~/Content/Plugins/FancyBox/initialise.js"));
            bundles.Add(new StyleBundle("~/Plugins/FancyBox/Styles").Include("~/Content/Plugins/FancyBox/*.css", new CssRewriteUrlTransform()));
        }

        private static Bundle GenerateCDNScriptBundle(string bundleName, string filePath, string cdnRootAddress)
        {
            if (string.IsNullOrEmpty(cdnRootAddress))
            {
                return new ScriptBundle(bundleName).Include($"~{filePath}");
            }

            var cdnFilePath = $"{cdnRootAddress}{filePath}";

            return new ScriptBundle(bundleName, $"{cdnRootAddress}{filePath}").Include($"~{filePath}");
        }

        private static Bundle GenerateCDNStyleBundle(string bundleName, string filePath, string cdnRootAddress)
        {
            if (string.IsNullOrEmpty(cdnRootAddress))
            {
                return new StyleBundle(bundleName).Include($"~{filePath}");
            }

            var cdnFilePath = $"{cdnRootAddress}{filePath}";

            return new StyleBundle(bundleName, $"{cdnRootAddress}{filePath}").Include($"~{filePath}");
        }
    }
}