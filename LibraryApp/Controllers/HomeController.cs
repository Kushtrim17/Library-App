﻿using System;
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
		public ActionResult Index(string searchTerm = "")
		{
			var data = new apiData();
			var jsonBooks = data.getBooksFromAPI();
			var books = JsonConvert.DeserializeObject<Books>(jsonBooks);

			//if the search is empty then we dont filter
			if (searchTerm.Length > 0)
			{
				//after we got all the books from the API we filter out the ones 
				//that dont match the searched term
				foreach (Book book in books.getAllBooks().ToList())
				{
					if (!book.isSelectedBook(searchTerm)) {
						books.removeBook(book);
					}
				}
			}

			return View(books);
		}

		public RedirectResult AddToCard(string bookTitle, string bookAuthor, int bookinStock)
		{
			if (bookinStock > 1) {
				//we can buy the book 
				return new RedirectResult("/Home/AddedToCard?title=" + bookTitle);
			}
			else {
				//we should redirect to the view that handles
				return new RedirectResult("/Home/OutOfStock?title=" + bookTitle);
			}

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
