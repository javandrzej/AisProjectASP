using System.Web.Mvc;
using System.Web.Routing;

namespace AisProjectASP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.MapPageRoute("StartHtml", "StartPage", "~/Message/Index.html");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Message", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
