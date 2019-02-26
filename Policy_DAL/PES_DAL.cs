using Policy_Exception;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Policy_Entities;
using System.Configuration;

namespace Policy_DAL
{
    public class PES_DAL
    {
    
        static string conStr = string.Empty;
        SqlConnection con = null;
        SqlCommand cmd = null;

        static PES_DAL()
        {
            conStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        }

        public PES_DAL()
        {
            con = new SqlConnection(conStr);
        }
        public DataTable search(int customerid, DateTime DOB, int PolicyNumber)
        {
            Customer p = null;
            DataTable dtStudent = null;
            try
            {
                cmd = new SqlCommand("Project_5.usp_SearchPolicy", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", customerid);
                cmd.Parameters.AddWithValue("@DOB", DOB);
                cmd.Parameters.AddWithValue("@PolicyNumber", PolicyNumber);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dtStudent = new DataTable();
                    dtStudent.Load(dr);

                }
                return dtStudent;
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
        public Customer DisplayCustomer_Dal(int customerId)
        {
            Customer p = null;
            try
            {
                cmd = new SqlCommand("Project_5.usp_ViewPolicy", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    p = new Customer
                    {

                        CustomerID = int.Parse(dr["CustomerId"].ToString()),
                        CustomerName = dr["CustomerName"].ToString(),
                     
                        CustomerAddress = dr["CustomerAddress"].ToString(),

                        CustomerPhoneNo = Int64.Parse(dr["CustomerPhoneNo"].ToString()),
                        Gender = dr["Gender"].ToString(),
                        DOB = DateTime.Parse(dr["Dob"].ToString()),
                        Habits = dr["Habits"].ToString(),
                        Hobbies = dr["Hobbies"].ToString(),
                        PolicyNumber = int.Parse(dr["PolicyNumber"].ToString()),
                        ProductId = int.Parse(dr["ProductId"].ToString())

                    };
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
            return p;
        }

        public bool UpdateDetails(Customer sboj, int ProductId)
        {
            bool result = false;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "Project_5.usp_UpdatePolicy1";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", sboj.CustomerID);
                cmd.Parameters.AddWithValue("@CustomerName", sboj.CustomerName);
                cmd.Parameters.AddWithValue("@CustomerAddress", sboj.CustomerAddress);
                cmd.Parameters.AddWithValue("@CustomerPhoneNo", sboj.CustomerPhoneNo);
                cmd.Parameters.AddWithValue("@Gender", sboj.Gender);
                cmd.Parameters.AddWithValue("@DOB", sboj.DOB);
                cmd.Parameters.AddWithValue("@Habits", sboj.Habits);
                cmd.Parameters.AddWithValue("@Hobbies", sboj.Hobbies);
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
    }
}
