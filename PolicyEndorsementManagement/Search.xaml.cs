using Policy_BAL;
using Policy_Entities;
using Policy_Exception;
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

namespace PolicyEndorsementManagement
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        public Search()
        {
            InitializeComponent();
        }
        int ProductId = 0;
        private void Btn_DOB_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb1 = new StringBuilder();
            try
            {
                PES_BAL pb = new PES_BAL();
                DataTable dt = pb.Search(int.Parse(txt_CustId.Text), DateTime.Parse(txt_DOB.Text), int.Parse(txt_PolicyNo.Text));
                if(dt == null)
                {
                    sb1.Append(Environment.NewLine + "Customer not Found!!");
                    throw new PolicyException(sb1.ToString());
                }
                else
                {
                    dg_Display.ItemsSource = dt.DefaultView;
                }
                
            }
            catch (PolicyException ex)
            {
                MessageBox.Show(ex.Message, "Student Management System");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong Credentials", "Student Management System");
            }
        }

        private void Btn_retunSearch_Click(object sender, RoutedEventArgs e)
        {
            HomePage hp = new HomePage();
            hp.Show();
            Close();
        }


        private void Dg_Display_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int custId = 0;
            custId = int.Parse(txt_CustId.Text);
            gd_edit.Visibility = Visibility.Visible;
            gd_search.Visibility = Visibility.Hidden;
            try
            {
                PES_BAL sb = new PES_BAL();
                Customer c = sb.DisplayCustomer_Bal(custId);
                //dg_Student.ItemsSource = dt.DefaultView;

                txt_customerId.Text = c.CustomerID.ToString();
                txt_CName.Text = c.CustomerName.ToString();
                txt_Address.Text = c.CustomerAddress.ToString();
                txt_no.Text = c.CustomerPhoneNo.ToString();
                txt_Gender.Text = c.Gender.ToString();
                txt_Dob.Text = c.DOB.ToString();
                txt_Habits.Text = c.Habits.ToString();
                txt_Hobbies.Text = c.Hobbies.ToString();
                txt_PolicyNumber.Text = c.PolicyNumber.ToString();
                txt_ProductId.Text = c.ProductId.ToString();

            }
            catch (PolicyException ex)
            {
                MessageBox.Show(ex.Message, "Policy Endorsement System");
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message, "Policy Endorsement System");
            }
        }

        private void update_btn(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer p = new Customer
                {

                    CustomerID = int.Parse(txt_customerId.Text),
                    CustomerName = txt_CName.Text,
                    CustomerAddress = txt_Address.Text,
                    CustomerPhoneNo = Int64.Parse(txt_no.Text),
                    Gender = txt_Gender.Text,
                    DOB = DateTime.Parse(txt_Dob.Text),
                    Habits = txt_Habits.Text,
                    Hobbies = txt_Hobbies.Text,

                };
                ProductId = int.Parse(txt_ProductId.Text);

                PES_BAL pb = new PES_BAL();
                bool updated = pb.UpdatePolicy(p, ProductId);
                HomePage h = new HomePage();
                if (updated)
                {
                    
                    MessageBox.Show("policy updated Info Saved.", "policy endorsement System");
                    h.Show();
                    Close();

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

        private void cancel_btn(object sender, RoutedEventArgs e)
        {
            gd_edit.Visibility = Visibility.Hidden;
            gd_search.Visibility = Visibility.Visible;
        }
    }
}
