﻿using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Portal.CMS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error()
        {
            if (System.Configuration.ConfigurationManager.AppSettings["CustomErrorPage"] == "true")
            {
                Response.Redirect("~/Home/Error");
            }
        }
    }
}