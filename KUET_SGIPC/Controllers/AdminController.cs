using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KUET_SGIPC.Models;
using System.IO;

namespace KUET_SGIPC.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
         //GET: Admin
        public ActionResult Index()
        {
           return View();
        }

        public ActionResult AddMarqueeNotice()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMarqueeNotice(NoticeTbl note)
        {
            using (NoticePannel db = new NoticePannel())
            {
                db.NoticeTbl.Add(note);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.Upload_Notice = "Notice Uploaded Successfully!!!";
            }
            return View();
        }


        public ActionResult GetMarqueeNoticeList()
        {
            NoticePannel db = new NoticePannel();
            var data = db.NoticeTbl.ToList();

            return View(data);
        }

        public ActionResult GetMarqueeNotice(int id)
        {
            NoticeTbl notice = new NoticeTbl();

            using (NoticePannel db = new NoticePannel())
            {

                notice = db.NoticeTbl.Where(x => x.Id == id).FirstOrDefault();

            }

            return View(notice);
        }

        public ActionResult EditMarqueeNotice(int id)
        {
            NoticeTbl notice = new NoticeTbl();

            using (NoticePannel db = new NoticePannel())
            {

                notice = db.NoticeTbl.Where(x => x.Id == id).FirstOrDefault();

            }

            return View(notice);

        }


        [HttpPost]
        public ActionResult EditMarqueeNotice(NoticeTbl it)
        {

            bool f = EditSubmitMarqueeNotice(it.Id, it);
            if (f)
            {
                return RedirectToAction("GetMarqueeNoticeList");
            }

            return View();

        }


        public bool EditSubmitMarqueeNotice(int id, NoticeTbl it)
        {

            using (NoticePannel db = new NoticePannel())
            {
                var notice = db.NoticeTbl.FirstOrDefault(x => x.Id == id);

                if (notice != null)
                {
                    notice.Title = it.Title;
                    notice.Notice = it.Notice;
                   
                }

                db.SaveChanges();
                return true;
            }


        }

        public ActionResult DeleteMarquee(NoticeTbl notice)
        {
            bool f = DeleteMarqueeNotice(notice.Id);

            if (f)
            {
                return RedirectToAction("GetMarqueeNoticeList");
            }

            return View();
        }

        [HttpPost]
        public bool DeleteMarqueeNotice(int id)
        {
            using (var db = new NoticePannel())
            {
                var notice = db.NoticeTbl.FirstOrDefault(x => x.Id == id);

                if (notice != null)
                {
                    db.NoticeTbl.Remove(notice);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }

        }




        public ActionResult AddContest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContest(ContestTable contest)
        {
            using (ContestPannel db = new ContestPannel())
            {
                db.ContestTable.Add(contest);
                db.SaveChanges();
                ModelState.Clear();

                ViewBag.Result = "Successfully uploaded!!!!";

            }
                return View();
        }


        public ActionResult GetContestList()
        {
            ContestPannel db = new ContestPannel();
            var data = db.ContestTable.ToList();

            return View(data);
        }

        public ActionResult GetContest(int id)
        {
            ContestTable contest = new ContestTable();

            using (ContestPannel db = new ContestPannel())
            {

                contest = db.ContestTable.Where(x => x.Id == id).FirstOrDefault();

            }

            return View(contest);
        }

        public ActionResult EditContest(int id)
        {
            ContestTable contest = new ContestTable();

            using (ContestPannel db = new ContestPannel())
            {

                contest = db.ContestTable.Where(x => x.Id == id).FirstOrDefault();

            }

            return View(contest);

        }


        [HttpPost]
        public ActionResult EditContest(ContestTable it)
        {
           
            bool f = EditSubmitContest(it.Id, it);
            if (f)
            {
                return RedirectToAction("GetContestList");
            }

            return View();

        }


        public bool EditSubmitContest(int id, ContestTable it)
        {

            using (ContestPannel db = new ContestPannel())
            {
                var contest = db.ContestTable.FirstOrDefault(x => x.Id == id);

                if (contest != null)
                {
                    contest.Title = it.Title;
                    contest.Link = it.Link;
                    contest.Date = it.Date;
                    contest.Time = it.Time;
                    contest.Status = it.Status;
                }

                db.SaveChanges();
                return true;
            }


        }

        public ActionResult DeleteContest(ContestTable contest)
        {
            bool f = DeleteContestFromList(contest.Id);

            if (f)
            {
                return RedirectToAction("GetContestList");
            }

            return View();
        }

        [HttpPost]
        public bool DeleteContestFromList(int id)
        {
            using (var db = new ContestPannel())
            {
                var contest = db.ContestTable.FirstOrDefault(x => x.Id == id);

                if (contest != null)
                {
                    db.ContestTable.Remove(contest);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }

        }




        public ActionResult AddPastContest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPastContest(PastContestTbl contest)
        {
            using (PastContestEntities db = new PastContestEntities())
            {
                db.PastContestTbl.Add(contest);
                db.SaveChanges();
                ModelState.Clear();

                ViewBag.Result = "Successfully uploaded!!!!";

            }
            return View();
        }


        public ActionResult GetPastContestList()
        {
            PastContestEntities db = new PastContestEntities();
            var data = db.PastContestTbl.ToList();

            return View(data);
        }

        public ActionResult GetPastContest(int id)
        {
            PastContestTbl contest = new PastContestTbl();

            using (PastContestEntities db = new PastContestEntities())
            {

                contest = db.PastContestTbl.Where(x => x.Id == id).FirstOrDefault();

            }

            return View(contest);
        }

        public ActionResult EditPastContest(int id)
        {
            PastContestTbl contest = new PastContestTbl();

            using (PastContestEntities db = new PastContestEntities())
            {

                contest = db.PastContestTbl.Where(x => x.Id == id).FirstOrDefault();

            }

            return View(contest);

        }


        [HttpPost]
        public ActionResult EditPastContest(PastContestTbl it)
        {

            bool f = EditSubmitPastContest(it.Id, it);
            if (f)
            {
                return RedirectToAction("GetPastContestList");
            }

            return View();

        }


        public bool EditSubmitPastContest(int id, PastContestTbl it)
        {

            using (PastContestEntities db = new PastContestEntities())
            {
                var contest = db.PastContestTbl.FirstOrDefault(x => x.Id == id);

                if (contest != null)
                {
                    contest.Title = it.Title;
                    contest.Link = it.Link;
                    contest.Date = it.Date;
                    contest.Time = it.Time;
                    contest.Status = it.Status;
                }

                db.SaveChanges();
                return true;
            }


        }

        public ActionResult DeletePastContest(PastContestTbl contest)
        {
            bool f = DeletePastContestList(contest.Id);

            if (f)
            {
                return RedirectToAction("GetPastContestList");
            }

            return View();
        }

        [HttpPost]
        public bool DeletePastContestList(int id)
        {
            using (var db = new PastContestEntities())
            {
                var contest = db.PastContestTbl.FirstOrDefault(x => x.Id == id);

                if (contest != null)
                {
                    db.PastContestTbl.Remove(contest);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }

        }








        [HttpGet]
        public ActionResult AddGalleryImage()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddGalleryImage(Gallery gallery)
        {
            string fileName = Path.GetFileNameWithoutExtension(gallery.ImageFile.FileName);
            string extenstion = Path.GetExtension(gallery.ImageFile.FileName);

            fileName = fileName + extenstion;

            gallery.Path = "~/Image/Gallery/" + fileName;

            fileName = Path.Combine(Server.MapPath("~/Image/Gallery/"), fileName);
            gallery.ImageFile.SaveAs(fileName);

            using (GalleryPannel db = new GalleryPannel())
            {
                db.Gallery.Add(gallery);
                db.SaveChanges();
                ViewBag.Message = "Uploaded successfully.";

            }
            ModelState.Clear();
            return View();
        }

        [HttpGet]
        public ActionResult GetGallery(int id)
        {
            Gallery image = new Gallery();

            using (GalleryPannel db = new GalleryPannel())
            {

                image = db.Gallery.Where(x => x.Id == id).FirstOrDefault();

            }

            return View(image);

        }
        public ActionResult GetAllImageList()
        {
            GalleryPannel db = new GalleryPannel();
            var data = db.Gallery.ToList();

            return View(data);
        }

        public ActionResult EditImage(int id)
        {
            Gallery image = new Gallery();

            using (GalleryPannel db = new GalleryPannel())
            {

                image = db.Gallery.Where(x => x.Id == id).FirstOrDefault();

            }

            return View(image);

        }
        [HttpPost]
        public ActionResult EditImage(Gallery it)
        {


            string path = "~/Image/Gallery/" + it.Path;
            it.Path = path;

            bool f = EditSubmitImage(it.Id, it);
            if (f)
            {
                return RedirectToAction("GetAllImageList");
            }

            return View();

        }


        public bool EditSubmitImage(int id, Gallery it)
        {

            using (GalleryPannel db = new GalleryPannel())
            {
                var image = db.Gallery.FirstOrDefault(x => x.Id == id);

                if (image != null)
                {
                    image.Title = it.Title;
                    image.Path = it.Path;
                }

                db.SaveChanges();
                return true;
            }


        }

        public ActionResult DeleteGalleryImage(Gallery image)
        {
            bool f = DeleteGalleryImageFromList(image.Id);

            if (f)
            {
                return RedirectToAction("GetAllImageList");
            }

            return View();
        }

        [HttpPost]
        public bool DeleteGalleryImageFromList(int id)
        {
            using (var db = new GalleryPannel())
            {
                var image = db.Gallery.FirstOrDefault(x => x.Id == id);

                if (image != null)
                {
                    db.Gallery.Remove(image);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }

        }

        public ActionResult AddBlog()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddBlog(BlogTable blog)
        {
            if(blog!=null)
            {
                using (BlogPannel db = new BlogPannel())
                {
                    db.BlogTable.Add(blog);
                    db.SaveChanges();
                    ModelState.Clear();
                    ViewBag.Blog_Upload = "Uploaded successfully!!!";
                }
                
            }
            return View();
        }


        [HttpGet]
        public ActionResult GetBlog(int id)
        {
            BlogTable blog = new BlogTable();

            using (BlogPannel db = new BlogPannel())
            {

                blog = db.BlogTable.Where(x => x.Id == id).FirstOrDefault();

            }

            return View(blog);

        }
        public ActionResult GetBlogList()
        {
            BlogPannel db = new BlogPannel();
            var data = db.BlogTable.ToList();

            return View(data);
        }

        public ActionResult EditBlog(int id)
        {
            BlogTable blog = new BlogTable();

            using (BlogPannel db = new BlogPannel())
            {

                blog = db.BlogTable.Where(x => x.Id == id).FirstOrDefault();

            }

            return View(blog);

        }
        [HttpPost]
        public ActionResult EditBlog(BlogTable it)
        {


            bool f = EditSubmitBlog(it.Id, it);
            if (f)
            {
                return RedirectToAction("GetBlogList");
            }

            return View();

        }


        public bool EditSubmitBlog(int id, BlogTable it)
        {

            using (BlogPannel db = new BlogPannel())
            {
                var blog = db.BlogTable.FirstOrDefault(x => x.Id == id);

                if (blog != null)
                {
                    blog.Title = it.Title;
                    blog.ShortDes = it.ShortDes;
                    blog.LongDes = it.LongDes;
                    blog.Date = it.Date;
                    blog.Time = it.Time;
                }

                db.SaveChanges();
                return true;
            }


        }

        public ActionResult DeleteBlog(BlogTable blog)
        {
            bool f = DeleteBlogFromList(blog.Id);

            if (f)
            {
                return RedirectToAction("GetBlogList");
            }

            return View();
        }

        [HttpPost]
        public bool DeleteBlogFromList(int id)
        {
            using (var db = new BlogPannel())
            {
                var blog = db.BlogTable.FirstOrDefault(x => x.Id == id);

                if (blog != null)
                {
                    db.BlogTable.Remove(blog);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }

        }

        public ActionResult AddResourse()
        {
            Session.Remove("res");
            return View();
        }
        [HttpPost]
        public ActionResult AddResourse(ResourseTable resourse )
        {
            using (ResoursePannelEntities db = new ResoursePannelEntities())
            {
                db.ResourseTable.Add(resourse);
                db.SaveChanges();
                ModelState.Clear();
                Session["res"] = "resourse added !!!";
            }

                return View();
        }

       
        public ActionResult GetResourseList()
        {
            ResoursePannelEntities db = new ResoursePannelEntities();
            var data = db.ResourseTable.ToList();

            return View(data);
        }

        public ActionResult EditResourse(int id)
        {
            ResourseTable res = new ResourseTable();

            using (ResoursePannelEntities db = new ResoursePannelEntities())
            {

                res = db.ResourseTable.Where(x => x.Id == id).FirstOrDefault();

            }

            return View(res);

        }
        [HttpPost]
        public ActionResult EditResourse(ResourseTable it)
        {


            bool f = EditSubmitResourse(it.Id, it);
            if (f)
            {
                return RedirectToAction("GetResourseList");
            }

            return View();

        }


        public bool EditSubmitResourse(int id, ResourseTable it)
        {

            using (ResoursePannelEntities db = new ResoursePannelEntities())
            {
                var res = db.ResourseTable.FirstOrDefault(x => x.Id == id);

                if (res != null)
                {
                    res.Title = it.Title;
                    res.Link = it.Link;
                   
                }

                db.SaveChanges();
                return true;
            }


        }

        public ActionResult DeleteResourse(BlogTable blog)
        {
            bool f = DeleteResourseFromList(blog.Id);

            if (f)
            {
                return RedirectToAction("GetResourseList");
            }

            return View();
        }

        [HttpPost]
        public bool DeleteResourseFromList(int id)
        {
            using (var db = new ResoursePannelEntities())
            {
                var res = db.ResourseTable.FirstOrDefault(x => x.Id == id);

                if (res != null)
                {
                    db.ResourseTable.Remove(res);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }

        }


    }
}