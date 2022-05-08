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
            new Models.CurrencyListResponseModel(){CurrencyID = 1, CurrencyCode = "USD", CurrencySymbol = "$", CurrencyName = "United States dollar" },
            new Models.CurrencyListResponseModel(){CurrencyID = 2, CurrencyCode = "RUB", CurrencySymbol = "₽", CurrencyName = "Russian ruble" },
            new Models.CurrencyListResponseModel(){CurrencyID = 3, CurrencyCode = "GBP", CurrencySymbol = "£", CurrencyName = "British pound" },
            new Models.CurrencyListResponseModel(){CurrencyID = 4, CurrencyCode = "SEK", CurrencySymbol = "kr", CurrencyName = "Swedish krona" },
            new Models.CurrencyListResponseModel(){CurrencyID = 5, CurrencyCode = "AUD", CurrencySymbol = "$", CurrencyName = "Australian dollar" },
            new Models.CurrencyListResponseModel(){CurrencyID = 6, CurrencyCode = "EUR", CurrencySymbol = "€", CurrencyName = "Euro" },
        }; 

        [HttpPost(Name = "Convert Currency")] 
        public Models.ConvertCurrencyResponseModel ConvertCurrency(Models.ConvertCurrencyRequestModel ConvertCurrencyRequest)
        {
            return new Models.ConvertCurrencyResponseModel
            {
                ConvertedDateTime = DateTime.Now,
                ConvertedFromCurrencyID = ConvertCurrencyRequest.FromCurrencyID,
                ConvertedFromAmount = ConvertCurrencyRequest.Amount,
                ConvertedToCurrencyID = ConvertCurrencyRequest.ToCurrencyID,
                ConvertedToAmount = (new Random(30).Next() * (ConvertCurrencyRequest.Amount / new Random(100).Next())),
                Success = true
            };  
        }
 
        [HttpGet(Name = "Get Currency List")]
        public List<Models.CurrencyListResponseModel> GetCurrencyList()
        {
            return _mockData_Currencies;
        }
    }
}