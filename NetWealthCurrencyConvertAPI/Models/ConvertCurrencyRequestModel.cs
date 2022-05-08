namespace NetWealthCurrencyConvertAPI.Models
{
    public class ConvertCurrencyRequestModel
    { 
        public int FromCurrencyID { get; set; }
        public decimal Amount { get; set; } 
        public int ToCurrencyID { get; set; } 
    }
}
