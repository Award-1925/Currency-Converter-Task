namespace NetWealthCurrencyConvertWeb.Models
{
    public class ConvertCurrencyRequestModel
    {
        public string CurrencyCode { get; set; }
        public decimal Amount { get; set; }
        public string DestinationCurrencyCode { get; set; }
    }
}
