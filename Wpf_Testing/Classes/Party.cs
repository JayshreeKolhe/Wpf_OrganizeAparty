using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_OrganizeAparty
{
   public class Party : Customer
    {
      
        public string responsibleperson { get; set; }
        public string partyDate { get; set; }
        public string partyType { get; set; }
        public string partyAddress { get; set; }
        public string cateringService { get; set; }
        public string guest { get; set; }
        public string child { get; set; }
        public string veg { get; set; }
        public string nonVeg { get; set; }
        public string fooddata { get; set; }
        public string decordata { get; set; }
        public string foodtotal { get; set; }
        public string decortotal { get; set; }
        public string partytotal { get; set; }


    }
}