using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Order
{
    class Program
    {
        public class JOrder
        {
            public string orderType { get; set; }
            public string session { get; set; }
            public string duration { get; set; }
            public string orderStrategyType { get; set; }
            //public JLegCollection orderLegCollection = new JLegCollection();
            //public List<JLegCollection> orderLegCollection = new List<JLegCollection>();
            public JLegCollection[] orderLegCollection { get; set; }
        }
        public class JLegCollection
        {
            public string instruction { get; set; }
            public int quantity { get; set; }
            //public JInstrument instrument = new JInstrument();
            public JInstrument instrument { get; set; }
        }

        public class JInstrument
        {
            public string symbol { get; set; }
            public string assetType { get; set; }
        }


        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            var item1 = new JLegCollection()
            {
                instruction = "Buy",
                quantity = 15,
                instrument = new JInstrument()
                {
                    symbol = "XYZ",
                    assetType = "EQUITY",
                },
            };
            var data = new JOrder()
            {
                orderType = "MARKET",
                session = "NORMAL",
                duration = "DAY",
                orderStrategyType = "SINGLE",
                orderLegCollection = new JLegCollection[] { item1 },

            };
            string json = JsonConvert.SerializeObject(data);

            JOrder dataAgain = JsonConvert.DeserializeObject<JOrder>(json);
            string jsonAgain = JsonConvert.SerializeObject(dataAgain);
            Console.WriteLine(jsonAgain);
            JOrder data2 = JsonConvert.DeserializeObject<JOrder>(jsonAgain);
            string json2 = JsonConvert.SerializeObject(data2);
            Console.WriteLine(json2);

            string json3 = "{\"orderType\": \"MARKET\",\"session\": \"NORMAL\",\"duration\": \"DAY\",\"orderStrategyType\": \"SINGLE\",\"orderLegCollection\": [{\"instruction\": \"Buy\",\"quantity\": 15,\"instrument\": {\"symbol\": \"XYZ\",\"assetType\": \"EQUITY\"}}]}";
            string json_3= @"{
""orderType"": ""MARKET"",
""session"": ""NORMAL"",
""duration"": ""DAY"",
""orderStrategyType"": ""SINGLE"",
""orderLegCollection"": [
    {""instruction"": ""Buy"",
    ""quantity"": 15,
    ""instrument"": {
        ""symbol"": ""XYZ"",
        ""assetType"": ""EQUITY""
    }
}
]
}";
            JOrder data3 = JsonConvert.DeserializeObject<JOrder>(json_3);
            string json4 = JsonConvert.SerializeObject(data3);
            Console.WriteLine(json4);
            JOrder data4 = JsonConvert.DeserializeObject<JOrder>(json4);
            string json_4 = JsonConvert.SerializeObject(data4);
            Console.WriteLine(json_4);
        }
    }
}
