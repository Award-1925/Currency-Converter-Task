using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NetWealthCurrencyConvertWeb.Models
{
    public class ConvertCurrencyViewModel
    {
        [Required]
        public int ConvertFromCurrencyID { get; set; }
        [Required]
        public decimal Amount { get; set; } 
        [Required]
        public int ConvertToCurrencyID { get; set; }
        [JsonIgnore]
        public decimal ConvertedAmount { get; set; }
        [JsonIgnore]
        public List<CurrencyListModel> CurrencyList { get; set; } 
        
    }
}
