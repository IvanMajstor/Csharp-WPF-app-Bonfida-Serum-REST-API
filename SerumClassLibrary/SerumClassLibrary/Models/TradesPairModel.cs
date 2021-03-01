using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerumClassLibrary.Models
{
    public class TradesPairModel
    {

        public class Rootobject
        {
            public bool success { get; set; }
            // new: to see what pair is in there
            public string pair { get; set; }
            public List<Trade> trade { get; set; }
        }

        public class Trade
        {
            public string market { get; set; }
            public float price { get; set; }
            public float size { get; set; }
            public string side { get; set; }
            public long time { get; set; }
            public string orderId { get; set; }
            public float feeCost { get; set; }
            public string marketAddress { get; set; }
        }

    }
}
