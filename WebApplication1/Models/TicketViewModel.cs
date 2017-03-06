using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TicketViewModel
    {
        public int id { get; set; }
        public string email { get; set; }
        public string description { get; set; }
        public List<string> PathForImg { get; set; }
    }
}