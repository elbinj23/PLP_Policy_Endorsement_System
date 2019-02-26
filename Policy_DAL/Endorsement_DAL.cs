using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Policy_Entities;
using Policy_Exception;


namespace Policy_DAL
{
    public class Endorsement_DAL
    {

        static string conStr = string.Empty;
        SqlConnection con = null;
        SqlCommand cmd = null;

        static Endorsement_DAL()
        {
            conStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        }

        public Endorsement_DAL()
        {
            con = new SqlConnection(conStr);
        }

        public bool AddStatus(EndorsementDetails sboj)
        {
            bool result = false;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "Project_5.usp_EndorsementStatus";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
               
                cmd.Parameters.AddWithValue("@CustomerId", sboj.CustomerId);
                cmd.Parameters.AddWithValue("@EndorsementId", sboj.EndorsementId);
                cmd.Parameters.AddWithValue("@Status", sboj.EndorsementStatus);
               

                con.Open();
                int noOfRowsAffected = cmd.ExecuteNonQuery();
                if (noOfRowsAffected == 1)
                {
                    result = true;
                }
            }
            catch (PolicyException) { throw; }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
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
            return result;
        }

        public DataTable ViewStatus(int customerId)
        {
            DataTable dtView = null;
            try
            {
                cmd = new SqlCommand("Project_5.usp_ViewEndorsement", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
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
