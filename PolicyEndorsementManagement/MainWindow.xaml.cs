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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Policy_BAL;
using Policy_Entities;
using Policy_Exception;

namespace PolicyEndorsementManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoginBal pb = new LoginBal();
                bool isCustomer = false;
                isCustomer = pb.LoginAdmin(txt_loginId.Text, txt_pswd.Password.ToString());
                if (isCustomer)
                {
                    ViewPolicyDetails obj = new ViewPolicyDetails();
                    Close();
                    obj.Show();
                }
                else
                {
                    MessageBox.Show("Wrong Password or Username");
                    txt_loginId.Text = string.Empty;
                    txt_pswd.Password = string.Empty;
                }
            }
            catch (PolicyException ex)
            {
                MessageBox.Show(ex.Message, "Policy Management System");
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid LoginId or Password", "Policy Management System");
            }
        }

        private void Btn_Reset_Click(object sender, RoutedEventArgs e)
        {
            txt_loginId.Clear();
            txt_pswd.Clear();

        }

        private void Btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            LoginPage l = new LoginPage();
            l.Show();
            Close();
        }
    }
}
