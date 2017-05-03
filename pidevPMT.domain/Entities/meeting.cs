using pidevPMT.data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pidevPMT.domain.Entities
{
    public partial class meeting
    {

        public int Id { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public bool Private { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }


        public Nullable<int> CategoryID { get; set; }
       
        public virtual categorymeeting categorymeeting { get; set; }

        public virtual ICollection<user> UsersM { get; set; }

    }
}
