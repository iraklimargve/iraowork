namespace Project1.ViewModels
{
    public class ChangePriceBodyModel
    {
        public int MarketId { get; set; }
        public int CompanyId { get; set; }
        public decimal NewPrice { get; set; }
    }
}
