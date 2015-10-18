using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Newtonsoft.Json.Serialization;

namespace BlochsTech.Website.Base
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { url = new LowercaseRouteConstraint() }
            );

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //jsonFormatter.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            jsonFormatter.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";

            // Remove xml formatters to enable xml by default.
            // http://stackoverflow.com/a/9979861
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }

        private class LowercaseRouteConstraint : IRouteConstraint
        {
            public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
            {
                try
                {
                    string path = httpContext.Request.Url.AbsolutePath;
                    return path.Equals(path.ToLowerInvariant(), StringComparison.InvariantCulture);
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}