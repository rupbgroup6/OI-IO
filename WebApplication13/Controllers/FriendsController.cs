using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class FriendsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("api/Friends/GetFriendReq/{userId}")]
        public IEnumerable<Friend> Get(string userId)
        {
            List<Friend> fl = new List<Friend>();
            Friend f = new Friend();
            fl = f.CheckFriendReq(userId);
            return fl;
        }

        [HttpPost]
        [Route("api/Friends/GetFeeds/{id}")]
        public IEnumerable<Friend> Post(int id)
        {
            List<Friend> fl = new List<Friend>();
            Friend f = new Friend();
            fl = f.getFeeds(id);
            return fl;
        }

        // GET api/<controller>/5
        public IEnumerable<Friend> Get(int id)
        {
            List<Friend> fl = new List<Friend>();
            Friend f = new Friend();
            fl = f.GetFriends(id);
            return fl;
        }

        // POST api/<controller>
        public int Post([FromBody]Friend f)
        {
            return f.AddFriend(f.UserId, f.FriendId);
        }


        [HttpPost]
        [Route("api/Friends/acceptFriend")]
        public int Post([FromBody]int[] ids)
        {
            Friend f = new Friend();
            return f.AcceptFriend(ids[0], ids[1]);
        }

        // PUT api/<controller>/5
        public int Put([FromBody]Friend f)
        {
            return f.giveFeedback();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        [HttpDelete]
        [Route("api/Friends/DeleteFriend")]
        public int Delete([FromBody]Friend f)
        {
            return f.DeleteFriend();
        }

        [HttpDelete]
        [Route("api/Friends/DeleteFriendReq")]
        public int Delete([FromBody]int[] ids)
        {
            
            Friend f = new Friend();
            return f.DeleteFriendReq(ids[0], ids[1]);
            
        }
    }
}