using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Policy_DAL;
using Policy_Entities;
using Policy_Exception;

namespace Policy_BAL
{
    public class Document_BAL
    {
        public bool InsertDocument(Documents d1)
        {
            bool inserted = false;
            try
            {

                Document_DAL din = new Document_DAL();
                inserted = din.InsertDocument(d1);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return inserted;

        }
    }
}
