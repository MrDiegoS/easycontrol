﻿using System.Web;
using System.Web.Optimization;

namespace easycontrol
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

            bundles.Add(new ScriptBundle("~/bundles/home").Include(
                       "~/Scripts/Home/home.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
                       "~/Scripts/Areas/Admin/admin.js"));

            bundles.Add(new ScriptBundle("~/bundles/fator").Include(
                      "~/Scripts/Areas/Admin/fator.js"));

            bundles.Add(new ScriptBundle("~/bundles/usuario").Include(
                      "~/Scripts/Areas/Admin/usuario.js"));

            bundles.Add(new ScriptBundle("~/bundles/divida").Include(
                      "~/Scripts/Areas/Admin/divida.js"));

            bundles.Add(new ScriptBundle("~/bundles/user").Include(
                      "~/Scripts/Areas/user.js"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*",
                        "~/Scripts/moment.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
