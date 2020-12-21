using System.Web;
using System.Web.Optimization;

namespace SignupWithLogin
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/jQuery").Include("~/Scripts/jquery-2.2.4.js"));
            bundles.Add(new ScriptBundle("~/jQueryValidate").Include("~/Scripts/jquery.validate.js"));
            bundles.Add(new ScriptBundle("~/Unobtrusive").Include("~/Scripts/jquery.validate.unobtrusive.js"));


        }
    }
}