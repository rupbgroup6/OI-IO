﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Configuration;

namespace WebApplication13.Models.DAL
{
    public class DBservices
    {

        public SqlDataAdapter da;
        public DataTable dt;

        public DBservices()
        {

        }

        //--------------------------------------------------------------------------------------------------
        // This method creates a connection to the database according to the connectionString name in the web.config 
        //--------------------------------------------------------------------------------------------------
        public SqlConnection connect(String conString)
        {

            // read the connection string from the configuration file
            string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }

        internal List<Profiler> GetAllProfiles()
        {
            List<Profiler> ap = new List<Profiler>();
            SqlConnection con = null;
            try
            {
                con = connect("DBConnectionString");
                String selectSTR = "select Profile, count(Profile) as Total from TBUsers group by Profile";
                SqlCommand cmd = new SqlCommand(selectSTR, con);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    Profiler p = new Profiler();

                    if (dr["DateStamp"].ToString().Length > 0)
                    {
                        string date = Convert.ToString(dr["DateStamp"]);
                        p.DateStamp = Convert.ToDateTime(date);
                    }

                    if (dr["Profile"].ToString().Length > 0)
                    {
                        p.Profile = Convert.ToString(dr["Profile"]);
                    }

                    ap.Add(p);
                }

                return ap;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }


        //---------------------------------------------------------------------------------
        // Create the SqlCommand
        //---------------------------------------------------------------------------------
        private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

            cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

            return cmd;
        }


