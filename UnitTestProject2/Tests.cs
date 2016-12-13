
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookTable.Models.Abstract;
using Moq;
using BookTable.Controllers;
using BookTable.Models;
using System;
using System.Web.Mvc;

namespace BookTableTest
{
    [TestClass]
    public class BookingControllerTest
    {
        [TestMethod]
        public void InsertRestaurantTest()

        {
            var mockRepoRestaurant = new Mock<IRestaurantInterface>();
            RestaurantsController controller = new RestaurantsController(mockRepoRestaurant.Object);
            Restaurant restaurant = new Restaurant() { Cvr = 4, Name = "Restaurant", Address = "Address1", Phone = 1122, Email = "klucinka007@gmail.com", Description = "afsf" };


            controller.Create(restaurant);

            mockRepoRestaurant.Verify(repo => repo.Insert(restaurant));
        }

    }
}

    [TestClass]
    public class HomeControllerIsNotNullTest
    {
    [TestMethod]
    public void Index()
    {
        // Arrange
        HomeController controller = new HomeController();

        // Act
        ViewResult result = controller.Index() as ViewResult;

        // Assert
        Assert.IsNotNull(result);
    }

    [TestClass]
    public class HomeControllerAboutTest
    {
        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }
    }

    [TestClass]
    public class HomeControllerContactTest
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
    }
}





