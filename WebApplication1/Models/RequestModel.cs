﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RequestModel
    {
        public int Id { get; set; }
        public string Email { get; set; } 
        public string Description { get; set; } 
        public string Source { get; set; }
    }
}