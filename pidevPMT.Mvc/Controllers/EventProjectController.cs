


using pidevPMT.Mvc.Models;
using pidevPMT.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pidevPMT.data.Models;



namespace pidevPMT.Mvc.Controllers
{
    public class EventProjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        ProjectEventService service = null;
        public EventProjectController()
        {
            service = new ProjectEventService();

        }
        // GET: event
        public ActionResult Index()
        {
            return View(service.GetAllevent());

        }

        // GET: event/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reward/Create
        [HttpPost]
        public ActionResult Create(ProjectEventModels eventproject)
        {
           eventproject r = new eventproject();
            

            if (ModelState.IsValid)
            {
               
                r.title = eventproject.title;
                r.StartDate = eventproject.StartDate;
                r.EndDate = eventproject.EndDate;

                service.createProjectEvent(r);
                //return RedirectToAction("Index");


            }
            return RedirectToAction("Index");
        }

        // GET: event/Edit/5
        public ActionResult Edit(int id)
        {
         eventproject   r = service.GetProjectEventById(id);
            ProjectEventModels cvm = new ProjectEventModels
            {
               


            };

            return View(cvm);
        }

        // POST: event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProjectEventModels eventModel)
        {
            try
            {
              eventproject c = service.GetProjectEventById(id);
               
                c.StartDate = eventModel.StartDate;
                c.EndDate = eventModel.EndDate;
                c.title = eventModel.title;


                service.updateProjectEvent(c);
                service.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: event/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: event/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, eventproject r)
        {
            try
            {
                if (ModelState.IsValid)

                {

                    r = service.GetProjectEventById(id);
                    service.deleteProjectEvent(r);
                    service.Commit();
                }
                return RedirectToAction("Index");



            }
            catch
            {
                return View();
            }
        }
    }
}