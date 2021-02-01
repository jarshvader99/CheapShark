using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapShark.Models
{

    public class Games
    {
        public string gameID { get; set; }
        public string steamAppID { get; set; }
        public string cheapest { get; set; }
        public string cheapestDealID { get; set; }
        public string external { get; set; }
        public string internalName { get; set; }
        public string thumb { get; set; }
    }


}
