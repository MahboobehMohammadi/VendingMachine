using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VendingMachine.Controllers;
using VendingMachine.DTO;
using VendingMachine.Models;
using VendingMachine.Services;
using System.Linq;

namespace VendingMachine.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        Mock<IBeverageService> _vendingMachineService;
        public HomeControllerTest()
        {
            _vendingMachineService = new Mock<IBeverageService>();
        }
        [TestMethod]
        public void Index()
        {
            //Arrange
            HomeController controller = new HomeController(_vendingMachineService.Object);

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Should_Return_All_Beverages_In_DB()
        {
            //Arrange
            var expectedAllBeverages = new List<BeverageListDto>(){
            new BeverageListDto
              {
                  Id= 1,
                  Name = "Hot Chocolate"
              },
             new BeverageListDto
              {
                  Id=2,
                  Name = "White Coffee with 1 sugar"
              }
            };
            _vendingMachineService.Setup(x => x.GetAll()).Returns(expectedAllBeverages);

            //Act
            var result = new HomeController(_vendingMachineService.Object).GetAll() as JsonResult;

            //Assert
            var data = result.Data;
            var beverages = data.GetType().GetProperty("beverages").GetValue(data, null) as List<BeverageListDto>;

            Assert.AreEqual(2, beverages.Count());
            Assert.AreEqual(beverages[0].Name, "Hot Chocolate");
            Assert.AreEqual(beverages[1].Name, "White Coffee with 1 sugar"); 

        }
        [TestMethod]
        public void Should_Return_Beverage_Recipe()
        {
            //Arrange
            var expectedAllBeverages = new List<BeverageRecipeDto>(){
                                    new BeverageRecipeDto{Title="Boil water" },
                                    new BeverageRecipeDto{Title="Add drinking chocolate to cup" },
                                    new BeverageRecipeDto{Title="Add water" }
            };
            _vendingMachineService.Setup(x => x.GetRecipe(1)).Returns(expectedAllBeverages);

            //Act
            var result = new HomeController(_vendingMachineService.Object).GetRecipe(1) as JsonResult;

            //Assert
            var data = result.Data;
            var recipe = data.GetType().GetProperty("recipe").GetValue(data, null) as List<BeverageRecipeDto>;

            Assert.AreEqual(3, recipe.Count());
            Assert.AreEqual(recipe[0].Title, "Boil water");
            Assert.AreEqual(recipe[1].Title, "Add drinking chocolate to cup");

        }
    }
}
