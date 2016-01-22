using System.Web;
using System.Web.Optimization;

namespace MvcBoilerPlate
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            // Javascript bundles
            bundles.Add(new ScriptBundle("~/bundles/libs").Include(
                      "~/Scripts/jquery-{version}.js",
                      "~/Scripts/modernizr-*",
                      "~/Scripts/bootstrap.js"
                      ));

            // CSS bundles
            StyleBundle cssBundle = new StyleBundle("~/Content/pkgs");
            cssBundle.Include("~/Content/bootstrap/bootstrap.css", new CssRewriteUrlTransform());
            bundles.Add(cssBundle);

            bundles.Add(new StyleBundle("~/Content/style").Include(
                        "~/Content/site.css"
                		));
        }
    }
}
