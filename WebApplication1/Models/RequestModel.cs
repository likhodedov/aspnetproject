using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; } // название картинки
        public string Description { get; set; } // название картинки
        public byte[] Image { get; set; }
    }
}