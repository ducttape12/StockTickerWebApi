using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTicker.FinancialModelingPrep;
using System.Linq;

namespace StockTickerIntegrationTests
{
    [TestClass]
    public class FinancialModelingPrepClientTests
    {
        [TestMethod]
        public void Search__GivenRemoteServiceAvailable_WhenCalledWithPartialSymbol_ThenReturnsMatchingCompanies()
        {
            // Arrange
            const string query = "AAP";
            var financialModelingPrepClient = new FinancialModelingPrepClient();

            // Act
            var results = financialModelingPrepClient.Search(query).ToList();

            // Assert
            Assert.AreEqual(4, results.Count);
            Assert.AreEqual("AAPL", results[0].Symbol);
            Assert.AreEqual("CAAP", results[1].Symbol);
            Assert.AreEqual("AAP", results[2].Symbol);
            Assert.AreEqual("CAAPX", results[3].Symbol);
        }

        [TestMethod]
        public void Search__GivenRemoteServiceAvailable_WhenCalledWithPartialSymbolThatMatchesMoreThan30_ThenReturnsFirst30Companies()
        {
            // Arrange
            const string query = "A";
            var financialModelingPrepClient = new FinancialModelingPrepClient();

            // Act
            var results = financialModelingPrepClient.Search(query).ToList();

            // Assert
            Assert.AreEqual(30, results.Count);
        }

        [TestMethod]
        public void CompanyProfile__GivenRemoteServiceAvailable_WhenCalledWithCompanySymbol_ThenReturnsCompanyProfile()
        {
            // Arrange
            const string symbol = "AAPL";
            var financialModelingPrepClient = new FinancialModelingPrepClient();

            // Act
            var result = financialModelingPrepClient.CompanyProfile(symbol);

            // Assert
            Assert.AreEqual("AAPL", result.Symbol);
            Assert.AreEqual("Apple Inc.", result.CompanyName);
        }
    }
}
