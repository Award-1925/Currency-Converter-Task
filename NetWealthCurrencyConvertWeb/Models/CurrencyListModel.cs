namespace NetWealthCurrencyConvertWeb.Models
{
    public class CurrencyListModel
    {
        public int CurrencyID { get; set; }
        public string CurrencySymbol { get; set; }
        public string Currency { get; set; }
        public string CurrencyCode { get; set; }
        public string DisplayText
        {
            get { return $"{CurrencySymbol} - {CurrencyCode} - {Currency}"; }
        }
    } 
}
