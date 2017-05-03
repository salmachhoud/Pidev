
using pro.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using pidevPMT.Mvc.Models;
using pidevPMT.service;
using pidevPMT.data.Models;
using pidevPMT.Mvc.Helpers;

namespace pidevPMT.Mvc.Controllers
{
    public class ReservationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        ReservationService service = null;
        ProjectEventService service1 = null;
        UserService service2 = null;
        public ReservationController()
        {
            service = new ReservationService();
            service1 = new ProjectEventService();
            service2 = new UserService();
        }

        // GET: Tasks
        public ActionResult Index()
        {
            List<reservationModels> EM = new List<reservationModels>();
            foreach (var item in service.GetAllreservation())
            {
                EM.Add(
                    new reservationModels
                    {
                        id=item.id,
                        title = item.title,
                        eventproject_id = item.eventproject_id,
                      
                        user_id = item.user_id





                    });
            }
            return View(EM);
        }

        //print actions








        // GET: Tasks/Create
        public ActionResult Create()
        {
            var reservationModels = new reservationModels();
            List<eventproject> events = service1.GetAllevent().ToList();
            reservationModels.events = events.ToSelectListItem();
            List<user> users = service2.GetAlluser().ToList();
            reservationModels.users = users.ToSelectListItems();


            return View(reservationModels);
        }

        // POST: Tasks/Create
        [HttpPost]
        public ActionResult Create(reservationModels t)
        {

            reservation e = new reservation
            {
                title = t.title,
              
                user_id = t.user_id,
                eventproject_id = t.eventproject_id



            };
            service.createreservation(e);
            service.Commit();
            return RedirectToAction("Index");
        }


        // GET: Tasks/Edit/5
        public ActionResult Edit(int id)
        {reservation e = service.GetById(id);
            reservationModels em = new reservationModels
            {
                title=e.title,
               
             

            };
            List<eventproject> events = service1.GetAllevent().ToList();
           em.events = events.ToSelectListItem();
            List<user> users = service2.GetAlluser().ToList();
            em.users = users.ToSelectListItems();
            return View(em);
        }

        // POST: Tasks/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            reservation e = service.GetById(id);


            try
            {
                service.Update(e);
                UpdateModel(e);

                service.Commit();
                return RedirectToAction("Index");


            }
            catch
            {


                return View(e);
            }
        }
        // GET: Tasks/Delete/5
        public ActionResult Delete(int id)
        {
            reservation e = service.GetById(id);
            if (e == null)
            {
                return HttpNotFound();
            }
            reservationModels em = new reservationModels
            {
                title = e.title,
               
                user_id = e.user_id,
                eventproject_id = e.eventproject_id
               

              

            };

            return View(em);
        }

        // POST: Tasks/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            reservation e = service.GetById(id);


            service.deletereservation(e);
            service.SaveChange();
            return RedirectToAction("Index");
        }
    }
}