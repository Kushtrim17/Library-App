using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kushtrim.Models;

namespace LibraryApp.Controllers
{
    public class CheckoutController : Controller
    {
        public ActionResult Index()
        {
			var books = SessionManager.Get<Books>(SessionManager.SHOPPING_CARD);

			if (books.getAllBooks().Count() > 0) {
				//if we have items in the shopping card
				return View(books);
			}
			else {
				//if we dont have books we redirect back to the begining
				return new RedirectResult("/");
			}

        }

		public ActionResult Delete()
		{
			SessionManager.DeleteSession();
			return new RedirectResult("/");
		}

		public ActionResult PaymentComplete()
		{
			//we empty out the shopping card and we assume
			//that the client payed for the books
			SessionManager.DeleteSession();
			return View();
		}

		public ActionResult RemoveItemFromCard(string bookTitle, string bookAuthor, string bookPrice)
		{
			SessionManager.Remove(bookTitle, bookAuthor, Double.Parse(bookPrice));
			return new RedirectResult("/Checkout");
		}
    }
}
