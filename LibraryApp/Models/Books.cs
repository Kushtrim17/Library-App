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
		 * constructor
		 */
		public Books()
		{
			books = new List<Book>();
		}

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
		public void removeBook(string title, string author, double price)
		{
			for (int i = books.Count - 1; i >= 0; i--)
			{
				if (books[i].title == title && books[i].author == author && Double.Parse(books[i].price) == price) {
					if (books[i].amount > 1) {
						//if the same book exists in more quantities in the shopping card
						//we remove one book at the time
						books[i].amount -= 1;
					}
					else {
						//if there is one book of this kind in shopping card 
						//we delete it all
						books.RemoveAt(i);
					}
				}
			}
		}

		/**
		 * addBook
		 * @param book | Book
		 */
		public void addBookToCard(Book book)
		{
			int index = bookExistsInShoppingCard(book);
			if (index == -1) {
				//book doesnt exist in shopping card
				book.amount = 1;
				books.Add(book);
			}
			else {
				//book exists so update it's amount
				books[index].amount += 1;
			}
		}

		/**
		 * filterBooks - keeps only the books that match the search term
		 * @param searchTerm | string
		 * @return books | IList<Book>
		 */
		public Books filterBooks(string searchTerm)
		{
			for (int i = books.Count - 1; i >= 0; i--) {
				if (!books[i].isSelectedBook(searchTerm)) {
					books.RemoveAt(i);
				}
			}

			return this;
		}

		/**
		 * bookExistsInShoppingcard - checks if the book is already once in the shopping card
		 * if the book is in the shopping card we increase the amount by 1
		 * @param book | Book
		 * @return i | int - the index of the book or -1 if the book doesn't exist in the shopping card
		 */
		private int bookExistsInShoppingCard(Book book)
		{
			for (var i = 0; i < getAllBooks().Count; i++) {
				if (books[i].title == book.title && books[i].author == book.author && books[i].price == book.price) {
					//we have to rely on the combination of title author and price to differenciate
					//between books since they don't have an id 
					return i;
				}
			}

			return -1;
		}
	}
}
