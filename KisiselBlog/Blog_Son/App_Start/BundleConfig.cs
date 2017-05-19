using System.Web;
using System.Web.Optimization;

namespace Blog_Son
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                         "~/Scripts/jquery-{version}.js",
                         "~/Scripts/js/owl.carousel.min.js",
                         "~/Scripts/js/wow.min.js",
                         "~/Scripts/js/slider.js",
                         "~/Scripts/js/jquery.fancybox.js",
                         "~/Scripts/js/main.js",
                         "~/Scripts/js/kullaniciGirisi.js"
                         ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/ckeditor").Include(
                       "~/ckeditor/ckeditor.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                         "~/Scripts/js/vendor/modernizr-2.6.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/js/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/ionicons.min.css",
                      "~/Content/css/animate.css",
                      "~/Content/css/slider.css",
                      "~/Content/css/owl.carousel.css",
                      "~/Content/css/owl.theme.css",
                      "~/Content/css/jquery.fancybox.css",
                      "~/Content/css/main.css",
                      "~/Content/css/responsive.css",
                      "~/Content/css/etiket.css",
                      "~/Content/css/adminPaneli.css",
                      "~/Content/css/kullaniciGirisi.css"
                     ));
        }
    }
}
