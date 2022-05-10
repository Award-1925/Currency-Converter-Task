using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConversionRateAutomaticUpdate
{
    internal class APIResponse
    {
        public class ExchangeRateAPILatest
        { 
            [JsonProperty("success")]
            public bool Success { get; set; } 
            [JsonProperty("base")]
            public string Base { get; set; }
            [JsonProperty("date")]
            public DateTime Date { get; set; }
            [JsonProperty("rates")]
            public Dictionary<string, decimal> Rates { get; set; } 
        } 

    }
}
