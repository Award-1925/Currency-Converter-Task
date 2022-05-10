namespace CurrencyConversionRateAutomaticUpdate.Business
{
    public static class Currency
    {
        public static Data.Currency.sp_GetCurrenciesDataTable GetCurrencies()
        {
            Data.CurrencyTableAdapters.sp_GetCurrenciesTableAdapter oAdapter = new Data.CurrencyTableAdapters.sp_GetCurrenciesTableAdapter();
            return oAdapter.GetData();
        }
        public static void UpdateCurrencyExchangeRate(string currencyCode, decimal exchangeRate, string destinationCurrencyCode)
        {
            Data.CurrencyTableAdapters.QueriesTableAdapter oQueryAdapter = new Data.CurrencyTableAdapters.QueriesTableAdapter();
            oQueryAdapter.sp_UpdateCurrencyExchangeRate(currencyCode, exchangeRate, destinationCurrencyCode);
        } 
    }
}
