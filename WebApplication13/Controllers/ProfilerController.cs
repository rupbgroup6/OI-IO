using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication13.Models;


namespace WebApplication13.Controllers
{
    public class ProfilerController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Profiler> Get()
        {
            List<Profiler> pr = new List<Profiler>();
            Profiler p = new Profiler();
            pr = p.GetAllProfiles();
            return pr;
        }
        [HttpGet]
        [Route("api/profiler/byDate/{date}")]
        public IEnumerable<Profiler> Get(string date)
        {
            string date1 = "";
            string date2 = "";
            bool sep = true;
            for (int i = 0; i < date.Length; i++)
            {
                if (date[i] != '@')
                {
                    if (sep)
                    {
                        date1 += date[i];
                    }
                    else
                    {
                        date2 += date[i];
                    }
                }
                else
                {
                    sep = false;
                }
            }
            List<Profiler> pr = new List<Profiler>();
            Profiler p = new Profiler();
            pr = p.GetAllProfilesByDate(date1, date2);
            return pr;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}