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
using Policy_Exception;

namespace PolicyEndorsementManagement
{
    /// <summary>
    /// Interaction logic for AdminViewDetails.xaml
    /// </summary>
    public partial class AdminViewDetails : Window
    {
        public AdminViewDetails()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                AdminViewPageBAL sb = new AdminViewPageBAL();
                DataTable dt = sb.ViewAdminDetails_Bal();
                dg_ViewAdmin.ItemsSource = dt.DefaultView;

            }
            catch (PolicyException ex)
            {
                MessageBox.Show(ex.Message, "Policy Management System");
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message, "Policy Management System");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewPolicyDetails vd = new ViewPolicyDetails();
            vd.Show();
            Close();
        }
    }
}
