using System.Web.Optimization;

namespace ACMS
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/mContent/css").Include(
                "~/Content/css/bootstrapmin.css",
                "~/Content/css/bootstrap-rtlmin.css",
                "~/Content/css/font-awesomemin.css",
                "~/Content/css/style.css",
                "~/Content/css/owlcarousel.css"));
            bundles.Add(new ScriptBundle("~/mScripts").Include(
                "~/Content/js/bootstrapmin.js", 
                "~/ Content /js/owlcarousel.js",
                "~/Content/js/script.js"


                ));

        }
    }
}
