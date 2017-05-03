using System;
using System.Collections.Generic;

namespace pidevPMT.data.Models
{
    public partial class certification
    {
        public int id { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public Nullable<int> trainingsession_id { get; set; }
        public Nullable<long> user_id { get; set; }
    }
}
