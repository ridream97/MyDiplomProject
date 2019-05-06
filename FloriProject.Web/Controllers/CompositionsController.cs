using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FloriProject.Data;
using FloriProject.Data.Context;
using FloriProject.Web.Models;

namespace FloriProject.Web.Controllers
{
    public class CompositionsController : Controller
    {
        private FloriDbContext db = new FloriDbContext();

        // GET: Compositions
        public ActionResult Index()
        {
            return View(db.Compositions.ToList());
        }

        // GET: Compositions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Composition composition = db.Compositions.Find(id);
            if (composition == null)
            {
                return HttpNotFound();
            }
            return View(composition);
        }

        // GET: Compositions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Compositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Photo")] Composition composition)
        {
            if (ModelState.IsValid)
            {
                db.Compositions.Add(composition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(composition);
        }

        // GET: Compositions/Edit/5
       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var composition = db.Compositions.Where(x => x.Id == id).Select(x => new EditCompVM
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Photo = x.Photo
            }).SingleOrDefault();
            if (composition == null)
            {
                return HttpNotFound();
            }
            return View(composition);
        }

        // POST: Compositions/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditCompVM compVM)
        {
            if (compVM.NewPhoto != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(compVM.NewPhoto.InputStream))
                {
                    imageData = binaryReader.ReadBytes(compVM.NewPhoto.ContentLength);
                }
                // установка массива байтов
                compVM.Photo = imageData;

            }

            if (ModelState.IsValid)
            {
                var composition = db.Compositions.Find(compVM.Id);
                composition.Name = compVM.Name;
                composition.Description = compVM.Description;
                if (compVM.NewPhoto != null)
                {
                    composition.Photo = compVM.Photo;
                }

                db.Entry(composition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
       
        public ActionResult DeleteConfirmed(int id)
        {
            Composition composition = db.Compositions.Find(id);
            db.Compositions.Remove(composition);
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
