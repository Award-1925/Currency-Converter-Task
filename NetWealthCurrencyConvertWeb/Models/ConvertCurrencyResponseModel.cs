namespace NetWealthCurrencyConvertWeb.Models
{
    public class ConvertCurrencyResponseModel
    {
        public DateTime ConvertedDateTime { get; set; } 
        public string ConvertedFromCurrencyID { get; set; } 
        public decimal ConvertedFromAmount { get; set; } 
        public string ConvertedToCurrencyID { get; set; } 
        public decimal ConvertedToAmount { get; set; }
        public bool Success { get; set; }
    }
}
