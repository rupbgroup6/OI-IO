using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication13.Models.DAL;

namespace WebApplication13.Models
{
    public class Connections
    {
        private int userA;
        private int userB;
        private string emailA;
        private string emailB;
        private string profileA;
        private string profileB;

        public string ProfileB { get => profileB; set => profileB = value; }
        public string ProfileA { get => profileA; set => profileA = value; }
        public int UserA { get => userA; set => userA = value; }
        public int UserB { get => userB; set => userB = value; }
        public string EmailA { get => emailA; set => emailA = value; }
        public string EmailB { get => emailB; set => emailB = value; }

        public List<Connections> GetAllCons()
        {
            List<Connections> temp = new List<Connections>();
            DBservices dbs = new DBservices();
            temp = dbs.GetAllCons();
            return temp;
        }
    }
}