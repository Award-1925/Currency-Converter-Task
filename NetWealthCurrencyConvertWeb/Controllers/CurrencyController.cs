using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetWealthCurrencyConvertWeb.Models;
using Newtonsoft.Json;
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
             
            viewModel.CurrencyList = await Api.CurrencyAPI.getCurrencyList(); 
            viewModel.Amount = 0;
            viewModel.ConvertedAmount = 0;

            return View(viewModel);
        }

        [HttpPost] 
        public async Task<IActionResult> CurrencyConverter(Models.ConvertCurrencyViewModel viewModel)
        {
            if(viewModel == null)
            {
                return View("Error");
            }
             
            viewModel.CurrencyList = await Api.CurrencyAPI.getCurrencyList();

            Models.ConvertCurrencyResponseModel oResponse = await Api.CurrencyAPI.convertCurrency(viewModel);
            if (oResponse != null && oResponse.Success)
            {
                viewModel.ConvertedAmount = oResponse.ConvertedToAmount;
            }
            return View(viewModel);
        } 
    }
}
