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
		/**
		 * the title
		 */
		public string title;

		/**
		 * the author
		 */
		public string author;

		/**
		 * the price of the given book
		 */
		public string price;

		/**
		 *  how many books we have in stock
		 */
		public int inStock;

		/**
		 * variable to control the amount of times
		 * a book appears in the shopping list
		 */
		public int amount;

		/**
		 * isSelectedBook - checks if the current book is part of the search
		 * if the title or the author mathces the searchTerm we return true
		 * @param searchTerm| string
		 * @return bool
		 */
		public bool isSelectedBook(string searchTerm)
		{
			string sTerm = searchTerm.ToLower();
			string aName = author.ToLower();
			string bTitle = title.ToLower();
			string aNameAndTitle = aName + " " + bTitle;
			string bTitleaName = bTitle + " " + aName;

			//the assignment specification says
			//"As a user you should be able to search for books, the ..
			//search will be on both the book title and/or author "
			if (aName.Contains(sTerm) || bTitle.Contains(sTerm) || 
			    aNameAndTitle.Contains(sTerm) || bTitleaName.Contains(sTerm)) {
				return true;
			}

			return false;
		}
	}
}
