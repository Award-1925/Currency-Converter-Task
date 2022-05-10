namespace NetWealthCurrencyConvertAPI.Business
{
    public static class Currency
    {
        public static Data.Currency.sp_GetCurrenciesDataTable GetCurrencies()
        {
            Data.CurrencyTableAdapters.sp_GetCurrenciesTableAdapter oAdapter = new Data.CurrencyTableAdapters.sp_GetCurrenciesTableAdapter();
            return oAdapter.GetData();
        }
        public static Data.Currency.sp_ConvertCurrencyRow ConvertCurrency(string currencyCode, decimal amount, string destinationCurrencyCode)
        {
            Data.CurrencyTableAdapters.sp_ConvertCurrencyTableAdapter oAdapter = new Data.CurrencyTableAdapters.sp_ConvertCurrencyTableAdapter();
            Data.Currency.sp_ConvertCurrencyDataTable oData = oAdapter.GetData(currencyCode, amount, destinationCurrencyCode);
            if(oData.Count > 0)
            {
                return oAdapter.GetData(currencyCode, amount, destinationCurrencyCode)[0];
            }
            return null;
        } 
    }
}
