using Mooshak2.Models.Entity;
using Mooshak2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;




namespace Mooshak2.Services
{
    public class LoginService
    {

        private ApplicationDbContext _db;

        public LoginService()
        {
            _db = new ApplicationDbContext();
        }

        public static string nameOfLoggedInUser = "";
        
        public static int userRole = 0;

        


        public int Authenticate(string name, string password)
        {
            
            foreach (var item in _db.Students)
            {
                if (name == item.userName && password == item.password)
                {
                    
                    return 1;
                }
                  
            }

            foreach (var item in _db.Teachers)
            {
                if (name == item.userName && password == item.password)
                {
                   
                    return 2;
                }
                   
            }

            foreach (var item in _db.Admins)
            {
                if (name == item.userName && password == item.password)
                {
                   
                   return 3;
                }
                   
            }

            return 404;

        }

        public string GetPathForAssignments()
        {
            string root = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            root = root.Remove(root.Length - 3);
            string path = "StudentAssignments\\";
            string wholePath = root + path;
            wholePath = wholePath.Remove(0, 6);

            return wholePath;
        }
    }
}

