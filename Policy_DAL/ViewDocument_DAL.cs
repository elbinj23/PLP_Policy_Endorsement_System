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
    public class ViewDocument_DAL
    {
        static string conStr = string.Empty;
        SqlConnection con = null;
        SqlCommand cmd = null;

        static ViewDocument_DAL()
        {
            conStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        }

        public ViewDocument_DAL()
        {
            con = new SqlConnection(conStr);
        }

        DataSet ds;
        public DataSet ViewDocuments(int customerId)
        {
            try
            {
                con.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Project_5.Documents where customerid=customerId", con))
                {
                    ds = new DataSet("myDataSet");
                    adapter.Fill(ds);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
    }
}
