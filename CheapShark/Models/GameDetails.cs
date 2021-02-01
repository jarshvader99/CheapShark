using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapShark.Models
{

    public class GameDetails
    {
        public Info info { get; set; }
        public Cheapestpriceever cheapestPriceEver { get; set; }
        public Deal[] deals { get; set; }
    }

    public class Info
    {
        public string title { get; set; }
        public string steamAppID { get; set; }
        public string thumb { get; set; }
    }

    public class Cheapestpriceever
    {
        public string price { get; set; }
        public int date { get; set; }
    }

    public class Deal
    {
        public string storeID { get; set; }
        public string dealID { get; set; }
        public string price { get; set; }
        public string retailPrice { get; set; }
        public string savings { get; set; }
    }

}
