using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockTicker.Controllers;
using StockTicker.FinancialModelingPrep;
using StockTicker.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace StockTickerUnitTests
{
    [TestClass]
    public class SearchControllerTests
    {
        [TestMethod]
        public void Get__GivenValidQuery_WhenCalled_ThenReturnsMatchesInAlphabeticalOrderMappedToNewObject()
        {
            // Arrange
            const string query = "SYMBOL";

            var companies = new List<SearchModel>
            {
                new SearchModel { Symbol = "C", Currency = "USD", ExchangeShortName = "SE1", StockExchange = "Stock Exchange 1", Name = "Company C" },
                new SearchModel { Symbol = "A", Currency = "USD", ExchangeShortName = "SE2", StockExchange = "Stock Exchange 2", Name = "Company A" },
                new SearchModel { Symbol = "B", Currency = "USD", ExchangeShortName = "SE1", StockExchange = "Stock Exchange 1", Name = "Company B" },
            };

            var mockFinancialModelingPrepClient = new Mock<IFinancialModelingPrepClient>();
            mockFinancialModelingPrepClient.Setup(x => x.Search(query)).Returns(companies);

            var searchController = new SearchController(mockFinancialModelingPrepClient.Object);

            // Act
            var results = searchController.Get(query);

            // Assert
            var searchResults = results.Value.ToList();
            Assert.AreEqual(companies.Count, searchResults.Count);
            Assert.AreEqual(companies[1].Symbol, searchResults[0].Symbol);
            Assert.AreEqual(companies[1].Name, searchResults[0].Name);
            Assert.AreEqual(companies[1].StockExchange, searchResults[0].StockExchange);

            Assert.AreEqual(companies[2].Symbol, searchResults[1].Symbol);
            Assert.AreEqual(companies[2].Name, searchResults[1].Name);
            Assert.AreEqual(companies[2].StockExchange, searchResults[1].StockExchange);

            Assert.AreEqual(companies[0].Symbol, searchResults[2].Symbol);
            Assert.AreEqual(companies[0].Name, searchResults[2].Name);
            Assert.AreEqual(companies[0].StockExchange, searchResults[2].StockExchange);
        }
    }
}
