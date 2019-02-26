using Policy_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policy_BAL
{
    public class ViewDocument_BAL
    {
        public DataSet ViewDocuments(int customerId)
        {
            DataSet ds;
            try
            {
                ViewDocument_DAL obj1 = new ViewDocument_DAL();
                ds = obj1.ViewDocuments(customerId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ds;

        }

    }
}
