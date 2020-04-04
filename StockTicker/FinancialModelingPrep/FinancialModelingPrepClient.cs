using Newtonsoft.Json;
using StockTicker.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;

namespace StockTicker.FinancialModelingPrep
{
    public class FinancialModelingPrepClient : IFinancialModelingPrepClient
    {
        private const int SearchResultLimit = 30;

        public IEnumerable<SearchModel> Search(string symbol)
        {
            using var client = new WebClient();
            var response = client.DownloadString(new Uri($"https://financialmodelingprep.com/api/v3/search?query={symbol}&limit={SearchResultLimit}"));
            var searchResults = JsonConvert.DeserializeObject<SearchModel[]>(response);

            return searchResults;
        }

        public CompanyModel CompanyProfile(string symbol)
        {
            using var client = new WebClient();
            var response = client.DownloadString(new Uri($"https://financialmodelingprep.com/api/v3/company/profile/{symbol}"));
            var companyProfile = JsonConvert.DeserializeObject<CompanyModel>(response);

            return companyProfile;
        }
    }
}
