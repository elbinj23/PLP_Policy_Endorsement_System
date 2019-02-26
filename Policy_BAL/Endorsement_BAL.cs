using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Policy_Entities;
using Policy_DAL;
using Policy_Exception;
using System.Data.SqlClient;
using System.Data;

namespace Policy_BAL
{
    public class Endorsement_BAL
    {
        public DataTable ViewStatus(int customerId)
        {
            try
            {
                Endorsement_DAL st = new Endorsement_DAL();
                DataTable dtView = st.ViewStatus(customerId);
                if (dtView.Rows.Count <= 0)
                {
                    throw new PolicyException("No customers available");
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

        public bool AddStatus(EndorsementDetails sboj)
        {
            bool added = false;
            try
            {
                Endorsement_DAL pd = new Endorsement_DAL();
                added = pd.AddStatus(sboj);
                return added;
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
