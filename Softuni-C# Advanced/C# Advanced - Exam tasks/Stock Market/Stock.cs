using System;
namespace StockMarket
{
    public class Stock
    {
        public string CompanyName { get; set; }
        public string Director { get; set; }
        public decimal PricePerShare { get; set; }
        public int TotalNumberOfShares { get; set; }
        public decimal MarketCapitalization { get; set; }
        public Stock(string name,string director,decimal pricePerShare,int totalNumberOfShares)
        {
            CompanyName = name;
            Director = director;
            PricePerShare = pricePerShare;
            TotalNumberOfShares = totalNumberOfShares;
            MarketCapitalization = pricePerShare * totalNumberOfShares;
        }
        public override string ToString()
        {
            string result = $"Company: {CompanyName}{Environment.NewLine}" +
                $"Director: { Director}{Environment.NewLine}" +
                $"Price per share: { PricePerShare}{Environment.NewLine}" +
                $"Market capitalization: { MarketCapitalization}";

            return result;
        }
    }
}
