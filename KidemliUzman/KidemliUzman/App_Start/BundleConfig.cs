using System.Web;
using System.Web.Optimization;

namespace KidemliUzman
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",                     
                        "~/Content/vendor/scrollreveal/scrollreveal.min.js",
                        "~/Content/vendor/magnific-popup/jquery.magnific-popup.min.js",
                        "~/Scripts/js/creative.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"
));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/vendor/font-awesome/css/font-awesome.min.css",
                      "~/Content/vendor/magnific-popup/magnific-popup.css",
                      "~/Content/css/creative.min.css",
                      "~/Content/css/LoginAndRegister.css"
                      ));
        }
    }
}
