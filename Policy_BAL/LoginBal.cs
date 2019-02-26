using Policy_DAL;
using Policy_Exception;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Policy_Entities;

namespace Policy_BAL
{
    public class LoginBal
    {
        private static bool ValidateLogin(int id,string password)
        {
            StringBuilder sb = new StringBuilder();
            bool validLogin = true;
            if (id <= 0)
            {
                validLogin = false;
                sb.Append(Environment.NewLine + "enter correct login id");

            }
            if (password == string.Empty)
            {
                validLogin = false;
                sb.Append(Environment.NewLine + "password Required");

            }
            return validLogin;
        }
        public bool login(int loginid, string password)
        {

            try
            {
                LoginDal st = new LoginDal();
                bool isCustomer = false;
               
                isCustomer = st.login(loginid, password);
                return isCustomer;

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
        public bool LoginAdmin(string loginid, string password)
        {

            try
            {
                LoginDal st = new LoginDal();
                bool isCustomer = false;
                isCustomer = st.LoginAdmin(loginid, password);
                return isCustomer;

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
    }
}
