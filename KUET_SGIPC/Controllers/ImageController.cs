using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KUET_SGIPC.Models;
using System.IO;

namespace KUET_SGIPC.Controllers
{
    public class ImageController : Controller
    {
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(ImageTable it)
        {
            string fileName = Path.GetFileNameWithoutExtension(it.ImageFile.FileName);
            string extenstion = Path.GetExtension(it.ImageFile.FileName);

            fileName = fileName + extenstion;

            it.ImagePath = "~/Image/" + fileName;

            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            it.ImageFile.SaveAs(fileName);

            using (SliderDB db = new SliderDB())
            {
                db.ImageTables.Add(it);
                db.SaveChanges();
                ViewBag.Message = "Uploaded successfully.";

            }
            ModelState.Clear();
            return View();
        }
        [HttpGet]
        public ActionResult GetAllSlider(int id)
        {
            ImageTable image = new ImageTable();

            using (SliderDB db = new SliderDB())
            {

                image = db.ImageTables.Where(x => x.Id == id).FirstOrDefault();
               
            }

            return View(image);

        }
       public ActionResult GetAllSliderList()
       {
            SliderDB db = new SliderDB();
            var data = db.ImageTables.ToList();

          return View(data);
        }

        public ActionResult EditSlider(int id)
        {
            ImageTable image = new ImageTable();

            using (SliderDB db = new SliderDB())
            {

                image = db.ImageTables.Where(x => x.Id == id).FirstOrDefault();

            }

            return View(image);

        }
        [HttpPost]
        public ActionResult EditSlider(ImageTable it)
        {
            

            string path = "~/Image/" + it.ImagePath;
            it.ImagePath = path;

            bool f = EditSubmitSlider(it.Id, it);
            if(f)
            {
                return RedirectToAction("GetAllSliderList");
            }

            return View();

        }

       
        public bool EditSubmitSlider(int id,ImageTable it)
        {
           
            using (SliderDB db = new SliderDB())
            {
                var image = db.ImageTables.FirstOrDefault(x => x.Id == id);

              if(image!=null)
                {
                    image.Title = it.Title;
                    image.ImagePath = it.ImagePath;
                }

                db.SaveChanges();
                return true;
            }
           

        }

        public ActionResult Delete(ImageTable image)
        {
            bool f = DeleteSlider(image.Id);

            if(f)
            {
                return RedirectToAction("GetAllSliderList");
            }

            return View();
        }

        [HttpPost]
        public bool DeleteSlider(int id)
        {
            using (var db = new SliderDB())
            {
                var image = db.ImageTables.FirstOrDefault(x => x.Id == id);

                if(image !=null)
                {
                    db.ImageTables.Remove(image);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }

        }


    }
}