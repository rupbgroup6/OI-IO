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
        string profile;
        float scoreA;
        float scoreB;

        public int Age { get => age; set => age = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Education { get => education; set => education = value; }
        public string Job { get => job; set => job = value; }
        public int UserId { get => userId; set => userId = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public bool Admin { get => admin; set => admin = value; }
        public DateTime DateStamp { get => dateStamp; set => dateStamp = value; }
        public string Profile { get => profile; set => profile = value; }
        public float ScoreA { get => scoreA; set => scoreA = value; }
        public float ScoreB { get => scoreB; set => scoreB = value; }

        public User()
        {

        }

        public User( string password, string email, bool admin, int age, string gender, string education, string job, DateTime dateStamp,float scoreA, float scoreB, string profile)
        {
            
            Password = password;
            Email = email;
            Admin = false;
            Age = age;
            Gender = gender;
            Education = education;
            Job = job;
            DateStamp = dateStamp;
            Profile = profile;
            ScoreA = scoreA;
            ScoreB = scoreB;
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

        public int UpdateUser()
        {
            DBservices dbs = new DBservices();
            int rowEffected = dbs.UpdateUser(this);
            return rowEffected;
        }

        public int UpdateProfileUser()
        {
            DBservices dbs = new DBservices();
            int rowEffected = dbs.UpdateProfileUser(this);
            return rowEffected;
        }
    }
}