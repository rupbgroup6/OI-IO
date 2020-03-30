using System;
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

        public int insertInfo(UserInfo ui)
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

            String cStr = BuildInsertCommandInfo(ui);      // helper method to build the insert string

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

        }//insert UserInforamtion

        //--------------------------------------------------------------------
        // Build the Insert UserInfo command String
        //--------------------------------------------------------------------
        private String BuildInsertCommandInfo(UserInfo ui)
        {
            String command;
 
            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}' ,'{2}', '{3}')", ui.Age, ui.Gender, ui.Education, ui.Job);
            String prefix = "INSERT INTO TBUserInfo " + "(Age, Gender, Education, Job,) ";
            command = prefix + sb.ToString();

            return command;
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

        }//insert Users

        //--------------------------------------------------------------------
        // Build the Insert Users command String
        //--------------------------------------------------------------------
        private String BuildInsertCommandUsers(User u)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}' ,'{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", u.UserId, u.Password, u.Email, u.Admin, u.Age, u.Gender, u.Job, u.Education);
            String prefix = "INSERT INTO TBUsers " + "(UserId, Password, Email, Admin, Age, Gender, Job, Education) ";
            command = prefix + sb.ToString();

            return command;
        }

        public int insertAnswer(Answer a)
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

            String cStr = BuildInsertCommandAnswers(a);      // helper method to build the insert string

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

        }//insert Users

        //--------------------------------------------------------------------
        // Build the Insert Answers command String
        //--------------------------------------------------------------------
        private String BuildInsertCommandAnswers(Answer a)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}', '{2}')", a.UserId, a.AnswerNum, a.QuestionId);
            String prefix = "INSERT INTO TBUsers " + "(UserId, Answer, QuestionId) ";
            command = prefix + sb;

            return command;
        }


        //--------------------------------------------------------------------------------------------------
        // This method gets the UserInfo 
        //--------------------------------------------------------------------------------------------------
        public List<User> GetUserInfo(int id)
        {
            List<User> ui = new List<User>();
            SqlConnection con = null;
            try
            {
                con = connect("DBConnectionString");
                String selectSTR = "select * from TBUsers where UserId=" + id;
                SqlCommand cmd = new SqlCommand(selectSTR, con);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    User u = new User();

                    u.Age = Convert.ToInt32(dr["Age"]);
                    u.Gender = Convert.ToString(dr["Gender"]);
                    u.Education = Convert.ToString(dr["Education"]);
                    u.Job = Convert.ToString(dr["Job"]);
                    string Date = Convert.ToString(dr["Date"]);
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
                    a.AnswerNum = Convert.ToInt32(dr["Answer"]);

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

    }
}