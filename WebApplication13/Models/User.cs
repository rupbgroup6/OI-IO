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
        string password;
        string email;
        Boolean admin;
        int age;
        string gender;
        string education;
        string job;
        DateTime dateStamp;

        public int Age { get => age; set => age = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Education { get => education; set => education = value; }
        public string Job { get => job; set => job = value; }
        public int UserId { get => userId; set => userId = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public bool Admin { get => admin; set => admin = value; }
        public DateTime DateStamp { get => dateStamp; set => dateStamp = value; }

        public User()
        {

        }

        public User(int userId, string password, string email, bool admin, int age, string gender, string education, string job, DateTime dateStamp)
        {
            UserId = userId;
            Password = password;
            Email = email;
            Admin = false;
            Age = age;
            Gender = gender;
            Education = education;
            Job = job;
            DateStamp = dateStamp;
        }

        public int insertUser()
        {
            DBservices dbs = new DBservices();
            int rowEffected = dbs.insertUser(this);
            return rowEffected;
        }

        public List<User> GetUserInfo()
        {
            List<User> temp = new List<User>();
            DBservices dbs = new DBservices();
            temp = dbs.GetUserInfo();
            return temp;
        }
    }
}