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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Btn_update_Click(object sender, RoutedEventArgs e)
        {
            Update u = new Update();
            u.Show();
            Close();
        }

        private void Btn_upload_Click(object sender, RoutedEventArgs e)
        {
            UploadDocuments ud = new UploadDocuments();
            ud.Show();
            Close();
        }

        private void Btn_view_Click(object sender, RoutedEventArgs e)
        {
            EndorsementStatus vp = new EndorsementStatus();
            vp.Show();
            Close();
        }

        private void Btn_LogOut_Click(object sender, RoutedEventArgs e)
        {
            LoginPage lp = new LoginPage();
            lp.Show();
            Close();
            
        }

        private void Btn_edit_Click(object sender, RoutedEventArgs e)
        {
            Search s = new Search();
            s.Show();
            Close();
        }
    }
}
