using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OShopping.Controllers;
using OShopping.Models;
using System.Collections.Generic;

namespace OShopping.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
             

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Products()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Products() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }        
    }
}
