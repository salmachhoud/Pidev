
using pidevPMT.data.Models;
using pidevPMT.domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pidevPMT.Mvc.Models
{
    public class MeetingModels
    {
        public int Id { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Description Required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Title Required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "EndDate Required")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> EndDate { get; set; }
       
        [Required(ErrorMessage = "StartDate Required")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> StartDate { get; set; }
        [Required(ErrorMessage = "Image Required")]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }
        public IEnumerable<SelectListItem> Meetings { get; set; }
        public bool Private { get; set; }
        public Nullable<int> CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual categorymeeting categorymeeting { get; set; }
        public virtual ICollection<user> UsersM { get; set; }

    }
}