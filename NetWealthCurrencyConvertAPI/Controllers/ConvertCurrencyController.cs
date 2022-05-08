using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace NetWealthCurrencyConvertAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ConvertCurrencyController : ControllerBase
    { 
        private readonly ILogger<ConvertCurrencyController> _logger;
        SqlConnection oSQlCon = new SqlConnection();
        SqlCommand oSQLCommand = new SqlCommand();
        public ConvertCurrencyController(ILogger<ConvertCurrencyController> logger)
        {
            _logger = logger;
            oSQlCon.ConnectionString = Properties.Resources.ConnectionString;
        }
        List<Models.CurrencyListResponseModel> _mockData_Currencies = new List<Models.CurrencyListResponseModel>()
        {
            new Models.CurrencyListResponseModel(){CurrencyID = 1, CurrencyCode = "USD", CurrencySymbol = "$", Currency = "United States dollar" },
            new Models.CurrencyListResponseModel(){CurrencyID = 2, CurrencyCode = "RUB", CurrencySymbol = "₽", Currency = "Russian ruble" },
            new Models.CurrencyListResponseModel(){CurrencyID = 3, CurrencyCode = "GBP", CurrencySymbol = "£", Currency = "British pound" },
            new Models.CurrencyListResponseModel(){CurrencyID = 4, CurrencyCode = "SEK", CurrencySymbol = "kr", Currency = "Swedish krona" },
            new Models.CurrencyListResponseModel(){CurrencyID = 5, CurrencyCode = "AUD", CurrencySymbol = "$", Currency = "Australian dollar" },
            new Models.CurrencyListResponseModel(){CurrencyID = 6, CurrencyCode = "EUR", CurrencySymbol = "€", Currency = "Euro" },
        }; 

        [HttpPost(Name = "Convert Currency")] 
        public Models.ConvertCurrencyResponseModel ConvertCurrency(Models.ConvertCurrencyRequestModel convertCurrencyRequest)
        {
            decimal convertedAmount = Business.Currency.ConvertCurrency(convertCurrencyRequest.FromCurrencyID, convertCurrencyRequest.Amount, convertCurrencyRequest.ToCurrencyID); 
            return new Models.ConvertCurrencyResponseModel
            {
                ConvertedDateTime = DateTime.Now,
                ConvertedFromCurrencyID = convertCurrencyRequest.FromCurrencyID,
                ConvertedFromAmount = convertCurrencyRequest.Amount,
                ConvertedToCurrencyID = convertCurrencyRequest.ToCurrencyID,
                ConvertedToAmount = convertedAmount,
                Success = true
            };  
        }
 
        [HttpGet(Name = "Get Currency List")]
        public List<Models.CurrencyListResponseModel> GetCurrencyList()
        {
            List<Models.CurrencyListResponseModel> currencies = Business.Currency.GetCurrencies().Select(x => new Models.CurrencyListResponseModel() { CurrencyID = x.CurrencyID, CurrencyCode = x.CurrencyCode, CurrencySymbol = x.CurrencySymbol, Currency = x.Currency }).ToList();
 
            return currencies;
        }
    }
}