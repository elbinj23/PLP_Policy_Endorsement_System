using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Policy_DAL;
using Policy_Exception;

namespace Policy_BAL
{
    public class AdminViewPageBAL
    {
        public DataTable ViewAdminDetails_Bal()
        {
            try
            {
                AdminPageViewDAL st = new AdminPageViewDAL();
                DataTable dtView = st.ViewAdminDetails_DAL();
                if (dtView.Rows.Count <= 0)
                {
                    throw new PolicyException("no customers available");
                }
                return dtView;
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

    }
}
