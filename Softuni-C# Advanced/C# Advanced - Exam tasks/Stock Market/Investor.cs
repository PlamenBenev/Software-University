using System.Collections.Generic;
using System;
using System.Linq;

namespace StockMarket
{
    public class Investor
    {
        public List<Stock> Portfolio { get; set; } = new List<Stock>();
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
        }
        public int Count
        {
            get { return Portfolio.Count; }
        }
        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization >= 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                Portfolio.Add(stock);
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            foreach (var item in Portfolio)
            {
                if (item.CompanyName == companyName)
                {
                    if (item.PricePerShare < sellPrice)
                    {
                        MoneyToInvest += sellPrice;
                        Portfolio.Remove(item);
                        return $"{companyName} was sold.";
                    }
                    else
                        return $"Cannot sell { companyName}.";
                }
            }
            return $"{companyName} does not exist.";
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
            decimal biggest = 0;
            foreach (var item in Portfolio)
            {
                if (item.MarketCapitalization > biggest)
                {
                    biggest = item.MarketCapitalization;
                    stock = item;
                }
            }
            return stock;
        }
        public string InvestorInformation()
        {
            string result = 
                $"The investor {FullName} with a broker {BrokerName} has stocks:{Environment.NewLine}" + 
                $"{string.Join(Environment.NewLine,Portfolio)}";

            return result;
        }
    }
}
