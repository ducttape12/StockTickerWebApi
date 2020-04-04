using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StockTicker.Interfaces;
using StockTicker.Models;

namespace StockTicker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IFinancialModelingPrepClient financialModelingPrepClient;

        public ProfileController(IFinancialModelingPrepClient financialModelingPrepClient)
        {
            this.financialModelingPrepClient = financialModelingPrepClient;
        }

        [HttpGet("{id}")]
        public ActionResult<CompanyProfileResult> Get(string id)
        {
            var company = financialModelingPrepClient.CompanyProfile(id);

            if(company == null || company.Profile == null || company.Symbol == null)
            {
                return NotFound();
            }

            return new CompanyProfileResult
            {
                CompanyName = company.Profile.CompanyName,
                Description = company.Profile.Description,
                Exchange = company.Profile.Exchange,
                Image = company.Profile.Image,
                Industry = company.Profile.Industry,
                Price = company.Profile.Price,
                Symbol = company.Symbol,
                Website = company.Profile.Website
            };
        }
    }
}