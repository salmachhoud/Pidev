using System;
using System.Collections.Generic;

namespace pidevPMT.data.Models
{
    public partial class eventproject
    {
        public int id { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public string title { get; set; }
    }
}
