namespace NetWealthCurrencyConvertAPI.Models
{
    public class ConvertCurrencyResponseModel
    {
        public DateTime ConvertedDateTime { get; set; }
        public string CurrencyCode { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string DestinationCurrencyCode { get; set; } = string.Empty;
        public decimal ConvertedAmount { get; set; }
        public DateTime LastUpdatedTS { get; set; }
        public string Status { get; set; }
        public string? Message { get; set; }
    }
}
