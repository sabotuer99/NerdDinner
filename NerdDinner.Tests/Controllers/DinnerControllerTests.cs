using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NerdDinner.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using NerdDinner.Model;
using System.Linq;

namespace NerdDinner.Tests.Controllers
{
    [TestClass]
    public class DinnerControllerTests
    {
        [TestMethod]
        public void Index_Should_Return_1_Or_More_Dinners()
        {
            //Arrange
            var controller = new DinnerController(new Fakes.FakeDinnerRepository());

            //Act
            var result = controller.Index() as ViewResult;

            //Assert
            //Had to change this code a bit to account for lazy loading
            //http://stackoverflow.com/questions/3584915/viewresult-returns-no-data
            var data = ((EnumerableQuery<Dinner>)result.ViewData.Model).ToList();
            Assert.IsTrue(data.Count > 0);
        }

        [TestMethod]
        public void Index_Should_Return_Dinners_For_Today_Or_Later()
        {
            //Arrange
            var controller = new DinnerController(new Fakes.FakeDinnerRepository());

            //Act
            var result = controller.Index() as ViewResult;

            //Assert
            var data = ((EnumerableQuery<Dinner>)result.ViewData.Model).ToList();
            Assert.IsFalse(data.Where(x => x.EventDate < DateTime.Now).Count() > 0);
        }
    }
}
