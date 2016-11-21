using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RequestModelWebAPIContext : DbContext
    {
        public RequestModelWebAPIContext()
       : base("DefaultConnection")
        { }

        public DbSet<RequestModelWebAPI> RequestModelWebAPI { get; set; }
    }
}