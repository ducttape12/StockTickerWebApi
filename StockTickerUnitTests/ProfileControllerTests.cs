using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockTicker.Controllers;
using StockTicker.FinancialModelingPrep;
using StockTicker.Interfaces;

namespace StockTickerUnitTests
{
    [TestClass]
    public class ProfileControllerTests
    {
        [TestMethod]
        public void Get__GivenValidId_WhenCompanyNull_ThenReturnsNotFound()
        {
            // Arrange
            var mockFinancialModelingPrepClient = new Mock<IFinancialModelingPrepClient>();
            mockFinancialModelingPrepClient.Setup(x => x.CompanyProfile(It.IsAny<string>())).Returns((CompanyModel)null);

            var profileController = new ProfileController(mockFinancialModelingPrepClient.Object);

            // Act
            var result = profileController.Get(string.Empty);

            // Assert
            var notFound = result.Result as NotFoundResult;
            Assert.IsNotNull(notFound);
        }

        [TestMethod]
        public void Get__GivenValidId_WhenCompanySymbolNull_ThenReturnsNotFound()
        {
            // Arrange
            var mockFinancialModelingPrepClient = new Mock<IFinancialModelingPrepClient>();
            var companyModel = new CompanyModel();
            mockFinancialModelingPrepClient.Setup(x => x.CompanyProfile(It.IsAny<string>())).Returns(companyModel);

            var profileController = new ProfileController(mockFinancialModelingPrepClient.Object);

            // Act
            var result = profileController.Get(string.Empty);

            // Assert
            var notFound = result.Result as NotFoundResult;
            Assert.IsNotNull(notFound);
        }

        [TestMethod]
        public void Get__GivenValidId_WhenDataReturned_ThenReturnedMappedToObject()
        {
            // Arrange
            const string symbol = "SYMBOL";

            var mockFinancialModelingPrepClient = new Mock<IFinancialModelingPrepClient>();
            var companyModel = new CompanyModel
            {
                Symbol = symbol,
                CompanyName = "Company Name",
                Description = "Company Description",
                Exchange = "Exchange",
                Image = "Image URL",
                Industry = "Company Industry",
                Price = 1.23m,
                Website = "Company URL"
            };
            mockFinancialModelingPrepClient.Setup(x => x.CompanyProfile(symbol)).Returns(companyModel);

            var profileController = new ProfileController(mockFinancialModelingPrepClient.Object);

            // Act
            var result = profileController.Get(symbol);

            // Assert
            var companyProfileResult = result.Value;
            Assert.IsNotNull(companyProfileResult);
            Assert.AreEqual(companyModel.Symbol, companyProfileResult.Symbol);
            Assert.AreEqual(companyModel.CompanyName, companyProfileResult.CompanyName);
            Assert.AreEqual(companyModel.Description, companyProfileResult.Description);
            Assert.AreEqual(companyModel.Exchange, companyProfileResult.Exchange);
            Assert.AreEqual(companyModel.Image, companyProfileResult.Image);
            Assert.AreEqual(companyModel.Industry, companyProfileResult.Industry);
            Assert.AreEqual(companyModel.Price, companyProfileResult.Price);
            Assert.AreEqual(companyModel.Website, companyProfileResult.Website);
        }
    }
}