        public int insertUser(User u)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildInsertCommandUsers(u);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int rawEffected = cmd.ExecuteNonQuery(); // execute the command
                return rawEffected;
            }
            catch (Exception ex)
            {
                throw (ex);
                // write to log
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }//insert Users

        public int UpdateProfileUser(User u)
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildUpdateProfileUserCommand(u);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int rawEffected = cmd.ExecuteNonQuery(); // execute the command
                return rawEffected;
            }
            catch (Exception ex)
            {
                return 0;
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }

        public List<User> GetUserByEmail(string email)
        {
            List<User> ui = new List<User>();
            SqlConnection con = null;
            try
            {
                con = connect("DBConnectionString");
                String selectSTR = $"select * from TBUsers where Email='{email}'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    User u = new User();
                    u.Email = Convert.ToString(dr["Email"]);
                    u.Password = Convert.ToString(dr["Password"]);
                    if (dr["Age"].ToString().Length > 0)
                    {
                        u.Age = Convert.ToInt32(dr["Age"]);
                    }
                    if (dr["Gender"].ToString().Length > 0)
                    {
                        u.Gender = Convert.ToString(dr["Gender"]);
                    }
                    if (dr["Education"].ToString().Length > 0)
                    {
                        u.Education = Convert.ToString(dr["Education"]);
                    }
                    if (dr["Job"].ToString().Length > 0)
                    {
                        u.Job = Convert.ToString(dr["Job"]);
                    }
                    if (dr["DateStamp"].ToString().Length > 0)
                    {
                        string date = Convert.ToString(dr["DateStamp"]);
                        u.DateStamp = Convert.ToDateTime(date);
                    }
                    if (dr["ScoreA"].ToString().Length > 0)
                    {
                        u.ScoreA = float.Parse(dr["ScoreA"].ToString());
                    }
                    if (dr["ScoreB"].ToString().Length > 0)
                    {
                        u.ScoreB = float.Parse(dr["ScoreB"].ToString());
                    }
                    if (dr["AvgSay1"].ToString().Length > 0)
                    {
                        u.AvgSay1 = float.Parse(dr["AvgSay1"].ToString());
                    }
                    if (dr["AvgSay2"].ToString().Length > 0)
                    {
                        u.AvgSay2 = float.Parse(dr["AvgSay2"].ToString());
                    }
                    if (dr["AvgSay3"].ToString().Length > 0)
                    {
                        u.AvgSay3 = float.Parse(dr["AvgSay3"].ToString());
                    }
                    if (dr["AvgSay4"].ToString().Length > 0)
                    {
                        u.AvgSay4 = float.Parse(dr["AvgSay4"].ToString());
                    }
                    if (dr["AvgSay5"].ToString().Length > 0)
                    {
                        u.AvgSay5 = float.Parse(dr["AvgSay5"].ToString());
                    }
                    if (dr["Profile"].ToString().Length > 0)
                    {
                        u.Profile = Convert.ToString(dr["Profile"]);
                    }
                    u.UserId = Convert.ToInt32(dr["UserId"]);
                    u.SecondTime = Convert.ToBoolean(dr["SecondTime"]);
                    u.Admin = Convert.ToBoolean(dr["Admin"]);
                    ui.Add(u);
                }

                return ui;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public int UpdateSayingUser(User u)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildUpdateSayingUserCommand(u);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int rawEffected = cmd.ExecuteNonQuery(); // execute the command
                return rawEffected;
            }
            catch (Exception ex)
            {
                return 0;
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }

        private string BuildUpdateSayingUserCommand(User u)
        {
            String command;

            // use a string builder to create the dynamic string
            String prefix = $"UPDATE TBUsers SET AvgSay1='{u.AvgSay1}', AvgSay2='{u.AvgSay2}', AvgSay3='{u.AvgSay3}', AvgSay4='{u.AvgSay4}', AvgSay5='{u.AvgSay5}', SecondTime='{u.SecondTime}' Where UserId={u.UserId}";
            command = prefix;

            return command;
        }


        //--------------------------------------------------------------------
        // updating the Users info
        //--------------------------------------------------------------------
        public int UpdateUser(User u)
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildUpdateUserCommand(u);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int rawEffected = cmd.ExecuteNonQuery(); // execute the command
                return rawEffected;
            }
            catch (Exception ex)
            {
                return 0;
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }

        //--------------------------------------------------------------------
        // Build the update Users command String
        //--------------------------------------------------------------------
        private String BuildUpdateUserCommand(User u)
        {
            String command;
            var dStamp = u.DateStamp.Year + "-" + u.DateStamp.Month + "-" + u.DateStamp.Day;
            // use a string builder to create the dynamic string
            String prefix = $"UPDATE TBUsers SET Gender='{u.Gender.ToString()}', Age='{u.Age.ToString()}',Job='{u.Job.ToString()}',Education='{u.Education.ToString()}', DateStamp='{dStamp}'  Where UserId={u.UserId}";
            command = prefix;

            return command;
        }

        //--------------------------------------------------------------------
        // Build the update Users command String
        //--------------------------------------------------------------------
        private String BuildUpdateProfileUserCommand(User u)
        {
            String command;

            // use a string builder to create the dynamic string
            String prefix = $"UPDATE TBUsers SET ScoreA='{u.ScoreA}', ScoreB='{u.ScoreB}', Profile='{u.Profile.ToString()}' Where UserId={u.UserId}";
            command = prefix;

            return command;
        }

        //--------------------------------------------------------------------
        // Build the Insert Users command String
        //--------------------------------------------------------------------
        private String BuildInsertCommandUsers(User u)
        {
            String command;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Values('{0}' ,'{1}', '{2}')", u.Email, u.Password, u.Admin);
            String prefix = "INSERT INTO TBUsers " + "(Email, Password, Admin) ";
            command = prefix + sb.ToString();

            return command;
        }

        public int InsertAnswer(List<Answer> a)
        {
            int counter = 0;
            foreach (var answer in a)
            {
                SqlConnection con;
                SqlCommand cmd;

                try
                {
                    con = connect("DBConnectionString"); // create the connection
                }
                catch (Exception ex)
                {
                    // write to log
                    throw (ex);
                }

                String cStr = BuildInsertCommandAnswers(answer);      // helper method to build the insert string

                cmd = CreateCommand(cStr, con);             // create the command

                try
                {
                    counter += cmd.ExecuteNonQuery(); // execute the command

                }
                catch (Exception ex)
                {
                    return 0;
                    // write to log
                    throw (ex);
                }

                finally
                {
                    if (con != null)
                    {
                        // close the db connection
                        con.Close();
                    }
                }
            }
            return counter;
        }//insert Answers

        //--------------------------------------------------------------------
        // Build the Insert Answers command String
        //--------------------------------------------------------------------
        private String BuildInsertCommandAnswers(Answer a)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values({0}, {1}, '{2}')", a.UserId, a.QuestionId, a.AnswerNum);
            String prefix = "INSERT INTO TBAnswers " + "(UserId, QuestionId, Answer)";
            command = prefix + sb;

            return command;
        }

        //--------------------------------------------------------------------------------------------------
        // This method gets the count of all profiles by date
        //--------------------------------------------------------------------------------------------------
        public List<Profiler> GetAllProfilesByDate(DateTime s, DateTime e)
        {
            List<Profiler> ap = new List<Profiler>();
            SqlConnection con = null;
            try
            {
                con = connect("DBConnectionString");
                String selectSTR = "select Profile, count(Profile) as Total from TBUsers where DateStamp between '"+s+"' and '"+e+"' group by Profile";
                SqlCommand cmd = new SqlCommand(selectSTR, con);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    Profiler p = new Profiler();
    
                    if (dr["DateStamp"].ToString().Length > 0)
                    {
                        string date = Convert.ToString(dr["DateStamp"]);
                        p.DateStamp = Convert.ToDateTime(date);
                    }
                
                    if (dr["Profile"].ToString().Length > 0)
                    {
                        p.Profile = Convert.ToString(dr["Profile"]);
                    }

                    ap.Add(p);
                }

                return ap;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }//Get Profiles

        //--------------------------------------------------------------------------------------------------
        // This method gets the UserInfo 
        //--------------------------------------------------------------------------------------------------
        public List<User> GetUserInfo()
        {
            List<User> ui = new List<User>();
            SqlConnection con = null;
            try
            {
                con = connect("DBConnectionString");
                String selectSTR = "select * from TBUsers";
                SqlCommand cmd = new SqlCommand(selectSTR, con);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    User u = new User();
                    u.Email = Convert.ToString(dr["Email"]);
                    u.Password = Convert.ToString(dr["Password"]);
                    if (dr["Age"].ToString().Length > 0)
                    {
                        u.Age = Convert.ToInt32(dr["Age"]);
                    }
                    if (dr["Gender"].ToString().Length > 0)
                    {
                        u.Gender = Convert.ToString(dr["Gender"]);
                    }
                    if (dr["Education"].ToString().Length > 0)
                    {
                        u.Education = Convert.ToString(dr["Education"]);
                    }
                    if (dr["Job"].ToString().Length > 0)
                    {
                        u.Job = Convert.ToString(dr["Job"]);
                    }
                    if (dr["DateStamp"].ToString().Length > 0)
                    {
                        string date = Convert.ToString(dr["DateStamp"]);
                        u.DateStamp = Convert.ToDateTime(date);
                    }
                    if (dr["ScoreA"].ToString().Length > 0)
                    {
                        u.ScoreA = float.Parse(dr["ScoreA"].ToString());
                    }
                    if (dr["ScoreB"].ToString().Length > 0)
                    {
                        u.ScoreB = float.Parse(dr["ScoreB"].ToString());
                    }
                    if (dr["AvgSay1"].ToString().Length > 0)
                    {
                        u.AvgSay1 = float.Parse(dr["AvgSay1"].ToString());
                    }
                    if (dr["AvgSay2"].ToString().Length > 0)
                    {
                        u.AvgSay2 = float.Parse(dr["AvgSay2"].ToString());
                    }
                    if (dr["AvgSay3"].ToString().Length > 0)
                    {
                        u.AvgSay3 = float.Parse(dr["AvgSay3"].ToString());
                    }
                    if (dr["AvgSay4"].ToString().Length > 0)
                    {
                        u.AvgSay4 = float.Parse(dr["AvgSay4"].ToString());
                    }
                    if (dr["AvgSay5"].ToString().Length > 0)
                    {
                        u.AvgSay5 = float.Parse(dr["AvgSay5"].ToString());
                    }
                    if (dr["Profile"].ToString().Length > 0)
                    {
                        u.Profile = Convert.ToString(dr["Profile"]);
                    }
                    u.Admin = Convert.ToBoolean(dr["Admin"]);
                    u.SecondTime = Convert.ToBoolean(dr["SecondTime"]);
                    u.UserId = Convert.ToInt32(dr["UserId"]);

                    ui.Add(u);
                }

                return ui;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }//Get UserInfo


        //--------------------------------------------------------------------------------------------------
        // This method gets Answeres of the users for the admin 
        //--------------------------------------------------------------------------------------------------
        public List<Answer> getUserAnswers(int id)
        {
            List<Answer> al = new List<Answer>();
            SqlConnection con = null;
            try
            {
                con = connect("DBConnectionString");
                String selectSTR = "select * from TBAnswers where UserId=" + id;
                SqlCommand cmd = new SqlCommand(selectSTR, con);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    Answer a = new Answer();

                    a.UserId = Convert.ToInt32(dr["UserId"]);
                    a.QuestionId = Convert.ToInt32(dr["QuestionId"]);
                    a.AnswerNum = Convert.ToString(dr["Answer"]);

                    al.Add(a);
                }

                return al;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }//get user answers



        //--------------------------------------------------------------------------------------------------
        // This method gets Questions
        //--------------------------------------------------------------------------------------------------
        public List<Question> getQuestions()
        {
            List<Question> ql = new List<Question>();
            SqlConnection con = null;
            try
            {
                con = connect("DBConnectionString");
                String selectSTR = "select * from TBQuestions";
                SqlCommand cmd = new SqlCommand(selectSTR, con);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    Question q = new Question();
                    q.KindOfQuestion = Convert.ToString(dr["KindOfQuestion"]);
                    q.QuestionSTR = Convert.ToString(dr["Question"]);
                    q.QuestionId = Convert.ToInt32(dr["QuestionId"]);
                    q.OrderView = Convert.ToInt32(dr["OrderView"]);
                    q.OrOrderView = Convert.ToInt32(dr["OrOrderView"]);
                    ql.Add(q);
                }


                return ql;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }//get Questions


        //--------------------------------------------------------------------------------------------------
        // This method insert Question for the admin 
        //--------------------------------------------------------------------------------------------------
        public int AddQuestion(Question q)
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildQuestionCommand(q);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int rawEffected = cmd.ExecuteNonQuery(); // execute the command
                return rawEffected;
            }
            catch (Exception ex)
            {
                return 0;
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }//insert Question


        //--------------------------------------------------------------------
        // Build the Insert Question!! command String
        //--------------------------------------------------------------------
        private string BuildQuestionCommand(Question q)
        {

            String command;
            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}' ,'{2}')", q.QuestionSTR, q.KindOfQuestion, q.OrderView);
            String prefix = "INSERT INTO TBQuestions " + "(Question, KindOfQuestion, OrderView) ";
            command = prefix + sb.ToString();

            return command;
        }

        //--------------------------------------------------------------------------------------------------
        // This method updates Questions for the admin 
        //--------------------------------------------------------------------------------------------------
        public int ChangeQuestion(Question q)
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildUpdateQuestionCommand(q);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int rawEffected = cmd.ExecuteNonQuery(); // execute the command
                return rawEffected;
            }
            catch (Exception ex)
            {
                return 0;
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }

        //--------------------------------------------------------------------
        // Build the update Question!! command String
        //--------------------------------------------------------------------
        private string BuildUpdateQuestionCommand(Question q)
        {

            String command;
            // use a string builder to create the dynamic string
            String prefix = $"UPDATE TBQuestions SET Question='{q.QuestionSTR.ToString()}', KindOfQuestion='{q.KindOfQuestion.ToString()}',OrderView='{q.OrderView}'  Where QuestionId={q.QuestionId}";
            command = prefix;

            return command;
        }


        //--------------------------------------------------------------------------------------------------
        // This method delets Question for the admin 
        //--------------------------------------------------------------------------------------------------
        public int deleteQuestion(int id)
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = "DELETE from TBQuestions WHERE QuestionId=" + id.ToString();      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int rawEffected = cmd.ExecuteNonQuery(); // execute the command
                return rawEffected;
            }
            catch (Exception ex)
            {
                return 0;
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }
    }
}