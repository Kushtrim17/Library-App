using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Kushtrim.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace LibraryApp
{
	public class BookstoreService
	{
		/**
		 *  the API endpoint
		 */
		private const string API_URL = "http://www.contribe.se/arbetsprov-net/books.json";

		/**
		 *  GetBooksAsync - gets the books from the API asynchronously
		 *  @return Task<string>
		 */
		public static async Task<string> GetBooksAsync()
		{
			try {
				HttpClient client = new HttpClient();
				string json = await client.GetStringAsync(API_URL);

				return json;
			}
			catch (HttpRequestException ex) {
				Console.WriteLine(ex.Message);
				return ex.Message;
			}

		}
	}
}
