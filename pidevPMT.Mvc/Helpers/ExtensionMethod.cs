

using pidevPMT.data.Models;
using pidevPMT.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pidevPMT.Mvc.Helpers
{
    public static class ExtensionMethod
    {
        public static IEnumerable<SelectListItem> ToSelectListItem
            (this IEnumerable<eventproject> numevent)
        {
            return numevent.OrderBy(c => c.id).Select(r => new SelectListItem
            {
                Text = r.title,
                Value = r.id.ToString()
            }
                );
        }
        public static IEnumerable<SelectListItem> ToSelectListItems
            (this IEnumerable<user> numevent)
        {
            return numevent.OrderBy(c => c.Id).Select(r => new SelectListItem
            {
                Text = r.Login,
                Value = r.Id.ToString()
            }
                );
        }

        /////
        public static IEnumerable<SelectListItem> ToSelectListItemM(this IEnumerable<categorymeeting> numReal)
        {
            return
                numReal.OrderBy(m => m.Id)
               .Select(c =>
             new SelectListItem
             {
                 Text = c.Name,
                 Value = c.Id.ToString()
             }
              );
        }


    }
}