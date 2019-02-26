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
   public class AdminPageViewDAL
    {

        static string conStr = string.Empty;
        SqlConnection con = null;
        SqlCommand cmd = null;

        static AdminPageViewDAL()
        {
            conStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        }

        public AdminPageViewDAL()
        {
            con = new SqlConnection(conStr);
        }
        public DataTable ViewAdminDetails_DAL()
        {
            DataTable dtView = null;
            try
            {
                cmd = new SqlCommand("Project_5.usp_ViewAdmin", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dtView = new DataTable();
                    dtView.Load(dr);
                }
            }
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
            return dtView;
        }


    }
}
