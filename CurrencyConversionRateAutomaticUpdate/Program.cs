using Newtonsoft.Json;
using RestSharp;

CurrencyConversionRateAutomaticUpdate.Data.Currency.sp_GetCurrenciesDataTable currencyTable = CurrencyConversionRateAutomaticUpdate.Business.Currency.GetCurrencies();

foreach(CurrencyConversionRateAutomaticUpdate.Data.Currency.sp_GetCurrenciesRow currencyRow in currencyTable.Rows)
{
    Console.WriteLine($"Getting exchange rates for {currencyRow.CurrencyCode}");
    RestClient client = new RestClient("https://api.exchangerate.host/latest"); 
    RestRequest request = new RestRequest($"?base={currencyRow.CurrencyCode}", Method.Get);  
    RestResponse response = await client.ExecuteAsync(request);

    if (response.StatusCode == System.Net.HttpStatusCode.OK && response.Content != null)
    {
        CurrencyConversionRateAutomaticUpdate.APIResponse.ExchangeRateAPILatest exchangeRateAPILatest = JsonConvert.DeserializeObject<CurrencyConversionRateAutomaticUpdate.APIResponse.ExchangeRateAPILatest>(response.Content) ?? new CurrencyConversionRateAutomaticUpdate.APIResponse.ExchangeRateAPILatest();
        foreach (KeyValuePair<string, decimal> rate in exchangeRateAPILatest.Rates)
        {
            Console.WriteLine($"exchange rates updated for {currencyRow.CurrencyCode}/{rate.Key} pair");
            CurrencyConversionRateAutomaticUpdate.Business.Currency.UpdateCurrencyExchangeRate(exchangeRateAPILatest.Base, rate.Value, rate.Key);
        }  
    }
}
