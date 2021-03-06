﻿using Mooshak2.Models.Entity;
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
    }
}

