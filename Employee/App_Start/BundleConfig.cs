using System.Web;
using System.Web.Optimization;

namespace Employee
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/bundles/js").Include(
                      "~/Libs/Bootstrap/js/bootstrap.min.js",
                      "~/Libs/Jquery/jquery-3.7.1.min.js",
                      "~/Libs/Jquery/moment.min.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Libs/Bootstrap/css/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/bundles/font").Include(
            "~/Libs/Font/css/all.min.css"));

        }
    }
}
