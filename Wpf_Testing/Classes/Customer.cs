using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_OrganizeAparty
{
    public class Customer
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string telNumber { get; set; }
        public string address { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public string name { get { return $"{ firstName} { lastName}"; } }



    }
}
