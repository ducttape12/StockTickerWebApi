using Newtonsoft.Json;
using StockTicker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace StockTicker.FinancialModelingPrep
{
    public class FinancialModelingPrepClient : IFinancialModelingPrepClient
    {
        private const int SearchResultLimit = 30;

        /// <summary>Get a free API key from https://financialmodelingprep.com/developer/docs/</summary>
        private const string ApiKey = "[Set your API Key here]";

        public IEnumerable<SearchModel> Search(string symbol)
        {
            using var client = new WebClient();
            var response = client.DownloadString(new Uri($"https://financialmodelingprep.com/api/v3/search?query={symbol}&limit={SearchResultLimit}&apikey={ApiKey}"));
            var searchResults = JsonConvert.DeserializeObject<SearchModel[]>(response);

            return searchResults;
        }

        public CompanyModel CompanyProfile(string symbol)
        {
            using var client = new WebClient();
            var response = client.DownloadString(new Uri($"https://financialmodelingprep.com/api/v3/profile/{symbol}?apikey={ApiKey}"));
            var companyProfiles = JsonConvert.DeserializeObject<CompanyModel[]>(response);

            return companyProfiles.FirstOrDefault();
        }
    }
}
