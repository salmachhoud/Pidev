using pidevPMT.domain.Entities;
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
    
    public class CategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        MeetingService service1 = null;
        CategoryService service = null;
        public CategoryController()
        {
            service = new CategoryService();
            service1 = new MeetingService();
        }
        // GET: Category
        public ActionResult Index()
        {
            return View(service.GetAllCat());
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryMeetingModels cat)
        {
            categorymeeting m = new categorymeeting();
            m.Name = cat.Name;

            if (ModelState.IsValid)
            {
                service.createCategory(m);
                //return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            categorymeeting sc = service.GetCategoryMById(id);
            CategoryMeetingModels cvm = new CategoryMeetingModels
            {

                Name = sc.Name

            };

            return View(cvm);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategoryMeetingModels cat)
        {
            categorymeeting c = service.GetCategoryMById(id);

            c.Name = cat.Name;
            service.updateCategory(c);
            service.Commit();
            return RedirectToAction("Index");
        }
        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, categorymeeting m)
        {
            if (ModelState.IsValid)

            {
              /*  m = service.GetCategoryMById(id);
                service.deleteCategory(m);
                service.Commit();
                */
                service.delete(id);
                service.Commit();
                
            }
            return RedirectToAction("Index");
        }
        //
        public ActionResult GetMeetingByCategory(int id)
        {
            var tasks = service1.GetMeetingByCategory(id);

            return View(tasks.ToList());
        }
        //
        public ActionResult MeetingCountByCategory(int id)
        {
            var Meetings = service.MeetingCountByCategory(id);
            return View(Meetings);
        }
        public ActionResult AdvancedSearchCateg(string EmailSerach)
        {
            IEnumerable<categorymeeting> listeSubCate = service.GetAllCat();
           
            if (!String.IsNullOrEmpty(EmailSerach))
            {
  
              //  listeSubCate = listeSubCate.Where(x=>x.list.Select(c=>c.UsersM.Select(s=>s.Email)).Contains(EmailSerach)).ToList();

            }


            return View(listeSubCate);
        }
        public ActionResult ExportToExcelCategory()
        {
            var gv = new GridView();
            gv.DataSource = service.GetAll();
            gv.DataBind();

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

            return View(service.GetAllCat());

        }
        //
        public ActionResult AdvancedSearchUser(string SearchStringUser)
        {
            IEnumerable<categorymeeting> list = service.GetAllCat();
            if (!String.IsNullOrEmpty(SearchStringUser))
            {
                list = list.Where(m => m.list.Select(x => x.UsersM


                  .Select(p => p.Email)
                  .Contains(SearchStringUser))
                  .SingleOrDefault());
            }
            


            return View(list);
        }


    }
}
