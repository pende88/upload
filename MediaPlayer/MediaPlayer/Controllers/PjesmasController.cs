using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MediaPlayer.Models;
using System.IO;

namespace MediaPlayer.Controllers
{
    public class PjesmasController : Controller
    {
        private MediaPlayerContext db = new MediaPlayerContext();

        // GET: Pjesmas
        public ActionResult Index()
        {
            return View(db.Pjesmas.ToList());
        }

        // GET: Pjesmas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pjesma pjesma = db.Pjesmas.Find(id);
            if (pjesma == null)
            {
                return HttpNotFound();
            }
            return View(pjesma);
        }

        // GET: Pjesmas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pjesmas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Lokacija,Naziv,Zanr,Artist,Album,TrackNumber")] Pjesma pjesma)
        {
            if (ModelState.IsValid)
            {
                db.Pjesmas.Add(pjesma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }



            return View(pjesma);
        }

        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }


        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }

        }



            // GET: Pjesmas/Edit/5
            public ActionResult Edit(int? id)
            {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pjesma pjesma = db.Pjesmas.Find(id);
            if (pjesma == null)
            {
                return HttpNotFound();
            }
            return View(pjesma);
            }

        // POST: Pjesmas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Lokacija,Naziv,Zanr,Artist,Album,TrackNumber")] Pjesma pjesma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pjesma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pjesma);
        }

        // GET: Pjesmas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pjesma pjesma = db.Pjesmas.Find(id);
            if (pjesma == null)
            {
                return HttpNotFound();
            }
            return View(pjesma);
        }

        // POST: Pjesmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pjesma pjesma = db.Pjesmas.Find(id);
            db.Pjesmas.Remove(pjesma);
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
