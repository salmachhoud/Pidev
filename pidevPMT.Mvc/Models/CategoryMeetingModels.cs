using pidevPMT.domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pidevPMT.Mvc.Models
{
    public class CategoryMeetingModels
    {
        public int Id { get; set; }
     
        public string Name { get; set; }
        public virtual ICollection<meeting> list { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}