using System;
using Kushtrim.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace LibraryApp.Tests
{
	[TestFixture]
	public class BookstoreServiceTest
	{
		[Test]
		public void  Test_GetBooksAsync()
		{
			var actual = BookstoreService.GetBooksAsync().Result;
			var books = JsonConvert.DeserializeObject<Books>(actual);

			Assert.That(books, Is.InstanceOf(typeof(Books)), "books should be instance of Books");
		}
	}
}
