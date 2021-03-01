using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerumClassLibrary.Models;
using SerumClassLibrary.DataAccess;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace SerumClassLibrary.BusinessLogic
{
    public class TradesPairProcessor
    {
        // Hardcoded for now, will implement user choice later on... :)
        // list of trading pairs 5x2
        // SRM SOL FIDA LINK UNI x USDC USDT
        // List<string> listPair // add pairs
        //private List<string> listPairs = new List<string>()
        //    {"SRMUSDC", "SRMUSDT", "SOLUSDC", "SOLUSDT", "FIDAUSDC", "FIDAUSDT", "LINKUSDC", "LINKUSDT", "UNIUSDC", "UNIUSDT"};
        public List<string> listPairs = new List<string>()
            {"SRMUSDC", "SOLUSDC", "FIDAUSDC", "LINKUSDC", "UNIUSDC"};

        // populated list of pairs (10)
        // List<TradesPairModel> listTradesPair ...
        private List<TradesPairModel.Rootobject> listTradesPair = new List<TradesPairModel.Rootobject>();

        // fighting to implement async so app can be responsive when calls are made...
        // async method
        //public async Task<List<TradesPairModel.Rootobject>> GetListOfTradesPairsAsync()
        //{
        //    await GetListOfTradesPairs();

        //}
        // method to pull all trading pairs into listTradesPair
        public List<TradesPairModel.Rootobject> GetListOfTradesPairs()
        {

            foreach (var pair in listPairs)
            {

                TradesPairModel.Rootobject tpmRoot = new TradesPairModel.Rootobject();
                tpmRoot.trade = new List<TradesPairModel.Trade>();

                DA_GETTradesPair gtp = new DA_GETTradesPair();
                string s = gtp.GetTradesPair(pair);
                JToken jtRootObject = JToken.Parse(s);
                List<JToken> jtData = jtRootObject["data"].ToList();

                // popuni osnovni root object
                tpmRoot.pair = pair;
                tpmRoot.success = Convert.ToBoolean(jtRootObject["success"].ToString());
                

                foreach (JToken jtTrade in jtData)
                {
                    // gde je bio izazov -->
                    TradesPairModel.Trade tpmTrade = new TradesPairModel.Trade();

                    tpmTrade.market = jtTrade["market"].ToString();
                    tpmTrade.price = float.Parse(jtTrade["price"].ToString(), CultureInfo.InvariantCulture.NumberFormat);
                    tpmTrade.size = float.Parse(jtTrade["size"].ToString(), CultureInfo.InvariantCulture.NumberFormat);
                    tpmTrade.side = jtTrade["side"].ToString();
                    tpmTrade.time = Convert.ToInt64(jtTrade["time"].ToString());
                    tpmTrade.orderId = jtTrade["orderId"].ToString();
                    tpmTrade.feeCost = float.Parse(jtTrade["feeCost"].ToString());
                    tpmTrade.marketAddress = jtTrade["marketAddress"].ToString();
                    // dodaje svaki trade u listu trejdova root podklase
                    tpmRoot.trade.Add(tpmTrade);
                }
                // dodaje svaku listu para trejdova u listu 
                listTradesPair.Add(tpmRoot);
            }
            return listTradesPair;
        }

    }
}
