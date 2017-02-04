using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StockExchange
{
    class Company
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("Code")]
        public string Code { get; internal set; }
        [JsonProperty("Unit")]
        public int Unit { get; internal set; }
        [JsonProperty("Price")]
        public double Price { get; internal set; }
    }
}
