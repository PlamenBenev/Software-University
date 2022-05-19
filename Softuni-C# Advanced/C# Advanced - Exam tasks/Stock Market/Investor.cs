using System.Collections.Generic;
using System.Linq;

namespace StockMarket
{
    public class Investor
    {
        public List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public Investor(string fname,string email, decimal moneyToInvest, string broker)
        {
            FullName = fname;
            EmailAddress = email;
            MoneyToInvest = moneyToInvest;
            BrokerName = broker;
            Portfolio = new List<Stock>();
        }
        public int Count
        {
            get { return Portfolio.Count; }
        }
        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                Portfolio.Add(stock);
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            bool doesItExist = false;
            bool itsBigger = false;
            Stock stonkToRemove = null;

            foreach (var item in Portfolio)
            {
                if (item.CompanyName == companyName)
                {
                    doesItExist = true;
                    if (sellPrice >= item.PricePerShare)
                    {
                        itsBigger = true;
                        stonkToRemove = item;
                    }
                }
            }
            if (!doesItExist)
            {
                return $"{companyName} does not exist.";
            }
            if (!itsBigger)
            {
                return $"Cannot sell {companyName}.";
            }

            MoneyToInvest += sellPrice;
            Portfolio.Remove(stonkToRemove);
            return $"{companyName} was sold.";
        }
        public Stock FindStock(string companyName)
        {
            Stock stock = null;
            foreach (var item in Portfolio)
            {
                if (item.CompanyName == companyName)
                {
                    stock = item;
                }
            }
            return stock;
        }
        public Stock FindBiggestCompany()
        {
            Stock stock = null;
            foreach (var item in Portfolio)
            {
                if (stock != null && stock.MarketCapitalization < item.MarketCapitalization)
                {
                    stock = item;
                }
                else if (stock == null)
                    stock = item;
            }
            return stock;
        }
        public string InvestorInformation()
        {
            string result = 
                $"The investor {FullName} with a broker {BrokerName} has stocks: {string.Join('\n',Portfolio)}";

            return result;
        }
    }
}
