using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StockTicker.Interfaces;
using StockTicker.Models;

namespace StockTicker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IFinancialModelingPrepClient financialModelingPrepClient;

        public SearchController(IFinancialModelingPrepClient financialModelingPrepClient)
        {
            this.financialModelingPrepClient = financialModelingPrepClient;
        }

        [HttpGet]
        public IEnumerable<SearchResult> Get(string query)
        {
            var results = financialModelingPrepClient.Search(query);

            return results
                .Select(x => new SearchResult
                {
                    Symbol = x.Symbol,
                    Name = x.Name,
                    StockExchange = x.StockExchange
                })
                .OrderBy(result => result.Name)
                .ToList();
        }
    }
}