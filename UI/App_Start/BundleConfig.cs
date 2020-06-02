using System.Web;
using System.Web.Optimization;

namespace UI
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/Vendor/jquery-1.12.4.min.js",
                      "~/Scripts/Vendor/modernizr-3.5.0.min.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/Js/animated.headline.js",
                      "~/Scripts/Js/aos.js",
                      "~/Scripts/Js/cells-by-column.js",
                      "~/Scripts/Js/contact.js",
                      "~/Scripts/Js/gmaps.min.js",
                      "~/Scripts/Js/jquery.ajaxchimp.min.js",
                      "~/Scripts/Js/jquery.counterup.min.js",
                      "~/Scripts/Js/jquery.downCount.js",
                      "~/Scripts/Js/jquery.easing.min.js",
                      "~/Scripts/Js/jquery.form.js",
                      "~/Scripts/Js/jquery.magnific-popup.js",
                      "~/Scripts/Js/jquery.nice-select.min.js",
                      "~/Scripts/Js/jquery.paroller.min.js",
                      "~/Scripts/Js/jquery.scrollUp.min.js",
                      "~/Scripts/Js/jquery.slicknav.min.js",
                      "~/Scripts/Js/jquery.sticky.js",
                      "~/Scripts/Js/jquery.validate.min.js",
                      "~/Scripts/Js/lightslider.min.js",
                      "~/Scripts/Js/mail-script.js",
                      "~/Scripts/Js/main.js",
                      "~/Scripts/Js/mixitup.min .js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/css/all.css",
                      "~/Content/css/animate.min.css",
                      "~/Content/css/aos.css",
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/fiaticon.css",
                      "~/Content/css/fontawesome-all.min.css",
                      "~/Content/css/lightslider.css",
                      "~/Content/css/magnific-popup.css",
                      "~/Content/css/nice-select.css",
                      "~/Content/css/owl.carousel.css",
                      "~/Content/css/price_rangs.css",
                      "~/Content/css/slick-theme.min.css",
                      "~/Content/css/slick.css",
                      "~/Content/css/slicknav.css",
                      "~/Content/css/style.css",
                      "~/Content/css/swiper.css",
                      "~/Content/css/themify-icons.css",
                      "~/Content/Site.css"));
        }
    }
}
