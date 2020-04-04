namespace StockTicker.Models
{
    public class CompanyProfileResult
    {
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public string CompanyName { get; set; }
        public string Exchange { get; set; }
        public string Industry { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
