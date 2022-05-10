using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace NetWealthCurrencyConvertAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ConvertCurrencyController : ControllerBase
    { 
        private readonly ILogger<ConvertCurrencyController> _logger; 
        public ConvertCurrencyController(ILogger<ConvertCurrencyController> logger)
        {
            _logger = logger; 
        } 

        [HttpPost(Name = "Convert Currency")] 
        public Models.ConvertCurrencyResponseModel ConvertCurrency(Models.ConvertCurrencyRequestModel convertCurrencyRequest)
        { 
            Data.Currency.sp_ConvertCurrencyRow currencyRow = Business.Currency.ConvertCurrency(convertCurrencyRequest.CurrencyCode, convertCurrencyRequest.Amount, convertCurrencyRequest.DestinationCurrencyCode); 
            if(currencyRow == null)
            {
                return new Models.ConvertCurrencyResponseModel
                {
                    ConvertedDateTime = DateTime.Now,
                    CurrencyCode = convertCurrencyRequest.CurrencyCode,
                    Amount = convertCurrencyRequest.Amount,
                    DestinationCurrencyCode = convertCurrencyRequest.DestinationCurrencyCode,
                    ConvertedAmount = 0,
                    LastUpdatedTS = DateTime.Now,
                    Status = "Error",
                    Message = "There is no updated conversion rate available for that currency pair."
                };
            }
            return new Models.ConvertCurrencyResponseModel
            {
                ConvertedDateTime = DateTime.Now, 
                CurrencyCode = currencyRow.CurrencyCode,
                Amount = currencyRow.Amount,
                DestinationCurrencyCode = currencyRow.DestinationCurrencyCode,
                ConvertedAmount = currencyRow.ConvertedAmount,
                LastUpdatedTS = currencyRow.LastUpdatedTS,
                Status = "OK"
            };  
        }
 
        [HttpGet(Name = "Get Currency List")]
        public List<Models.CurrencyListModel> GetCurrencyList()
        {
            List<Models.CurrencyListModel> currencies = Business.Currency.GetCurrencies().Select(x => new Models.CurrencyListModel() { Currency = x.Currency, CurrencyCode = x.CurrencyCode }).ToList();
 
            return currencies;
        }
    }
}