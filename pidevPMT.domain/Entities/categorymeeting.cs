using System;
using System.Collections.Generic;

namespace pidevPMT.domain.Entities
{
    public partial class categorymeeting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<meeting> list { get; set; }
    }
}
