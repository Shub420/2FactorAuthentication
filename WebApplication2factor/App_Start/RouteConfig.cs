using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication2factor
{       
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

        //    routes.MapRoute(
        //    name: "AllEmployees",
        //    url: "Employees",
        //    defaults: new { controller = "Employee", action = "Index" }
        //);

        //    routes.MapRoute(
        //   name: "Employee",
        //   url: "Employees/{id}",
        //   defaults: new { controller = "Employee", action = "Edit" }
        //);
        //    routes.MapRoute(
        //    name: "EmployeeDetails",
        //    url: "Employees/{id}/Details",
        //    defaults: new { controller = "Employee", action = "Details" }
        //    constraints: new {id=@"\d+"}
        //);


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
