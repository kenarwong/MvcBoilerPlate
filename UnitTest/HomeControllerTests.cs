using System;
using System.Web.Mvc;
using MvcBoilerPlate.Controllers;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void TestView_Index_ShouldCreate()
        {
            var controller = new HomeController();
            var result = (ViewResult)controller.Index();
            Assert.IsNotNull(result);
        }
    }
}
