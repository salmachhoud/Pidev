using pidevPMT.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace pidev.Mvc.Controllers
{
    public class ChartController : Controller
    {
        CategoryService service = null;
        MeetingService serviceMeeting = null;
        public ChartController()
        {
            service = new CategoryService();
            serviceMeeting = new MeetingService();
        }
        // GET: Chart
        public ActionResult Index()
        {
            var ListMeeting = serviceMeeting.GetAllMeetings().GroupBy(x => x.CategoryID).ToList();
            //on va declarer deux tableaux
            int[] CountMeeting = new int[ListMeeting.Count()];//nb des listes des meetings selon catId
            string[] nameCat = new string[ListMeeting.Count()];//
            int i = 0;
            foreach (var group in ListMeeting) //parcourir liste des Meeting et compter les meetings 
            {
                int nbMeeting = 0;
                foreach (var item in group)//combien de meeting dans chaque categorie 
                {
                    nbMeeting++; 
                }
                CountMeeting[i] = nbMeeting;
                var cat = service.GetCategoryMById(group.Key.Value);//Key est la categorieId
                nameCat[i] = cat.Name;
                i++;
            }
            string myTheme =
                @"<Chart BackColor=""Transparent"">
                    <ChartAreas> 
                            <ChartArea Name=""Default"" BackColor=""Transparent"">
                            </ChartArea>
                    </ChartAreas>
            </Chart>";
            new Chart(width: 500, height: 500, theme: myTheme).AddTitle("Statistic of Meetings By Categories")
                     .AddSeries(
                     chartType: "StackedColumn ",
                     xValue: nameCat,
                     yValues: CountMeeting)
                     .Write("png");
            return null;
        }

        // GET: Chart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chart/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Chart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Chart/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Chart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Chart/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
    

    }

}

