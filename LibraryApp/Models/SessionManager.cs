using System;
using System.Collections.Generic;
using System.Web;
using Kushtrim.Models;

namespace LibraryApp
{
	/**
	 *  SessionManager is a session wrapper
	 */
	public class SessionManager
	{
		/**
		 * the name of the key in which we store the shopping card items
		 */
		public const string SHOPPING_CARD = "shoppingCard";

		/**
		 * the name of the key in which we store the number of items
		 */
		public const string NR_OF_ITEMS   = "nrOfItems";

		/**
		 * Get<T> - gets the specified data from the session
		 * key | String - the key of the data we want to access from the session
		 */
		public static T Get<T>(string key)
		{
			object sessionObject = HttpContext.Current.Session[key];
			if (sessionObject == null) {
				return default(T);
			}

			return (T)HttpContext.Current.Session[key];
		}

		/**
		 * Save - stores a book in the session i.e. shopping card
		 * @param book | Book
		 */
		public static void Save<T>(Book book)
		{
			if (HttpContext.Current.Session[SHOPPING_CARD] == null) {
				//if the session hasnt been created we create it
				Books books = new Books();
				books.addBookToCard(book);
				HttpContext.Current.Session[SHOPPING_CARD] = books;
				HttpContext.Current.Session[NR_OF_ITEMS] = 1;
			}
			else {
				var books = Get<Books>(SHOPPING_CARD);
				books.addBookToCard(book);
				HttpContext.Current.Session[NR_OF_ITEMS] = (int)HttpContext.Current.Session[NR_OF_ITEMS] + 1;
			}
		}

		/**
		 * Remove - removes the given item from the session
		 * @param bookTitle | string
		 * @param bookAuthor | string
		 * @param bookPrice | double
		 */
		public static void Remove(string bookTitle, string bookAuthor, double bookPrice)
		{
			var books = Get<Books>(SHOPPING_CARD);
			books.removeBook(bookTitle, bookAuthor, bookPrice);
			HttpContext.Current.Session[NR_OF_ITEMS] = (int)HttpContext.Current.Session[NR_OF_ITEMS] - 1;
		}

		/**
		 * DeleteSession
		 */
		public static void DeleteSession()
		{
			HttpContext.Current.Session[SHOPPING_CARD] = null;
			HttpContext.Current.Session[NR_OF_ITEMS] = null;
		}
	}
}
