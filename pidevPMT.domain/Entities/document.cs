using System;
using System.Collections.Generic;

namespace pidevPMT.data.Models
{
    public partial class document
    {
        public int id { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public Nullable<int> project_id { get; set; }
    }
}
