using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetWealthCurrencyConvertWeb.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace NetWealthCurrencyConvertWeb.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly ILogger<CurrencyController> _logger;

        public CurrencyController(ILogger<CurrencyController> logger)
        {
            _logger = logger;
        } 
         
        public async Task<IActionResult> CurrencyConverter()
        {
            Models.ConvertCurrencyViewModel viewModel = new Models.ConvertCurrencyViewModel();
             
            viewModel.CurrencyList = await Api.CurrencyAPI.GetCurrencyList(); 
            viewModel.Amount = 0; 

            return View(viewModel);
        }

        [HttpPost] 
        public async Task<IActionResult> CurrencyConverter(Models.ConvertCurrencyViewModel viewModel)
        {
            if(viewModel == null)
            {
                return View("Error");
            }

            viewModel.CurrencyList = await Api.CurrencyAPI.GetCurrencyList();

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            Models.ConvertCurrencyResponseModel oResponse = await Api.CurrencyAPI.ConvertCurrency(viewModel);
            if (oResponse != null)
            {
                if (oResponse.Status == "OK")
                {
                    viewModel.ConversionDisplayHeader = $"{TruncateDecimal(oResponse.ConvertedAmount, 2).ToString()} {oResponse.DestinationCurrencyCode}";
                    viewModel.ConversionDisplayMessage = $"{oResponse.Amount} {oResponse.CurrencyCode} = {oResponse.ConvertedAmount} {oResponse.DestinationCurrencyCode}";
                    viewModel.lastUpdatedDisplayMessage = $"Last Updated : {oResponse.LastUpdatedTS}";
                }
                else
                {
                    viewModel.ConversionDisplayMessage = String.Empty;
                    viewModel.Message = oResponse.Message;
                }
            }
            return View(viewModel);
        }
        private decimal TruncateDecimal(decimal value, int precision)
        {
            decimal step = (decimal)Math.Pow(10, precision);
            decimal tmp = Math.Truncate(step * value);
            return tmp / step;
        }

        public IActionResult ViewAPIEndpoints()
        {
            return Redirect($"{Api.CurrencyAPI.ApiURL}swagger/index.html");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
