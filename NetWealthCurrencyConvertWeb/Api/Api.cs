using Newtonsoft.Json;
using System.Text;

namespace NetWealthCurrencyConvertWeb.Api
{
    public static class CurrencyAPI
    {
        public const string ApiURL = "https://localhost:7108/";
        public static async Task<List<Models.CurrencyListModel>> GetCurrencyList()
        {
            List<Models.CurrencyListModel> currencyList = new List<Models.CurrencyListModel>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{ApiURL}api/ConvertCurrency/GetCurrencyList"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    currencyList = JsonConvert.DeserializeObject<List<Models.CurrencyListModel>>(apiResponse) ?? new List<Models.CurrencyListModel>(); 
                }
            }
            return currencyList; 
        } 
        public static async Task<Models.ConvertCurrencyResponseModel> ConvertCurrency(Models.ConvertCurrencyViewModel viewModel)
        {  
            using (var httpClient = new HttpClient())
            {
                string jsonObject = JsonConvert.SerializeObject(viewModel);
                StringContent content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync($"{ApiURL}api/ConvertCurrency/ConvertCurrency", content).ConfigureAwait(false))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Models.ConvertCurrencyResponseModel convertCurrencyResponse = JsonConvert.DeserializeObject<Models.ConvertCurrencyResponseModel>(apiResponse) ?? new Models.ConvertCurrencyResponseModel(); 
                    return convertCurrencyResponse;
                }
            }
            return null;
        }
    } 
}
