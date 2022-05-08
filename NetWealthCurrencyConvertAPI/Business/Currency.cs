namespace NetWealthCurrencyConvertAPI.Business
{
    public static class Currency
    {
        public static Data.Currency.sp_GetCurrenciesDataTable GetCurrencies()
        {
            Data.CurrencyTableAdapters.sp_GetCurrenciesTableAdapter oAdapter = new Data.CurrencyTableAdapters.sp_GetCurrenciesTableAdapter();
            return oAdapter.GetData();
        }
        public static decimal ConvertCurrency(int currencyID, decimal amount, int destinationCurrencyID)
        {
            Data.CurrencyTableAdapters.QueriesTableAdapter oQueryAdapter = new Data.CurrencyTableAdapters.QueriesTableAdapter();
            return (decimal)oQueryAdapter.sp_ConvertCurrency(currencyID, amount, destinationCurrencyID); 
        }
    }
}
