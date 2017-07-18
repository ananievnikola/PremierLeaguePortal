namespace PremierLeaguePortal
{
    using System.Web.Optimization;
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            //bundles.Add(new ScriptBundle("~/bundles/tinymce").Include(
            //            "~/Scripts/tinymce/tinymce.js"));
            //bundles.Add(new Bundle("~/bundles/tinymce")
            //     .Include("~/Scripts/tinymce/tinymce.min.js",
            //               "~/Scripts/tinymce/jquery.tinymce.min.js",
            //               "~/Scripts/tinymce/plugins/paste/plugin.min.js",
            //               "~/Scripts/tinymce/themes/modern/theme.min.js"));
            //bundles.Add(new ScriptBundle("~/bundles/tinymce").Include(
            //            "~/Scripts/tinymce/tinymce.js"));

            bundles.Add(new ScriptBundle("~/bundles/plp-scripts").Include(
                        "~/Scripts/plp-scripts.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Scripts/tinymce/skins").Include(
            //          "~/Scripts/tinymce/skins/content.inline.min.css",
            //          "~/Scripts/tinymce/skins/content.min.css",
            //          "~/Scripts/tinymce/skins/skin.min.css"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-solar.min.css",
                      "~/Content/site.css"));
        }
    }
}
