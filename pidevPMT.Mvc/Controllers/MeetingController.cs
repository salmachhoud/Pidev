
using pidevPMT.domain.Entities;
using pidevPMT.Mvc.Helpers;
using pidevPMT.Mvc.Models;
using pidevPMT.service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pidev.Mvc.Controllers
{
    public class MeetingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        MeetingService service = null;
        CategoryService service1 = null;
        public MeetingController()
        {
            service = new MeetingService();
            service1 = new CategoryService();
        }
        // GET: Meeting
        public ActionResult Index()
        {
            return View(service.GetAllMeetings());
        }
        public ActionResult ImageAffichage()
        {
            var rewardd = service.GetAllMeetings();
            List<MeetingModels> fVM = new List<MeetingModels>();
            foreach (var item in rewardd)
            {
                fVM.Add(
                    new MeetingModels
                    {
                        Id = item.Id,
                        Description = item.Description,
                        Image = item.Image,
                        Title = item.Title

                    });
            }
            return View(fVM);

        }

        // GET: Meeting/Details/5
        public ActionResult Details(int id)
        {

            return View(service.GetById(id));
        }

        // GET: Meeting/Create
        public ActionResult Create()
        {

            MeetingModels ch = new MeetingModels();
            ch.Meetings = service1.GetAllCat().ToSelectListItemM();
            return View(ch);
        }

        // POST: Meeting/Create
        [HttpPost]
        public ActionResult Create(MeetingModels meet, HttpPostedFileBase image)
        {

            meeting c = new meeting();
            c.Image = image.FileName;
            c.Title = meet.Title;
            c.Private = meet.Private;
            c.Description = meet.Description;
            c.StartDate = meet.StartDate;
            c.EndDate = meet.EndDate;
            c.CategoryID = meet.CategoryID;

            if (ModelState.IsValid)
            {
                service.createMeeting(c);
            }
            var path = Path.Combine(Server.MapPath("~/content/upload"), image.FileName);
            image.SaveAs(path);
            return RedirectToAction("Index");
        }
        // GET: Meeting/Edit/5
        public ActionResult Edit(int id)
        {
            meeting sc = service.GetMeetingById(id);
            MeetingModels cvm = new MeetingModels
            {
                Title = sc.Title,
                EndDate = sc.EndDate,
                StartDate = sc.StartDate,
                Description = sc.Description,
            };

            return View(cvm);
        }

        // POST: Meeting/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MeetingModels sc)
        {
            {
                meeting c = service.GetMeetingById(id);

                c.EndDate = sc.EndDate;
                c.StartDate = sc.StartDate;
                c.Description = sc.Description;
                c.Title = sc.Title;
                service.updateMeeting(c);
                service.Commit();

                return RedirectToAction("Index");

            }
        }

        // GET: Meeting/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Meeting/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, meeting m)
        {
            if (ModelState.IsValid)

            {
                m = service.GetMeetingById(id);
                service.deleteMeeting(m);
                service.Commit();
            }
            return RedirectToAction("Index");
        }
        //
        public ActionResult FinishedMeeting()
        {
            var acti = service.GetFinishedMeetingyByDate();
            return View(acti);
        }
        public ActionResult NoneFinishedMeeting()
        {
            var act = service.GetNoneFinishedMeetingByDate();
            return View(act);
        }
       
        public ActionResult LastWeekMeetings()
        {
            var act = service.GetLastWeekMeetings();
            return View(act);
        }
        public ActionResult PrivateMeetings()
        {
            var Meetings = service.GetPrivateMeetings();
            return View(Meetings);
        }
        public ActionResult PublicMeetings()
        {
            var Meetings = service.GetPublicMeetings();
            return View(Meetings);
        }
        public ActionResult ExportToExcel()
        {
            var gv = new GridView();
            gv.DataSource = service.GetAllMeetings();
            gv.DataBind(); //Binds Datasource to the GridVue
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return View(service.GetAllMeetings());

        }
        /////////////////////Search/////////////
        public ActionResult AdvancedSearch(string SearchStringMeeting, string SearchStringCategory, string s3)
        {
            IEnumerable<meeting> listeSubCate = service.GetAllMeetings();
            if (!String.IsNullOrEmpty(SearchStringMeeting))
            {
                listeSubCate = listeSubCate.Where(m => m.Title.Contains(SearchStringMeeting)).ToList();
            }
            if (!String.IsNullOrEmpty(SearchStringCategory))
            {
                    listeSubCate = listeSubCate.Where(m => m.categorymeeting.Name.Contains(SearchStringCategory)).ToList();
            }
            
            
            return View(listeSubCate);
        }


    }
}
