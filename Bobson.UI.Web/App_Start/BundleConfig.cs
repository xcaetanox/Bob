using System.Web.Optimization;

namespace Bobson.UI.Web
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
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));


            bundles.Add(new ScriptBundle("~/bundles/tinymce").Include(
                      "~/Scripts/tinymce/tinymce.js"));



            bundles.Add(new ScriptBundle("~/bundles/wysiwyg").Include(
                      "~/Scripts/codemirror-3.01/codemirror.js",
                      "~/Scripts/codemirror-3.01/mode/xml.js",
                      "~/Scripts/codemirror-2.37/lib/util/formatting.js",
                      "~/Scripts/summernote.js",
                      "~/Scripts/summernote-pt-BR.js"));


            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                      "~/Scripts/jquery.dataTables.js",
                        "~/Scripts/DataTables/extensions/Buttons/js/dataTables.buttons.js",
                        "~/Scripts/DataTables/extensions/Buttons/js/buttons.flash.js",
                        "~/Scripts/jszip.js",
                        "~/Scripts/pdfmake/pdfmake.min.js",
                        "~/Scripts/pdfmake/vfs_fonts.js",
                        "~/Scripts/DataTables/extensions/Buttons/js/buttons.html5.js",
                        "~/Scripts/DataTables/extensions/Buttons/js/buttons.print.js",
                      "~/Scripts/dataTables.bootstrap.js",
                      "~/Scripts/DataTables/extensions/Responsive/js/dataTables.responsive.js",
                      "~/Scripts/DataTables/extensions/Responsive/js/responsive.bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/wizard").Include(
                    "~/Scripts/jquery.bootstrap.wizard.js",
                    "~/Scripts/gsdk-bootstrap-wizard.js"));


            bundles.Add(new StyleBundle("~/Content/summernotecss").Include(
                "~/Content/codemirror-3.01/codemirror.css",
                "~/Content/codemirror-3.0/theme/monokai.css",
                "~/Content/font-awesome.css",
                "~/Content/summernote.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/DataTables/extensions/Buttons/css/buttons.dataTables.css",
                      "~/Content/jquery.dataTables.css",
                      "~/Content/jquery.dataTables_themeroller.css",
                      "~/Content/dataTables.bootstrap.css",
                      "~/Content/DataTables/extensions/Responsive/css/responsive.bootstrap.css",
                      "~/Content/font-awesome.css",
                      "~/Content/site.css"));
        }
    }
}