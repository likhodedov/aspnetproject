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
       [ResponseType(typeof(RequestModelWebAPI))]
        public IHttpActionResult PostRequest(RequestModelWebAPI model)//,byte[] Image)
       {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //RequestModel model2=new RequestModel();
           // model2.Name = model.Email;
            dg.RequestModelWebAPI.Add(model);
            dg.SaveChanges();
            return Ok(model);
        }
    }
}
