using Mooshak2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak2.Models.HomePageViewModel;
using Mooshak2.Models.Entity;

namespace Mooshak2.Services
{

    public class AssignmentService
    {
        private ApplicationDbContext _db;

        public AssignmentService()
        {
            _db = new ApplicationDbContext();
        }
        /*
        public GetAllAssignments()
        {


            return X;
        }*/
    }
}