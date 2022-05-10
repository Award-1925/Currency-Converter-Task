namespace NetWealthCurrencyConvertWeb.Models
{
    public class CurrencyListModel
    { 
        public string CurrencyCode { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty; 
        public string DisplayText
        {
            get { return $"{CurrencyCode} - {Currency}"; }
        }
    } 
}
