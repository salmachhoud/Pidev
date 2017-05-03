using System;
using System.Collections.Generic;

namespace pidevPMT.data.Models
{
    public partial class reservation
    {
        public int id { get; set; }
        public string title { get; set; }
        public string username { get; set; }
        public Nullable<int> eventproject_id { get; set; }
        public Nullable<long> user_id { get; set; }
    }
}
