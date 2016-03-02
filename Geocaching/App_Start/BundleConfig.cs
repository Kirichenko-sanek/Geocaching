using System.Web;
using System.Web.Optimization;

namespace Geocaching
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

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(

                       "~/Scripts/angular.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/jquery-1.10.2.min.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/slick.js",
                      "~/Scripts/jquery.mixitup.js",
                      "~/Scripts/jquery.fancybox.pack.js",
                      "~/Scripts/waypoints.js",
                      "~/Scripts/jquery.counterup.js",
                      "~/Scripts/wow.js",
                      "~/Scripts/bootstrap-progressbar.js",
                      "~/Scripts/custom.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/font-awesome.css",
                      "~/Content/bootstrap.css",
                      "~/Content/slick.css",
                      "~/Content/jquery.fancybox.css",
                      "~/Content/animate.css",
                      "~/Content/bootstrap-progressbar-3.3.4.css",
                      "~/Content/fountain-blue-theme.css",
                      "~/Content/style.css"));
        }
    }
}
