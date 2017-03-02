﻿using System.Web.Mvc;
using System.Web.Routing;

namespace LibraryApp
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);

			routes.MapRoute(
				name: "Checkout",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Checkout", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
