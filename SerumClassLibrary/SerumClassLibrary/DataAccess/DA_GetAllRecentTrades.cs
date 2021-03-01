using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SerumClassLibrary.DataAccess
{
    public class DA_GetAllRecentTrades
    {
		public string GetJsonGetAllRecentTrades()
		{ 
			try 
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				var client = new RestClient("https://serum-api.bonfida.com/trades/all/recent");
				client.Timeout = -1;
				var request = new RestRequest(Method.GET);
				request.AddHeader("Content-Type", "application/json");
				IRestResponse response = client.Execute(request);
				string s = response.Content;
				return s;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
