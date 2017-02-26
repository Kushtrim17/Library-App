using System;
using System.Collections.Generic;
using Kushtrim.Models;

namespace Kushtrim.Models
{
	public class Books
	{
		/**
		 * books - a list that holds instances of the class Book
		 */
		public IList<Book> books;

		/**
		 * getAllBooks
		 * @return books| IList
		 */
		public IList<Book> getAllBooks()
		{
			return books;
		}

		/**
		 * removeBook - removes the given book from the book list
		 * @param book|Book
		 */
		public void removeBook(Book book)
		{
			books.Remove(book);
		}
	}
}
