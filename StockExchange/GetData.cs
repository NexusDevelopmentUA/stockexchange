using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StockExchange
{
    class GetData
    {
        public JObject download()//download JSON file
        {
            WebClient conn = new WebClient();
            var data = conn.DownloadString("http://webtask.future-processing.com:8068/stocks");
            JObject jdata = JObject.Parse(data);
            return jdata;
        }
    }
}
