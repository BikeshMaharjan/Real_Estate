using System.Web;
using System.Web.Optimization;

namespace AngularMVC.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                 "~/Themes/site/js/jquery.js",
                "~/Themes/site/js/bootstrap.min.js",
                "~/Themes/site/js/jquery.scrollUp.min.js",
                "~/Themes/site/js/price-range.js",
                "~/Themes/site/js/jquery.prettyPhoto.js",
                "~/Themes/site/js/main.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Themes/site/css/bootstrap.min.css",
                      "~/Themes/site/css/font-awesome.min.css",
                      "~/Themes/site/css/prettyPhoto.css",
                      "~/Themes/site/css/price-range.css",
                      "~/Themes/site/css/animate.css",
                      "~/Themes/site/css/main.css",
                      "~/Themes/site/css/responsive.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(              
                        "~/Scripts/angular.js"
                         ));
        }
    }
}
