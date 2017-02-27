using System;
using System.Net;

namespace LibraryApp
{
	public class apiData
	{
		/**
		 *  the API endpoint
		 */
		private string API_URL = "http://www.contribe.se/arbetsprov-net/books.json";

		public apiData() {
			
		}

		/**
		 * getBooksFromAPI - reads the data from the remote API
		 * @return json - the books in json format
		 */
		public string getBooksFromAPI()
		{
			try {
				var webClient = new WebClient();
				Console.WriteLine("correct");
				return webClient.DownloadString(API_URL);
			}
			catch (Exception ex) {
				
				Console.WriteLine("THINGS WENT WRONG..........::" + ex);
				return "error :" + ex;
			}
		}
	}
}
