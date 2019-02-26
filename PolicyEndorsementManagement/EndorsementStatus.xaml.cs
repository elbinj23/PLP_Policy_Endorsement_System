using System;
using System.Collections.Generic;
using System.Data;
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
using Policy_BAL;
using Policy_Entities;
using Policy_Exception;

namespace PolicyEndorsementManagement
{
    /// <summary>
    /// Interaction logic for EndorsementStatus.xaml
    /// </summary>
    public partial class EndorsementStatus : Window
    {
        public EndorsementStatus()
        {
            InitializeComponent();
        }

        private void btn_status(object sender, RoutedEventArgs e)
        {
            StringBuilder sbdt = new StringBuilder();
            try
            {
                StringBuilder sb1 = new StringBuilder();

                if (txt_custId.Text == string.Empty)
                {
                    sb1.Append(Environment.NewLine + "Customer Id Required!!");
                    throw new PolicyException(sb1.ToString());
                }
                else
                {
                    int customerId = int.Parse(txt_custId.Text);
                    Endorsement_BAL sb = new Endorsement_BAL();
                    DataTable dt = sb.ViewStatus(customerId);
                    if(dt == null)
                    {
                        MessageBox.Show("Status Pending or Not Updated!!");
                        
                    }
                    else
                    dg_status.ItemsSource = dt.DefaultView;
                }
             
            }
            catch (PolicyException ex)
            {
                MessageBox.Show(ex.Message, "Policy Management System");
            }
            catch (SystemException ex)
            {
                MessageBox.Show("Status Pending or Not Updated!!", "Policy Management System");
            }
        }

        private void btn_back(object sender, RoutedEventArgs e)
        {
            HomePage h = new HomePage();
            h.Show();
            Close();
        }
    }
}
