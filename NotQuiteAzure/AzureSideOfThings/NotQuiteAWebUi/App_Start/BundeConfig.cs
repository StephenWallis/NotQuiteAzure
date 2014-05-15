using System.Web.Optimization;

namespace NotQuiteAWebUi.App_Start
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Assests/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Assests/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Assests/Scripts/jquery.unobtrusive*",
                        "~/Assests/Scripts/jquery.validate*"));



            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                    "~/Assests/Scripts/bootstrap.js"
                ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Assests/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Assests/css").Include("~/Assests/css/site.css"));

            bundles.Add(new StyleBundle("~/Assests/themes/base/css").Include(
                        "~/Assests/themes/base/jquery.ui.core.css",
                        "~/Assests/themes/base/jquery.ui.resizable.css",
                        "~/Assests/themes/base/jquery.ui.selectable.css",
                        "~/Assests/themes/base/jquery.ui.accordion.css",
                        "~/Assests/themes/base/jquery.ui.autocomplete.css",
                        "~/Assests/themes/base/jquery.ui.button.css",
                        "~/Assests/themes/base/jquery.ui.dialog.css",
                        "~/Assests/themes/base/jquery.ui.slider.css",
                        "~/Assests/themes/base/jquery.ui.tabs.css",
                        "~/Assests/themes/base/jquery.ui.datepicker.css",
                        "~/Assests/themes/base/jquery.ui.progressbar.css",
                        "~/Assests/themes/base/jquery.ui.theme.css"));


            bundles.Add(new StyleBundle("~/Assests/css").Include(
                "~/Assests/css/bootstrap.css",
                "~/Assests/css/bootstrap-responsive.css"
                ));


        }
    }
}