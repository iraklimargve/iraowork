namespace Project1.ViewModels
{
    public class MarketViewModel
    {
        public int MarketId { get; set; }
        public string MarketName { get; set; }
        public List<CompanyViewModel> CompanyList { get; set; }
    }

    public class CompanyViewModel
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public decimal Price { get; set; }
    }
}
