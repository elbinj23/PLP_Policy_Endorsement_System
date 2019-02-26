using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Policy_Entities;


namespace Policy_DAL
{
   public class Document_DAL
    {
        static string conStr = string.Empty;
        SqlConnection con = null;
        SqlCommand cmd = null;

        static Document_DAL()
        {
            conStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        }

        public Document_DAL()
        {
            con = new SqlConnection(conStr);
        }


        public bool InsertDocument(Documents d1)
        {
            bool inserted = false;
            try
            {
                if (d1.ImageName != "")
                {
                    //Initialize a file stream to read the image file
                    FileStream fs = new FileStream(d1.ImageName, FileMode.Open, FileAccess.Read);

                    //Initialize a byte array with size of stream
                    byte[] imgByteArr = new byte[fs.Length];

                    //Read data from the file stream and put into the byte array
                    fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));

                    //Close a file stream
                    fs.Close();

                    cmd = new SqlCommand();
                    cmd.CommandText = "Project_5.usp_UploadDocuments";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerId", d1.CustomerId);
                    cmd.Parameters.AddWithValue("@id", d1.Id);
                    //Pass byte array into database
                    cmd.Parameters.Add(new SqlParameter("@images", imgByteArr));
                    cmd.Connection = con;
                    con.Open();

                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        inserted = true;

                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return inserted;
        }
    }
}
