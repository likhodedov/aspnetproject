using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RequestModelContext : DbContext
    {
        public RequestModelContext()
       : base("DefaultConnection")
        { }

        public DbSet<RequestModel> RequestModel { get; set; }
    }
}