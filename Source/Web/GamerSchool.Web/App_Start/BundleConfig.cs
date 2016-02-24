namespace GamerSchool.Web
{
    using System.Web.Optimization;

    public static class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.2.0.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryajax").Include(
                      "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                "~/Scripts/Kendo/kendo.all.min.js",
                "~/Scripts/Kendo/kendo.aspnetmvc.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"
                      /*"~/Scripts/respond.js"*/));

            bundles.Add(new ScriptBundle("~/bundles/public").Include(
                    "~/Scripts/common/vendor/vendor.js",
                    "~/Scripts/public/variables.js",
                    "~/Scripts/common/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                   "~/Content/theme/bootstrap.min.css",
                   "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/public").Include(
                    "~/Content/public/style.css",
                    "~/Content/public/color.css",
                    "~/Content/public/title-size.css",
                    "~/Content/public/custom.css"
                    ));

            bundles.Add(new StyleBundle("~/Content/kendo-css").Include(
                  "~/Content/Kendo/kendo.common.min.css",
                  "~/Content/Kendo/kendo.material.min.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}
