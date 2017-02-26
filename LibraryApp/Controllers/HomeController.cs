using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Kushtrim.Models;
using Newtonsoft.Json;

namespace LibraryApp.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var data = new apiData();
			var jsonBooks = data.getBooksFromAPI();
			var books = JsonConvert.DeserializeObject<Books>(jsonBooks);

			return View(books);
		}
	}
}
