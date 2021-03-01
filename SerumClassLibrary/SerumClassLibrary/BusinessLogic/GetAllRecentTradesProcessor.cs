using Newtonsoft.Json.Linq;
using SerumClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerumClassLibrary.DataAccess;
using System.Globalization;

namespace SerumClassLibrary.BusinessLogic
{
    public class GetAllRecentTradesProcessor
    {
        private AllRecentTradesModel.Rootobject artmroot = new AllRecentTradesModel.Rootobject();
        private AllRecentTradesModel.Datum artmdatum = new AllRecentTradesModel.Datum();

        private List<AllRecentTradesModel.Datum> listArtm = new List<AllRecentTradesModel.Datum>();

        public List<AllRecentTradesModel.Datum> GetListAllRecentTrades(string strJsonART)
        {
            List<AllRecentTradesModel.Datum> tempArtm = new List<AllRecentTradesModel.Datum>();
            
            try
            {
                AllRecentTradesModel.Rootobject root = new AllRecentTradesModel.Rootobject();
                

                JToken jtRootObject = JToken.Parse(strJsonART.ToString());
                List<JToken> art = jtRootObject["data"].ToList();
                foreach (JToken pair in art)
                {
                    AllRecentTradesModel.Datum datum = new AllRecentTradesModel.Datum();

                    datum.market = pair["market"].ToString();
                    datum.price = float.Parse(pair["price"].ToString(), CultureInfo.InvariantCulture.NumberFormat);
                    datum.time = Convert.ToInt64(pair["time"].ToString());
                    tempArtm.Add(datum);
                }
                return tempArtm;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<AllRecentTradesModel.Datum> GetListOfAllRecentTradesMarket()
        {
            DA_GetAllRecentTrades g = new DA_GetAllRecentTrades();
            listArtm = GetListAllRecentTrades(g.GetJsonGetAllRecentTrades());
            return listArtm;
        }
    }
}
