using Policy_BAL;
using Policy_Exception;
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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        
        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                LoginBal pb = new LoginBal();
                bool isCustomer = pb.login(int.Parse(txt_loginId.Text), txt_pswd.Password.ToString());
                if (isCustomer)
                {
                    
                    HomePage obj = new HomePage();
                    obj.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Wrong Password and UserName!!");
                    txt_loginId.Text = string.Empty;
                    txt_pswd.Password = string.Empty;
                }
            }
            catch (PolicyException ex)
            {
                MessageBox.Show(ex.Message, "Policy Management System");
            }
            catch (Exception )
            {
                MessageBox.Show("Invalid LoginId or Password ", "Policy Management System");
            }
        }

        private void Btn_Reset_Click(object sender, RoutedEventArgs e)
        {
            txt_loginId.Clear();
            txt_pswd.Clear();

        }

        private void admin_btn(object sender, RoutedEventArgs e)
        {
           
            MainWindow mw = new MainWindow();
            Close();
            mw.Show();
        }
    }
}
