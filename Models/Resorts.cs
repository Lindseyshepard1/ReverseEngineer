using System;
using System.Collections.Generic;

namespace WinterReverse.Models
{
    public partial class Resorts
    {
        public int ResortId { get; set; }
        public string ResortName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Url { get; set; }
    }
}
