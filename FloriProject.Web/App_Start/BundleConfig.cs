using System.Web;
using System.Web.Optimization;

namespace FloriProject.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // готово к выпуску, используйте средство сборки по адресу https://modernizr.com, чтобы выбрать только необходимые тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/site.css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/navbar.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/bouquet.css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/navbar.css",
                      "~/Content/bouquet.css"));
            bundles.Add(new StyleBundle("~/Content/composition.css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/navbar.css",
                      "~/Content/composition.css"));
            bundles.Add(new StyleBundle("~/Content/contact.css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/navbar.css",
                      "~/Content/contact.css"));
            bundles.Add(new StyleBundle("~/Content/admin.css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/addbouquets.css",
                      "~/Content/admin.css"));
            bundles.Add(new StyleBundle("~/Content/login.css").Include(
               "~/Content/bootstrap.css",
               "~/Content/addbouquets.css",
               "~/Content/login.css"));
        }
    }
}
