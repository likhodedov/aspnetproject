using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    
    public class HomeController : Controller
    {
        RequestModelContext db = new RequestModelContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult SentEmail()
        {
            

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       // [Authorize(Roles = "admin")]
        public ActionResult AdminPage()
        {
            ViewBag.Message = "Your contact page.";

            return View(db.RequestModel);
        }

        
       // [Authorize(Roles = "user")]
        public ActionResult UserPage()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult UserPage(RequestModel pic, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                // установка массива байтов
                pic.Image = imageData;

                db.RequestModel.Add(pic);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(pic);
        }

        [HttpPost]
        public ActionResult sendemail(email model)
        {

            RequestModelContext db = new RequestModelContext();
            
            //var customerName = Request["customerName"];
            //var customerEmail = Request["customerEmail"];
            //var customerRequest = Request["customerRequest"];
            var errorMessage = "";
            var debuggingFlag = false;

            try
            {
                // Initialize WebMail helper
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 25;
                WebMail.EnableSsl = true;
                WebMail.UserName = "likhodedovdmitry@gmail.com";
                WebMail.Password = "20051971";
                WebMail.From = model.to;


                // Send email
                WebMail.Send(to: model.to,
                   subject: "Администратор " + model.to + " готов Вам помочь",
                   body: model.to
                );
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            return View();
        }
    }

    }
