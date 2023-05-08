using System.Web.Optimization;

namespace AdminPortal
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/Content/assets/js/jquery-3.1.1.min.js",
                      "~/Scripts/vue.js",
                      "~/Scripts/axios.min.js",
                      "~/Content/assets/js/popper.min.js",
                      "~/Content/assets/js/bootstrap.js",
                      "~/Content/assets/js/inspinia.js",
                      "~/Content/assets/js/plugins/dataTables/datatables.min.js",
                      "~/Content/assets/js/plugins/sweetalert/sweetalert.min.js",
                      "~/Scripts/arrow-table.min.js",
                      "~/Scripts/v-money.js",
                      "~/Scripts/select2.js"

                    ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/assets/css/bootstrap.min.css",
                      "~/Content/assets/font-awesome/css/font-awesome.css",
                      "~/Content/assets/css/animate.css",
                      "~/Content/assets/css/style.css",
                      "~/Content/assets/css/plugins/dataTables/datatables.min.css",
                      "~/Content/assets/css/plugins/sweetalert/sweetalert.css",
                      "~/Content/assets/css/navstyles.css",
                      "~/Content/style.css",
                      "~/Content/select2.min.css"
                      ));
        }
    }
}