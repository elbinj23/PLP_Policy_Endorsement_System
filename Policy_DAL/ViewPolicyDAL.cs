using Policy_Entities;
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
     public class ViewPolicyDAL
    {
        static string conStr = string.Empty;
        SqlConnection con = null;
        SqlCommand cmd = null;

        static ViewPolicyDAL()
        {
            conStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        }

        public ViewPolicyDAL()
        {
            con = new SqlConnection(conStr);
        }

        public Customer search(int customerid)
        {
            Customer p = null;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "Project_5.usp_ViewPolicy";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", customerid);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    p = new Customer
                    {
                         
                        CustomerID = int.Parse(dr["CustomerId"].ToString()),
                        CustomerName = dr["CustomerName"].ToString(),
                        CustomerAddress= dr["CustomerAddress"].ToString(),
                        CustomerAge = int.Parse(dr["Age"].ToString()),
                        CustomerPhoneNo = Int64.Parse(dr["CustomerPhoneNo"].ToString()),
                        Gender = dr["Gender"].ToString(),
                        Habits = dr["Habits"].ToString(),
                        DOB = DateTime.Parse(dr["Dob"].ToString()),
                        NomineeName = dr["NomineeName"].ToString(),
                        Relation = dr["Relation"].ToString(),
                        ProductName = dr["ProductName"].ToString(),
                        PremiumPaymentFrequency = dr["PremiumPaymentFrequency"].ToString(),
                        PolicyNumber = int.Parse(dr["PolicyNumber"].ToString()),
                        ProductLine = dr["ProductLine"].ToString(),
                        ProductId =int.Parse(dr["ProductId"].ToString())
                 
                    };
                    dr.Close();
                }
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
            return p;
        }

        public bool UpdateDetails(Customer sboj,int ProductId)
        {
            bool result = false;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "Project_5.usp_UpdatePolicy";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductId", ProductId);
                cmd.Parameters.AddWithValue("@CustomerId", sboj.CustomerID);
                cmd.Parameters.AddWithValue("@CustomerName", sboj.CustomerName);
                cmd.Parameters.AddWithValue("@Age", sboj.CustomerAge);
                cmd.Parameters.AddWithValue("@DOB", sboj.DOB);
                cmd.Parameters.AddWithValue("@Gender", sboj.Gender);
                cmd.Parameters.AddWithValue("@NomineeName", sboj.NomineeName);
                cmd.Parameters.AddWithValue("@Relation", sboj.Relation);
                cmd.Parameters.AddWithValue("@Habits", sboj.Habits);
                cmd.Parameters.AddWithValue("@CustomerAddress", sboj.CustomerAddress);
                cmd.Parameters.AddWithValue("@CustomerPhoneNo", sboj.CustomerPhoneNo);
                cmd.Parameters.AddWithValue("@PremiumPaymentFrequency", sboj.PremiumPaymentFrequency);

                con.Open();
                int noOfRowsAffected = cmd.ExecuteNonQuery();
                if (noOfRowsAffected >1)
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
