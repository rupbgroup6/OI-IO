using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication13.Models.DAL;

namespace WebApplication13.Models
{
    public class User
    {
        int userId;
        int password;
        string email;
        Boolean admin;

        public int Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public bool Admin { get => admin; set => admin = value; }
        public int UserId { get => userId; set => userId = value; }

        public User()
        {

        }

        public User(int userId, int password, string email, bool admin)
        {
            UserId = userId;
            Password = password;
            Email = email;
            Admin = false;
        }

        public int insert()
        {
            DBservices dbs = new DBservices();
            int rowEffected = dbs.insertUser(this);
            return rowEffected;
        }
    }
}