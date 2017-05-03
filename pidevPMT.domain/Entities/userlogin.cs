using System;
using System.Collections.Generic;

namespace pidevPMT.data.Models
{
    public partial class userlogin
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public long UserId { get; set; }
    }
}
