using System;
using System.Collections.Generic;

namespace pidevPMT.data.Models
{
    public partial class trainingsession
    {
        public int id { get; set; }
        public Nullable<System.DateTime> enddate { get; set; }
        public string name { get; set; }
        public Nullable<System.DateTime> startdate { get; set; }
        public int teamnumber { get; set; }
    }
}
