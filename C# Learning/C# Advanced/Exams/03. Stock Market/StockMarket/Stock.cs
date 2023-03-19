namespace StockMarket
{
    public class Stock
    {
        private string companyName;

        public string CompanyName
        {
            get { return  companyName; }
            set {  companyName = value; }
        }
        private string director;

        public string  Director
        {
            get { return director; }
            set { director = value; }
        }
        private decimal pricePerShare;

        public decimal PricePerShare
        {
            get { return pricePerShare; }
            set { pricePerShare = value; }
        }
        private int totalNumberOfShares;

        public int TotalNumberOfShares
        {
            get { return totalNumberOfShares; }
            set { totalNumberOfShares = value; }
        }

        private decimal marketCapitalization;

        public decimal MarketCapitalization
        {
            get { return marketCapitalization; }
            set { marketCapitalization = this.PricePerShare*this.TotalNumberOfShares; }
        }

        public Stock(string companyName,string director,decimal pricePerShare,int totalNumberOfShares )
        {
            this.CompanyName = companyName;
            this.Director = director;
            this.PricePerShare = pricePerShare;
            this.TotalNumberOfShares = totalNumberOfShares;
            this.MarketCapitalization = marketCapitalization;
        }

        public override string ToString()
        {
            return $"Company: {CompanyName}\nDirector: {Director}\nPrice per share: ${PricePerShare}\nMarket capitalization: ${MarketCapitalization}\n";
        }
    } 
}
