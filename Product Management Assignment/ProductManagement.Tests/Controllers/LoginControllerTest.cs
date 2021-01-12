using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManagement.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProductManagement.Tests.Controllers
{
    [TestClass]
    public class LoginControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            LoginController controller = new LoginController();
            //Act
            ActionResult result = controller.Index();
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Logout()
        {
            //Arrange
            LoginController controller = new LoginController();
            //Act
            ActionResult result = controller.Index();

            //Assert
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void Reset()
        {
            //Arrange
            LoginController controller = new LoginController();
            //Act
            ActionResult result = controller.Index();

            //Assert
            Assert.IsNotNull(result);

        }


    }
}
