using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Kushtrim.Models;
using Newtonsoft.Json;

namespace LibraryApp.Controllers
{
	public class HomeController : Controller
	{

		public ActionResult Index(string searchTerm = "")
		{
			var json = BookstoreService.GetBooksAsync().Result;
			var books = JsonConvert.DeserializeObject<Books>(json);

			//if the search is empty then we dont filter
			if (searchTerm.Length > 0) {
				//after we got all the books from the API we filter out the ones 
				//that dont match the searched term
				books.filterBooks(searchTerm);
			}

			return View(books);
		}

		public RedirectResult AddToCard(string bookTitle, string bookAuthor, string bookPrice, int bookinStock)
		{
			//prepare the book object
			Book book = new Book();
			book.title = bookTitle;
			book.author = bookAuthor;
			book.price = bookPrice;
			book.inStock = bookinStock;

			SessionManager.Save<Book>(book);

			return new RedirectResult("/Home/AddedToCard?title=" + bookTitle);
		}

		public ActionResult OutOfStock()
		{
			return View();
		}

		public ActionResult AddedToCard()
		{
			return View();
		}
	}
}
