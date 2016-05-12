using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoinyMarvel.Models
{
    public class CharacterInfo
    {
        public string name { get; set; }
        public string image { get; set; }
        public string real_name { get; set; }
        public string api_detail_url { get; set; }
        public string deck { get; set; }
        public int fame { get; set; }
    }

}
