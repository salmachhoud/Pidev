
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pidevPMT.Mvc.Models
{
    public class reservationModels
    {
        public int id { get; set; }
        public string title { get; set; }
       
        public Nullable<int> eventproject_id { get; set; }
        public IEnumerable<SelectListItem> events{ get; set; }
        public Nullable<long> user_id { get; set; }
        public IEnumerable<SelectListItem> users { get; set; }
    }
}