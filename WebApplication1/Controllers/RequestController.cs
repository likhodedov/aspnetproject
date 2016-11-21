using System;
using System.Collections.Generic;
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
       [ResponseType(typeof(RequestModelWebAPI))]
        public IHttpActionResult PostRequest(RequestModelWebAPI model)
       {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.RequestModel.Add(model);
           // db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }
    }
}
