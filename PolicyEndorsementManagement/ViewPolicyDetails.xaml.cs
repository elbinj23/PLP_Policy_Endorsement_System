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

namespace PolicyEndorsementManagement
{
    /// <summary>
    /// Interaction logic for ViewPolicyDetails.xaml
    /// </summary>
    public partial class ViewPolicyDetails : Window
    {
        public ViewPolicyDetails()
        {
            InitializeComponent();
        }

        private void View_customers_btn(object sender, RoutedEventArgs e)
        {
            AdminViewDetails ad = new AdminViewDetails();
            ad.Show();
            Close();
        }

        private void ViewDocuments_btn(object sender, RoutedEventArgs e)
        {
            ViewDocuments vd = new ViewDocuments();
            vd.Show();
            Close();
        }

        private void AdminLogout_btn(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
            Close();
        }
    }
}
