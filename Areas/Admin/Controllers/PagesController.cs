using DataLayer1;
using System;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ACMS.Areas.Admin.Controllers
{
    [Authorize]
    public class PagesController : Controller
    {
        private IPageRepository PR;
        private IPageGroupRepository IPR;
        private AcmsCOntext db = new AcmsCOntext();

        public PagesController()
        {
            PR = new PageRepository(db);
            IPR = new PageGroupRepository(db);
        }

        // GET: Admin/Pages
        public ActionResult Index()
        {

            return View(PR.GetAllPage());
        }

        // GET: Admin/Pages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }
        [ValidateInput(false)]
        // GET: Admin/Pages/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(IPR.GetAllGroups(), "GroupID", "GroupTitle");
            return View();
        }

        // POST: Admin/Pages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageID,GroupID,Title,ShowDescription,Text,Visit,ImageCaption,ShowinSlider,CreateDate,Tags")] Page page, HttpPostedFileBase ImgUp)
        {
            if (ModelState.IsValid)
            {
                page.Visit = 0;
                page.CreateDate = DateTime.Now;
                if (ImgUp != null)
                {
                    page.ImageCaption = Guid.NewGuid() + Path.GetExtension(ImgUp.FileName);
                    ImgUp.SaveAs(Server.MapPath("/PageImages/" + page.ImageCaption));
                }
                PR.InsertPage(page);
                PR.Save();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(db.PageGroups, "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // GET: Admin/Pages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = PR.GetPageById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(IPR.GetAllGroups(), "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // POST: Admin/Pages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "PageID,GroupID,Title,ShowDescription,Text,Visit,ImageCaption,ShowinSlider,CreateDate,Tags")] Page page, HttpPostedFileBase ImgUp)
        {
            if (ModelState.IsValid)
                page.CreateDate = DateTime.Now;

            {
                if (ImgUp != null)
                {
                    if (page.ImageCaption != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/PageImages/" + page.ImageCaption));
                    }
                    page.ImageCaption = Guid.NewGuid() + Path.GetExtension(ImgUp.FileName);
                    ImgUp.SaveAs(Server.MapPath("/PageImages/" + page.ImageCaption));
                }
                PR.UpdatePage(page);
                PR.Save();
               

                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(db.PageGroups, "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // GET: Admin/Pages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: Admin/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Page page = db.Pages.Find(id);
            db.Pages.Remove(page);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
