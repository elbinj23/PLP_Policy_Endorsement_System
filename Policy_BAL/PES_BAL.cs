using Policy_DAL;
using Policy_Exception;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Policy_Entities;
using System.Text.RegularExpressions;

namespace Policy_BAL
{
    public class PES_BAL
    {
        private bool ValidateCustomer(Customer cust)
        {
            bool isValidCustomer = true;
            StringBuilder sbEMSError = new StringBuilder();

            if(cust.CustomerID .ToString()== string.Empty)
            {
                isValidCustomer = false;
                sbEMSError.Append("please enter Customer Id " + Environment.NewLine);
            }
            if (!(Regex.IsMatch(cust.CustomerName, "[A-Za-z]{3,}")))
            {
                isValidCustomer = false;
                sbEMSError.Append("Name should not be null and should have atleast 4 characters " + Environment.NewLine);
            }

            //if(cust.CustomerAge < 18)
            //{
            //    isValidCustomer = false;
            //    sbEMSError.Append("Age should be greater than 18 " + Environment.NewLine);
            //}

            if (!(Regex.IsMatch(cust.CustomerPhoneNo.ToString(), "[7-9][0-9]{9}")))
            {
                isValidCustomer = false;
                sbEMSError.Append("Phone number length should be 10 begining with 7 to 9 " + Environment.NewLine);
            }

            if(!(Regex.IsMatch(cust.NomineeName, "[A-Za-z]{3,}")))
            {
                isValidCustomer = false;
                sbEMSError.Append("Nominee name  should not be null and should have atleast 4 characters " + Environment.NewLine);
            }

            if(!(Regex.IsMatch(cust.Relation, "[A-Za-z]{3,}")))
            {
                isValidCustomer = false;
                sbEMSError.Append("Relation should not be null and should have atleast 4 characters " + Environment.NewLine);
            }

            if (cust.CustomerAddress == string.Empty)
            {
                isValidCustomer = false;
                sbEMSError.Append("Address should not be null" + Environment.NewLine);
            }

            

            if (!isValidCustomer)

            { throw new PolicyException(sbEMSError.ToString()); }

            return isValidCustomer;
        }

        public DataTable Search(int customerid, DateTime DOB, int PolicyNumber)
        {

            try
            {
                PES_DAL st = new PES_DAL();
                DataTable dtStudent = st.search(customerid, DOB, PolicyNumber);
                if (dtStudent.Rows.Count <= 0)
                {
                    throw new PolicyException("no Customer available");
                }
                return dtStudent;
            }
            catch (PolicyException)
            {
                throw;
            }
            catch (SqlException se)
            {
                throw se;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Customer DisplayCustomer_Bal(int customerId)
        {
            try
            {
                PES_DAL st = new PES_DAL();
                Customer p = st.DisplayCustomer_Dal(customerId);
                if (p == null)
                {
                    throw new PolicyException("no customers available");
                }
                return p;
            }
            catch (PolicyException se)
            {
                throw se;
            }
            catch (SqlException se)
            {
                throw se;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool UpdatePolicy(Customer sboj, int productId)
        {
            bool updated = false;
            try
            {
             
                 PES_DAL pd = new PES_DAL();
                 updated = pd.UpdateDetails(sboj, productId);
              
            }
            catch (PolicyException se)
            {
                throw se;
            }
            catch (SqlException se)
            {
                throw se;
            }
            catch (Exception e)
            {
                throw e;
            }
            return updated;
        }
    }
}
