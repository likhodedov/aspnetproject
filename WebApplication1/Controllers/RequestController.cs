using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    
    public class RequestController : ApiController
    {
        RequestModelContext db = new RequestModelContext();

       


        [System.Web.Http.HttpGet]
        public IHttpActionResult ReturnObject(int id)
        {

            RequestModel model = db.RequestModel.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);

        }

        //  [HttpPost]
        // [ResponseType(typeof(RequestModel))]
        //  public IHttpActionResult PostRequest(RequestModel model)//,byte[] Image)
        // {
        //   Image image = Image.FromFile(@"C:\untitled.png");
        //   System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
        //   image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
        // byte[] b = memoryStream.ToArray();
        // Console.WriteLine(model.Email);
        // Console.WriteLine(model.Description);
        // Console.WriteLine(model.Image);
        //  if (!ModelState.IsValid)
        //  {
        //  return BadRequest(ModelState);
        // }
        //   if (model.Image == null) {

        //    model.Image = b; }
        //   RequestModel model2=new RequestModel();
        //model2.Name = model.Email;
        // model2.Description = model.Description;
        // model2.Image = Image;
        //db.RequestModel.Add(model2);
        //  db.SaveChanges();
        //  db.RequestModel.Add(model);
        //  db.SaveChanges();
        //return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        // return Ok(model);
        //}


        //public async Task<HttpResponseMessage> PostFormData(RequestModelWebAPI model)
        //{
        //     //Check if the request contains multipart/form-data.


        //    string root = HttpContext.Current.Server.MapPath("~/App_Data/"+model.Email);
        //    var provider = new MultipartFormDataStreamProvider(root);

        //    try
        //    {
        //        // Read the form data.
        //        await Request.Content.ReadAsMultipartAsync(provider);

        //        // This illustrates how to get the file names.
        //        foreach (MultipartFileData file in provider.FileData)
        //        {
        //            Trace.WriteLine(file.Headers.ContentDisposition.FileName);
        //            Trace.WriteLine("Server file path: " +model.Email+ file.LocalFileName);
        //        }
        //        return Request.CreateResponse(HttpStatusCode.OK);
        //   }
        //    catch (System.Exception e)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
        //    }
        //}
        //Загрузка файла с данными через модель

        //public HttpResponseMessage Post(string title, string description)
        //{
        //    var httpRequest = HttpContext.Current.Request;
        //    if (httpRequest.Files.Count < 1)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }
        //    String currentPath = "C:\\uploads\\" + title + "\\" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + "\\";
        //    if (!Directory.Exists(currentPath))
        //        Directory.CreateDirectory(currentPath);
        //    foreach (string file in httpRequest.Files)
        //    {
        //        var postedFile = httpRequest.Files[file];
        //        var filePath = currentPath + Path.GetExtension(postedFile.FileName);
        //        postedFile.SaveAs(filePath);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.Created);
        //}
        [System.Web.Http.Authorize]
        public HttpResponseMessage Post(string email, string description)
        {
            ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;
            RequestModel model = new RequestModel();
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count < 1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            
            String currentPath = "C:\\uploads\\" + email + "\\" + Guid.NewGuid().ToString() + "\\";
               if (!Directory.Exists(currentPath))
                    Directory.CreateDirectory(currentPath);

            model.Email = email;
            model.Description = description;
            model.Source = currentPath;
            db.RequestModel.Add(model);
            db.SaveChanges();
            //foreach (string file in httpRequest.Files)
            for (int i=0;i<httpRequest.Files.Count;i++)
            {
                var postedFile = httpRequest.Files[i];
                var filePath =currentPath + postedFile.FileName;
                postedFile.SaveAs(filePath);
            }
            
            
            return Request.CreateResponse(HttpStatusCode.Created);
        }

       
        [System.Web.Http.ActionName("postTest")]
        public string Post()
        {
            var httpRequest = HttpContext.Current.Request;
            //var x=httpRequest.
            return "ss";
        }





    }


}






