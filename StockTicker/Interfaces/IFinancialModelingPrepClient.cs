using StockTicker.FinancialModelingPrep;
using System.Collections.Generic;

namespace StockTicker.Interfaces
{
    public interface IFinancialModelingPrepClient
    {
        public IEnumerable<SearchModel> Search(string symbol);
        public CompanyModel CompanyProfile(string symbol);
    }
}
