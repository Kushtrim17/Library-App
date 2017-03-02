using System;
using Kushtrim.Models;
using NUnit.Framework;

namespace LibraryApp.Tests
{
	[TestFixture]
	public class BooksTest
	{
		[Test]
		public void Test_bookExistsInShoppingCard()
		{
			//Arrange
			Book book1 = new Book();
			book1.title = "Book Title";
			book1.author = "Book Author";
			book1.price = "300";
			book1.inStock = 10;

			Book book2 = new Book();
			book2.title = "Book Title2";
			book2.author = "Book Author2";
			book2.price = "400";
			book2.inStock = 30;

			Books books = new Books();

			//Assert
			Assert.AreEqual(books.addBookToCard(book1), 1); //the book1 exists just once
			Assert.AreEqual(books.addBookToCard(book1), 2); //the book1 exists twice
			Assert.AreEqual(books.addBookToCard(book2), 1); //the book2 exists just once
		}

		[Test]
		public void Test_removeBook()
		{
			//Arrange
			Book book1 = new Book();
			book1.title = "Book Title";
			book1.author = "Book Author";
			book1.price = "300";
			book1.inStock = 10;

			Book book2 = new Book();
			book2.title = "Book Title2";
			book2.author = "Book Author2";
			book2.price = "400";
			book2.inStock = 30;

			//Act
			Books books = new Books();
			books.addBookToCard(book1);
			books.addBookToCard(book2);

			//Assert
			Assert.AreEqual(books.removeBook(book1.title, book1.author, Double.Parse(book1.price)), 1, "Index should be 1 for book1 ");
			//since the first element is removed then it is only one left so it should be 1 again
			Assert.AreEqual(books.removeBook(book2.title, book2.author, Double.Parse(book2.price)), 1, "Index should be 1 for book2 ");
		}
	}
}
