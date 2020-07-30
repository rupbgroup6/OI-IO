using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication13.Models.DAL;

namespace WebApplication13.Models
{
    public class Friend
    {
        private int userId;
        private int friendId;
        private string friendEmail;
        private string status;
        string friendsGuess;

        public Friend()
        {

        }

        public int UserId { get => userId; set => userId = value; }
        public int FriendId { get => friendId; set => friendId = value; }
        public string FriendEmail { get => friendEmail; set => friendEmail = value; }
        public string Status { get => status; set => status = value; }
        public string FriendsGuess { get => friendsGuess; set => friendsGuess = value; }

        public List<Friend> GetFriends(int id)
        {
            List<Friend> temp = new List<Friend>();
            DBservices dbs = new DBservices();
            temp = dbs.GetFriends(id);
            return temp;
        }

        public List<Friend> getFeeds(float id)
        {
            List<Friend> temp = new List<Friend>();
            DBservices dbs = new DBservices();
            temp = dbs.getFeeds(id);
            return temp;
        }

        public List<Friend> CheckFriendReq(string userId)
        {
            List<Friend> temp = new List<Friend>();
            DBservices dbs = new DBservices();
            temp = dbs.CheckFriendReq(userId);
            return temp;
        }

        public int DeleteFriend()
        {
            DBservices dbs = new DBservices();
            int rowEffected = dbs.DeleteFriend(this.UserId, this.FriendId);
            rowEffected += dbs.DeleteFriend(this.FriendId, this.UserId);
            return rowEffected;
        }

        public int giveFeedback()
        {
            DBservices dbs = new DBservices();
            int rowEffected = dbs.giveFeedback(this);
            return rowEffected;
        }

        public int DeleteFriendReq(int userId, int friendId)
        {
            DBservices dbs = new DBservices();
            int rowEffected = dbs.DeleteFriendReq(friendId, userId);
            rowEffected += dbs.DeleteFriend(userId, friendId);
            return rowEffected;
        }

        public int AddFriend(int userId, int friendId)
        {
            DBservices dbs = new DBservices();
            int rowEffected = dbs.AddFriend(userId, friendId);
            rowEffected += dbs.AddFriendReq(userId, friendId);
            return rowEffected;
        }

        public int AcceptFriend(int userId, int friendId)
        {
            DBservices dbs = new DBservices();
            int rowEffected = dbs.AcceptFriend(userId, friendId);
            rowEffected += dbs.DeleteFriendReq(friendId, userId);
            rowEffected += dbs.AcceptFriendReq(userId, friendId);
            return rowEffected;
        }
    }
}