using System;
using System.Collections.Generic;

namespace pidevPMT.data.Models
{
    public partial class project
    {
        public int Id { get; set; }
        public string category { get; set; }
        public Nullable<double> cost { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> enddate { get; set; }
        public string name { get; set; }
        public Nullable<int> numberofparticipants { get; set; }
        public Nullable<System.DateTime> startdate { get; set; }
    }
}
