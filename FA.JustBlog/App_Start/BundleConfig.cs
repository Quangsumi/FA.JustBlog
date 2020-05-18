using System.Web.Optimization;

namespace FA.JustBlog
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Content/AdminLTE/bower_components/jquery/dist/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/AdminLTE/bower_components/bootstrap/dist/js/bootstrap.min.js",
                      "~/Content/AdminLTE/dist/js/adminlte.min.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/AdminLTE/bower_components/bootstrap/dist/css/bootstrap.min.css",
                      "~/Content/AdminLTE/bower_components/font-awesome/css/font-awesome.min.css",
                      "~/Content/AdminLTE/bower_components/Ionicons/css/ionicons.min.css",
                      "~/Content/AdminLTE/bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css",
                      "~/Content/AdminLTE/dist/css/AdminLTE.min.css",
                      "~/Content/AdminLTE/dist/css/skins/_all-skins.min.css",
                      "~/Content/site.css"
                      ));

            bundles.Add(new ScriptBundle("~/Content/CleanBlogScript").Include(
                        "~/Content/CleanBlog/vendor/jquery/jquery.min.js",
                        "~/Content/CleanBlog/vendor/bootstrap/js/bootstrap.bundle.min.js",
                        "~/Content/CleanBlog/js/clean-blog.min.js"
                        ));

            bundles.Add(new StyleBundle("~/Content/CleanBlogCss").Include(
                      "~/Content/CleanBlog/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/CleanBlog/vendor/fontawesome-free/css/all.min.css",
                      "~/Content/CleanBlog/css/clean-blog.min.css",
                      "~/Content/site.css"
                      ));
        }
    }
}
