﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.Entity
{
    public class Teacher
    {
        
        public int Id { get; set; }
        public string name { get; set; }
        public string userName { get; set; }
        public string ssn { get; set; }            
        public string email { get; set; }
        public string password { get; set; }
        public int role { get; set; }
        //HVAÐ MEÐ COURSE HÉR
    }
}