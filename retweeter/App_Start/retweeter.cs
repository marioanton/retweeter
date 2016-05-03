using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Threading.Tasks;
using LinqToTwitter;
using System.Configuration;

namespace retweeter
{
    public static class retweeter
    {
       

        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "retweeter/{controller}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
