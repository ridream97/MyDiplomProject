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
    public class BouquetsController : Controller
    {
        private FloriDbContext db = new FloriDbContext();

        // GET: Bouquets
        public ActionResult Index()
        {
            return View(db.Bouquets.ToList());
        }

        // GET: Bouquets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bouquet bouquet = db.Bouquets.Find(id);
            if (bouquet == null)
            {
                return HttpNotFound();
            }
            return View(bouquet);
        }

        // GET: Bouquets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bouquets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Photo")] Bouquet bouquet)
        {
            if (ModelState.IsValid)
            {
                db.Bouquets.Add(bouquet);
                db.SaveChanges();
                return RedirectToAction("_");
            }

            return View(bouquet);
        }

        // GET: Bouquets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bouquet = db.Bouquets.Where(x=>x.Id==id).Select(x=>new EditBouquetVM {
                Id=x.Id,
                Name=x.Name,
                Description=x.Description,
                Photo=x.Photo
            }).SingleOrDefault();
            if (bouquet == null)
            {
                return HttpNotFound();
            }
            return View(bouquet);
        }

        // POST: Bouquets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( EditBouquetVM bouquetVM)
        {
            if (bouquetVM.NewPhoto != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(bouquetVM.NewPhoto.InputStream))
                {
                    imageData = binaryReader.ReadBytes(bouquetVM.NewPhoto.ContentLength);
                }
                // установка массива байтов
                bouquetVM.Photo = imageData;

            }

            if (ModelState.IsValid)
            {
                var bouquet = db.Bouquets.Find(bouquetVM.Id);
                bouquet.Name = bouquetVM.Name;
                bouquet.Description = bouquetVM.Description;
                if (bouquetVM.NewPhoto != null)
                {
                    bouquet.Photo = bouquetVM.Photo;
                }

                db.Entry(bouquet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }




        // GET: Bouquets/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Bouquet bouquet = db.Bouquets.Find(id);

        //    //if (bouquet == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    //else
        //    //{
        //        db.Bouquets.Remove(bouquet);
        //        db.SaveChanges();
        //    //}
        //     return RedirectToAction("Index");
        //}

        // POST: Bouquets/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Bouquet bouquet = db.Bouquets.Find(id);
            db.Bouquets.Remove(bouquet);
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
