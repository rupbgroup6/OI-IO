using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication13.Models.DAL;

namespace WebApplication13.Models
{
    public class Answer
    {
        int answerNum;
        int userId;
        int questionId;

        static public List<Answer> list = new List<Answer>();

        public int AnswerNum { get => answerNum; set => answerNum = value; }
        public int QuestionId { get => questionId; set => questionId = value; }
        public int UserId { get => userId; set => userId = value; }


        public Answer()
        {
                
        }

        public Answer(int userId, int answer, int questionId)
        {
            UserId = userId;
            AnswerNum = answer;
            QuestionId = questionId;
        }

        public int InsertAnswers()
        {
            DBservices dbs = new DBservices();
            int rowEffected = dbs.InsertAnswer(list);
            return rowEffected;
        }

        public List<Answer> getUserAnswers(int id)
        {
            List<Answer> temp = new List<Answer>();
            DBservices dbs = new DBservices();
            temp = dbs.getUserAnswers(id);
            return temp;
        }
    }
}