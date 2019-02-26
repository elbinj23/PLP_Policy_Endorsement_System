using System;
using System.Collections.Generic;
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
using Microsoft.Win32;
using Policy_BAL;
using Policy_Entities;
using Policy_Exception;


namespace PolicyEndorsementManagement
{
    /// <summary>
    /// Interaction logic for UploadDocuments.xaml
    /// </summary>
    public partial class UploadDocuments : Window
    {

        Documents d1 = new Documents();


        public UploadDocuments()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif;*.png;*.txt)|*.jpg;*.bmp;*.gif;*.png;*.txt";
                fldlg.ShowDialog();
                {
                    d1.Id = fldlg.SafeFileName;
                    d1.ImageName = fldlg.FileName;
                    ImageSourceConverter isc = new ImageSourceConverter();
                    image1.SetValue(Image.SourceProperty, isc.ConvertFromString(d1.ImageName));
                }
                fldlg = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            
            try
            {
                StringBuilder sb = new StringBuilder();

                if (txtId.Text == string.Empty)
                {
                    sb.Append(Environment.NewLine + "Enter Customer Id!");
                    throw new PolicyException(sb.ToString());
                }
                else
                {
                    d1.CustomerId = int.Parse(txtId.Text.ToString());
                    bool inserted = false;
                    Document_BAL bin = new Document_BAL();
                    inserted = bin.InsertDocument(d1);
                    if (inserted)
                    {
                        MessageBox.Show("Documents Added");
                    }
                }
               
            }
            catch(PolicyException ex)
            {
                MessageBox.Show(ex.Message, "Policy Endorsement System");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            HomePage h = new HomePage();
            h.Show();
            Close();
        }
    }
}
