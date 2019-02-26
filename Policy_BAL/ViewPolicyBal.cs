using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Policy_DAL;
using Policy_Entities;
using Policy_Exception;

namespace Policy_BAL
{
    public class ViewPolicyBal
    {
        private bool ValidateCustomer(Customer cust)
        {
            bool isValidCustomer = true;
            StringBuilder sbEMSError = new StringBuilder();

            if (cust.CustomerID.ToString() == string.Empty)
            {
                isValidCustomer = false;
                sbEMSError.Append("please enter Customer Id " + Environment.NewLine);
            }

            if (!(Regex.IsMatch(cust.CustomerName, "[A-Za-z]{3,}")))
            {
                isValidCustomer = false;
                sbEMSError.Append("Name should not be null and should have atleast 4 characters " + Environment.NewLine);
            }

            //if (cust.CustomerAge < 18)
            //{
            //    isValidCustomer = false;
            //    sbEMSError.Append("Age should be greater than 18 " + Environment.NewLine);
            //}

            if (!(Regex.IsMatch(cust.CustomerPhoneNo.ToString(), "[7-9][0-9]{9}")))
            {
                isValidCustomer = false;
                sbEMSError.Append("Phone number length should be 10 begining with 7 to 9 " + Environment.NewLine);
            }

            if (!(Regex.IsMatch(cust.NomineeName, "[A-Za-z]{3,}")))
            {
                isValidCustomer = false;
                sbEMSError.Append("Nominee name  should not be null and should have atleast 4 characters " + Environment.NewLine);
            }

            if (!(Regex.IsMatch(cust.Relation, "[A-Za-z]{3,}")))
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


        public Customer Search(int customerid)
        {
            try
            {
                ViewPolicyDAL pd = new ViewPolicyDAL();
                return pd.search(customerid);
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
        public bool UpdatePolicy(Customer sboj,int productId)
        {
            bool updated = false;
            try
            {
                if(ValidateCustomer(sboj))
                {
                    ViewPolicyDAL pd = new ViewPolicyDAL();
                    updated = pd.UpdateDetails(sboj, productId);
                }
               
                
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
