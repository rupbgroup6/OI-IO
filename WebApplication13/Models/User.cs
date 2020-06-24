using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication13.Models.DAL;

namespace WebApplication13.Models
{
    public class User
    {
        private int userId;
        private string password;
        private string email;
        private bool admin;
        private int age;
        private string gender;
        private string education;
        private string job;
        private DateTime dateStamp;
        private string profile;
        private float scoreA;
        private float scoreB;
        private float avgSay1;
        private float avgSay2;
        private float avgSay3;
        private float avgSay4;
        private float avgSay5;
        private bool secondTime;

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
        public float AvgSay1 { get => avgSay1; set => avgSay1 = value; }
        public float AvgSay2 { get => avgSay2; set => avgSay2 = value; }
        public float AvgSay3 { get => avgSay3; set => avgSay3 = value; }
        public float AvgSay4 { get => avgSay4; set => avgSay4 = value; }
        public float AvgSay5 { get => avgSay5; set => avgSay5 = value; }
        public bool SecondTime { get => secondTime; set => secondTime = value; }

        public User()
        {

        }

        public User( string password, string email, bool admin, int age, string gender, string education, string job, DateTime dateStamp,float scoreA, float scoreB, string profile, float avgSay1, float avgSay2, float avgSay3, float avgSay4, float avgSay5, bool secondTime)
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
            AvgSay1 = avgSay1;
            AvgSay2 = avgSay2;
            AvgSay3 = avgSay3;
            AvgSay4 = avgSay4;
            AvgSay5 = avgSay5;
            SecondTime = secondTime;
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

        public int UpdateSayingeUser()
        {
            DBservices dbs = new DBservices();
            int rowEffected = dbs.UpdateSayingUser(this);
            return rowEffected;
        }

        public List<User> GetUserByEmail(string email)
        {
            List<User> temp = new List<User>();
            DBservices dbs = new DBservices();
            temp = dbs.GetUserByEmail(email);
            return temp;
        }
    }
}