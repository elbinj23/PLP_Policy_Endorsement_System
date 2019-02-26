using Policy_Exception;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policy_DAL
{
    public class LoginDal
    {

        static string conStr = string.Empty;
        SqlConnection con = null;
        SqlCommand cmd = null;

        static LoginDal()
        {
            conStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        }

        public LoginDal()
        {
            con = new SqlConnection(conStr);
        }
        public bool login(int loginid, string password)
        {
            bool isCustomer = false;
            try
            {
                cmd = new SqlCommand("Project_5.uspLogin", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoginId", loginid);
                cmd.Parameters.AddWithValue("LoginPassword", password);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    isCustomer = true;
                }
                return isCustomer;

            }

            catch (PolicyException) { throw; }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        public bool LoginAdmin(string loginid, string password)
        {
            bool isCustomer = false;
            try
            {
                cmd = new SqlCommand("Project_5.uspLoginadmin", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoginId", loginid);
                cmd.Parameters.AddWithValue("LoginPassword", password);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    isCustomer = true;
                }
                return isCustomer;

            }

            catch (PolicyException) { throw; }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

        }
    }
}
