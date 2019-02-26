using Policy_BAL;
using Policy_Entities;
using Policy_Exception;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PolicyEndorsementManagement
{
    /// <summary>
    /// Interaction logic for ViewDocuments.xaml
    /// </summary>
    public partial class ViewDocuments : Window
    {
        DataSet ds;
        public ViewDocuments()
        {
            InitializeComponent();
        }

        private void Btnsearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                if (txtid.Text== string.Empty)
                {
                    sb.Append(Environment.NewLine + "Enter Customer Id!!");
                    throw new PolicyException(sb.ToString());
                }
                ViewDocument_BAL obj = new ViewDocument_BAL();

                ds = obj.ViewDocuments(int.Parse(txtid.Text));
                DataTable dt = ds.Tables[0];

                cbImages.Items.Clear();

                foreach (DataRow dr in dt.Rows)
                    cbImages.Items.Add(dr["id"].ToString());

                cbImages.SelectedIndex = 0;

                if (ds != null)
                {
                    lbl_id.Visibility = Visibility.Hidden;
                    txtid.Visibility = Visibility.Hidden;
                    btnsearch.Visibility = Visibility.Hidden;
                    btnshow.Visibility = Visibility.Visible;
                    cbImages.Visibility = Visibility.Visible;

                }
                
                else
                {
                    StringBuilder sb1 = new StringBuilder();
                    sb1.Append(Environment.NewLine + "No Documents Uploaded!!");
                    throw new PolicyException(sb1.ToString());
                }

            }
            catch (PolicyException ex)
            {
                MessageBox.Show(ex.Message, "Policy Endorsement System");
            }
            catch (Exception)
            {

            }
        }

        private void Btnshow_Click(object sender, RoutedEventArgs e)
        {

            DataTable dataTable = ds.Tables[0];
            int endId = 0;
            txtEndid.Visibility = Visibility.Visible;
            lbl_endid.Visibility = Visibility.Visible;
            txtid1.Visibility = Visibility.Visible;
            lbl_id1.Visibility = Visibility.Visible;
            foreach (DataRow row in dataTable.Rows)
            {

                //Store binary data read from the database in a byte array
                endId = (int)(row[0]);
                byte[] blob = (byte[])row[3];
                MemoryStream stream = new MemoryStream();
                stream.Write(blob, 0, blob.Length);
                stream.Position = 0;

                System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();

                MemoryStream ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                ms.Seek(0, SeekOrigin.Begin);
                bi.StreamSource = ms;
                bi.EndInit();
                image2.Source = bi;

            }
            txtEndid.Text = endId.ToString();
            txtid1.Text = txtid.Text;
            btn_Status.Visibility = Visibility.Visible;
        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                if (txt_Status.Text == string.Empty)
                {
                    sb.Append(Environment.NewLine + "Endorsement Status Required!!");
                    throw new PolicyException(sb.ToString());
                }

                EndorsementDetails p = new EndorsementDetails
                {
                    CustomerId = int.Parse(txtid.Text),
                    EndorsementId = int.Parse(txt_EnId.Text),
                    EndorsementStatus = txt_Status.Text
                };
                Endorsement_BAL pb = new Endorsement_BAL();
                bool added = pb.AddStatus(p);
                if (added)
                {

                    MessageBox.Show("policy updated Info Saved.", "policy endorsement System");
                }
                else
                {
                    MessageBox.Show("policy not updated ", "policy endorsement System");
                }
            }
            catch (PolicyException ex)
            {
                MessageBox.Show(ex.Message, "policy endorsement System");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "policy endorsement System");
            }
        }

        private void Update_Status_click(object sender, RoutedEventArgs e)
        {
            txt_Id.Text = txtid1.Text;
            txt_EnId.Text = txtEndid.Text;
            status.Visibility = Visibility.Visible;
            viewdoc.Visibility = Visibility.Hidden;

        }

        private void AdminLogout_btn(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
            Close();
        }
    }
}
