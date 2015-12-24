using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Sample
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			//	Enable some "prettier" formatted json output - useful in browsers and some testing
			var jsonSettings = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
			jsonSettings.SerializerSettings.Formatting = Formatting.Indented;

			//	Note Angular and other javascript based code needs camel case as javascript is case sensitive
			jsonSettings.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

		}
	}
}
