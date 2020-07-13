using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication13.Models.DAL;

namespace WebApplication13.Models
{
    public class Profiler
    {
        private DateTime dateStamp;
        private string profile;


        public DateTime DateStamp { get => dateStamp; set => dateStamp = value; }
        public string Profile { get => profile; set => profile = value; }


        public Profiler()
        {

        }

        public Profiler(DateTime dateStamp, string profile)
        {

            DateStamp = dateStamp;
            Profile = profile;

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