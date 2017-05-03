using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pidevPMT.Mvc.Models
{
    public class ProjectEventModels
    {


        [Key]
        public int id { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        public string title { get; set; }
   
    }
}