using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    
    public class RequestController : ApiController
    {
        RequestModelContext db = new RequestModelContext();
        RequestModelWebAPIContext dg = new RequestModelWebAPIContext();
        [HttpGet]
        public IHttpActionResult ReturnObject(int id)
        {

            RequestModel model = db.RequestModel.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);

        }

        [HttpPost]
       [ResponseType(typeof(RequestModel))]
        public IHttpActionResult PostRequest(RequestModel model)//,byte[] Image)
       {
            Image image = Image.FromFile(@"C:\untitled.png");
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            byte[] b = memoryStream.ToArray();
           // Console.WriteLine(model.Email);
           // Console.WriteLine(model.Description);
           // Console.WriteLine(model.Image);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model.Image == null) {

                model.Image = b; }
            RequestModel model2=new RequestModel();
            //model2.Name = model.Email;
           // model2.Description = model.Description;
           // model2.Image = Image;
            //db.RequestModel.Add(model2);
          //  db.SaveChanges();
            db.RequestModel.Add(model);
            db.SaveChanges();
            //return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
            return Ok(model);
        }
    }




}
