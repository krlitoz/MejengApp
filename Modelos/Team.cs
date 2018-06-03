using System;
using System.Collections.Generic;

namespace MejengApp.Models
{
    
    public class Team
    {
        public string name { get; set; }
        public string crestUrl { get; set; }
        //public string fixtures { get; set; }
        //public string players { get; set; }
        public Dictionary<string, Dictionary<string, Object>> _links { get; set; }


    }
}
