namespace StockTicker.FinancialModelingPrep
{
    public class CompanyModel
    {
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public decimal Beta { get; set; }
        public int VolAvg { get; set; }
        public decimal LastDiv { get; set; }
        public string Range { get; set; }
        public decimal Changes { get; set; }
        public string CompanyName { get; set; }
        public string Exchange { get; set; }
        public string Industry { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public string Ceo { get; set; }
        public string Sector { get; set; }
        public string Image { get; set; }
    }
}
