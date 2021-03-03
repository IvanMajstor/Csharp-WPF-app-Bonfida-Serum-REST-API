using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SerumClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SerumClassLibrary.DataAccess
{
    public class DA_GETTradesPair
    {

        private string tradesPairLink = @"https://serum-api.bonfida.com/trades/";

        public async Task<string> GetTradesPairAsync(string pair)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var client = new RestClient(tradesPairLink + pair);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json");
                IRestResponse response = await Task.Run(() => client.Execute(request));
                string s = response.Content;
                return s;
            }
            catch (Exception)
            {

                throw;
            }

        }

        // another way to do it
        ///// <summary>
        ///// Call to Rest API for recent trades on trade pair
        ///// </summary>
        ///// <param name="pair">Trade pair used to return results from recent trades</param>
        ///// <returns>Json of recent trades for given pair</returns>
        //public async Task<string> GetTradesPairAsync(string pair)
        //{
        //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        //    var client = new HttpClient();
        //    var request = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Get,
        //        RequestUri = new Uri(tradesPairLink + pair)
        //    };
        //    try
        //    {
        //        using (var response = await client.SendAsync(request))
        //        {
        //            response.EnsureSuccessStatusCode();
        //            var body = await response.Content.ReadAsStringAsync();
        //            string s = body.ToString();
        //            // formatira string u prijemcljiviji za oko format
        //            JToken jtoken = JsonConvert.DeserializeObject<JToken>(body); // RADI (JObject je bacao gresku)
        //            return s;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        if (e.InnerException != null)
        //        {
        //            string err = e.InnerException.Message;
        //        }
        //        throw;
        //    }
        //}
    }
}
