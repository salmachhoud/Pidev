using System;
using System.Collections.Generic;

namespace pidevPMT.data.Models
{
    public partial class task
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Name { get; set; }
        public Nullable<int> NumberOfParticipants { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<int> project_id { get; set; }
    }
}
