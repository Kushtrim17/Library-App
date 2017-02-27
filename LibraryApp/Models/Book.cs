using System;
using System.Collections.Generic;
using System.Web.ClientServices;
using System.Net;
using System.Web.Script.Serialization;
using System.Web;
using System.Diagnostics;
using System.IO;


namespace Kushtrim.Models
{
	public class Book
	{
		public string title;

		public string author;

		public string price;

		public string inStock;

		/**
		 * isSelectedBook - checks if the current book is part of the search
		 * if the title or the author mathces the searchTerm we return true
		 * @param searchTerm| string
		 * @return bool
		 */
		public bool isSelectedBook(string searchTerm)
		{
			if (author.ToLower().Contains(searchTerm.ToLower()) || title.ToLower().Contains(searchTerm.ToLower())) {
				return true;
			}

			return false;
		}
	}
}
