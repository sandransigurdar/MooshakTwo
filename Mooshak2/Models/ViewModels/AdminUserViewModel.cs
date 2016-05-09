using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak2.Models.Entity;

namespace Mooshak2.Models.ViewModels
{
    public class AdminUserViewModel
    {
        public List<Student> students { get; set; }
        public List <Teacher> teachers { get; set; }
    }
}