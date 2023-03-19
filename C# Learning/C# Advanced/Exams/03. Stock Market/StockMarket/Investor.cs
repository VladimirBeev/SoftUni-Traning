using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio;

        public List<Stock> Portfolio
        {
            get { return portfolio; }
            set { portfolio = value; }
        }

        private string fullName;

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        private string emailAddress;

        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }
        private decimal moneyToInvest;

        public decimal MoneyToInvest
        {
            get { return moneyToInvest; }
            set { moneyToInvest = value; }
        }

        private string brokerName;

        public string BrokerName
        {
            get { return brokerName; }
            set { brokerName = value; }
        }

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            this.Portfolio = new List<Stock>();
            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
        }

        public int Count
        {
            get => this.Portfolio.Count;
        }
        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization >= 10000)
            {
                if (MoneyToInvest >= stock.PricePerShare)
                {
                    this.Portfolio.Add(stock);
                    MoneyToInvest -= stock.PricePerShare;
                }
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            foreach (Stock stock in this.Portfolio)
            {
                if (stock.CompanyName == companyName)
                {
                    if (stock.PricePerShare < sellPrice)
                    {
                        this.Portfolio.Remove(stock);
                        this.MoneyToInvest += sellPrice;
                        return ($"{companyName} was sold.");
                    }
                    return ($"Cannot sell {companyName}.");
                }
            }
            return ($"{companyName} does not exist.");
        }
        public Stock FindStock(string companyName)
        {
            foreach (Stock stock in this.Portfolio)
            {
                if (companyName == stock.CompanyName)
                {
                    return stock;
                }
            }
            return null;
        }
        public Stock FindBiggestCompany()
        {
            if (this.Portfolio.Count == 0)
            {
                return null;
            }
            else
                return this.Portfolio.OrderByDescending(stock => stock.MarketCapitalization).First();
        }
        public string InvestorInformation()
        {
            StringBuilder st = new StringBuilder();
            st.Append($"The investor {fullName} with a broker {brokerName} has stocks:\n");
            foreach (Stock stock in this.Portfolio)
            {
                st.Append(stock.ToString());
            }
            return st.ToString();
        }
    }
}
