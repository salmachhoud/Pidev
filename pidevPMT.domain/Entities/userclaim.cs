using System;
using System.Collections.Generic;

namespace pidevPMT.data.Models
{
    public partial class userclaim
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
