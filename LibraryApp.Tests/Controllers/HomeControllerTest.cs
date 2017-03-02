using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using LibraryApp;
using LibraryApp.Controllers;
using Kushtrim.Models;

namespace LibraryApp.Tests
{
	[TestFixture]
	public class HomeControllerTest
	{
		[Test]
		public void Index()
		{
			// Arrange
			var controller = new HomeController();

			//Act
			ViewResult result = controller.Index() as ViewResult;

			//Assert
			Assert.IsNotNull(result);
			var model = result.ViewData.Model;
		}
	}
}
