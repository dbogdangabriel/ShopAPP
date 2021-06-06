using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server_proiect
{
    public class PC
    {
        public int PCID { get; set; }
        public string CPU { get; set; }
        public string GPU { get; set; }
        public string RAM { get; set; }
        public string Storage { get; set; }
        public bool Storage_type { get; set; }
        public string Price { get; set; }
        public string ImageUrlPC { get; set; }
    }
}