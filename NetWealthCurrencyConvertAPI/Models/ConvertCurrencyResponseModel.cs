namespace NetWealthCurrencyConvertAPI.Models
{
    public class ConvertCurrencyResponseModel
    {
        public DateTime ConvertedDateTime { get; set; } 
        public int ConvertedFromCurrencyID { get; set; } 
        public decimal ConvertedFromAmount { get; set; } 
        public int ConvertedToCurrencyID { get; set; } 
        public decimal ConvertedToAmount { get; set; }
        public bool Success { get; set; }
    }
}
