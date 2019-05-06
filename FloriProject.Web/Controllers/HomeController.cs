using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using FloriProject.Data.Context;
using FloriProject.Data;

namespace ImageDbApp.Controllers
{
    public class HomeController : Controller
    {
        FloriDbContext db = new FloriDbContext();

        public ActionResult HomePage()
        {
            return View();
        }

        public ActionResult Bouquets()
        {
            return View(db.Bouquets);
        }

        public ActionResult Compositions()
        {
            return View(db.Compositions);
        }

        public ActionResult Contact()
        {
            return View(db.Contacts);
        }
        [HttpGet]
        public ActionResult Admin()
        {
            return View();
        }



        [HttpPost]
        public ActionResult CreateBouquet(Bouquet pic, HttpPostedFileBase uploadImage)
        {
            if (uploadImage != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                // установка массива байтов
                pic.Photo = imageData;

                db.Bouquets.Add(pic);
                db.SaveChanges();

            }
            return RedirectToAction("Index","Bouquets");
        }

        [HttpPost]
        public ActionResult CreateComposition(Composition pic, HttpPostedFileBase uploadImage)
        {
            if (uploadImage != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                // установка массива байтов
                pic.Photo = imageData;

                db.Compositions.Add(pic);
                db.SaveChanges();

            }
            return RedirectToAction("Index","Compositions");
        }
    }
}