using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NetWealthCurrencyConvertWeb.Models
{
    public class ConvertCurrencyViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must select a currency to convert from.")]
        public string CurrencyCode { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter an amount to convert")]
        public decimal Amount { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must select a currency to convert to.")]
        public string DestinationCurrencyCode { get; set; } 
        [JsonIgnore] 
        public List<CurrencyListModel> CurrencyList { get; set; } = new List<CurrencyListModel>();
        [JsonIgnore]
        public string? Message { get; set; }
        [JsonIgnore]
        public string? ConversionDisplayHeader { get; set; }
        [JsonIgnore]
        public string? ConversionDisplayMessage { get; set; }
        [JsonIgnore]
        public string? lastUpdatedDisplayMessage { get; set; }
    }
}
