using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication13.Models.DAL;

namespace WebApplication13.Models
{
    public class UserInfo
    {
        int userId;
        int age;
        string gender;
        string education;
        string job;

        public int Age { get => age; set => age = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Education { get => education; set => education = value; }
        public string Job { get => job; set => job = value; }
        public int UserId { get => userId; set => userId = value; }

        public UserInfo()
        {

        }

        public UserInfo(int userId, int age, string gender, string education, string job)
        {
            UserId = userId;
            Age = age;
            Gender = gender;
            Education = education;
            Job = job;
        }

        public int insert()
        {
            DBservices dbs = new DBservices();
            int rowEffected = dbs.insertInfo(this);
            return rowEffected;
        }

        public List<UserInfo> GetUserInfo()
        {
            List<UserInfo> temp = new List<UserInfo>();
            DBservices dbs = new DBservices();
            temp = dbs.GetUserInfo();
            return temp;
        }
    }
}