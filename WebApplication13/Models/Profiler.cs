using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication13.Models.DAL;

namespace WebApplication13.Models
{
    public class Profiler
    {
        
        private string profile;
        private int total;


       
        public string Profile { get => profile; set => profile = value; }
        public int Total { get => total; set => total = value; }

        public Profiler()
        {

        }

        public Profiler(string profile, int total)
        {
            
            Profile = profile;
            Total = total;
        }

        public List<Profiler> GetAllProfilesByDate(DateTime s, DateTime e)
        {
            List<Profiler> temp = new List<Profiler>();
            DBservices dbs = new DBservices();
            temp = dbs.GetAllProfilesByDate(s, e);
            return temp;
        }

        public List<Profiler> GetAllProfiles()
        {
            List<Profiler> temp = new List<Profiler>();
            DBservices dbs = new DBservices();
            temp = dbs.GetAllProfiles();
            return temp;
        }
    }
}