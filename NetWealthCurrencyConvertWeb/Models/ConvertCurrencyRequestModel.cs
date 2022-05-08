namespace NetWealthCurrencyConvertWeb.Models
{
    public class ConvertCurrencyRequestModel
    { 
        public int FromCurrencyID { get; set; }
        public int Amount { get; set; } 
        public int ToCurrencyID { get; set; } 
    }
}
