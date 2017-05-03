using System;
using System.Collections.Generic;

namespace pidevPMT.data.Models
{
    public partial class challenge
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Nullable<int> reward_id { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> BeginDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    }
}
