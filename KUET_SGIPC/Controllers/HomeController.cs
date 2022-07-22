using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KUET_SGIPC.Models;
using System.Web.Helpers;
using System.Net;
using System.Net.Mail;

namespace KUET_SGIPC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SliderDB db = new SliderDB();
            var data = (from d in db.ImageTables select d).ToList();

            NoticePannel dbNotice = new NoticePannel();

            var notice = (from d in dbNotice.NoticeTbl select d).ToList();

            string message = "";

            foreach(var item in notice)
            {
                message += (item.Title+": "+ item.Notice+". ");
            }

            ViewBag.Notice = message;
            return View(data);
        }

        public ActionResult LoadGallery()
        {
            GalleryPannel db = new GalleryPannel();
            var result = (from d in db.Gallery select d).ToList();
            return View(result);
        }
        [Authorize]
        public ActionResult Contest()
        {
            ContestPannel db = new ContestPannel();
            var result = (from d in db.ContestTable select d).ToList();
            return View(result);

        }
        [Authorize]
        public ActionResult PastContest()
        {
            PastContestEntities db = new PastContestEntities();
            var result = (from d in db.PastContestTbl select d).ToList();
            return View(result);

        }

        public ActionResult Blog()
        {
            BlogPannel db = new BlogPannel();
            var result = (from d in db.BlogTable select d).ToList();
            return View(result);
        }
        [Authorize]
        public ActionResult BlogDetails(int id)
        {
            BlogTable blog = new BlogTable();

            using (BlogPannel db = new BlogPannel())
            {

                blog = db.BlogTable.Where(x => x.Id == id).FirstOrDefault();

            }

            return View(blog);
        }
        [Authorize]
        public ActionResult Resourses()
        {
            ResoursePannelEntities db = new ResoursePannelEntities();
            var result = (from d in db.ResourseTable select d).ToList();
            return View(result);
        }
        public ActionResult Others()
        {

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Contact(EmailContact a)
        {
            MailMessage mm = new MailMessage(a.Email, "rupok1807003@stud.kuet.ac.bd");
            mm.Subject = a.Subject;
            mm.Body = a.FullName+"\n"+ a.Message;
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("rupok1807003@stud.kuet.ac.bd", "rupok162365");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);

            ViewBag.Message = "Email sent successfully!!!";
            return View();
        }
        


    }
}