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
using Policy_BAL;
using Policy_DAL;
using Policy_Entities;
using Policy_Exception;

namespace PolicyEndorsementManagement
{
    /// <summary>
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        public Update()
        {
            InitializeComponent();
        }
        int ProductId = 0;
        private void Btn_view_Click(object sender, RoutedEventArgs e)
        {
 
            try
            {
                StringBuilder sb = new StringBuilder();

                if (txt_CustomerId.Text == string.Empty)
                {
                    sb.Append(Environment.NewLine + "Please Enter Customer Id!!!");
                    throw new PolicyException(sb.ToString());
                }
                else
                {
                    btn_Update.Visibility = Visibility.Visible;
                    btn_view.Visibility = Visibility.Hidden;
                }
                ViewPolicyBal pb = new ViewPolicyBal();
                Customer p = pb.Search(int.Parse(txt_CustomerId.Text));
                if (p != null)
                {
                    ProductId = p.ProductId;
                    tb_PolicyNumber.Text = p.PolicyNumber.ToString();
                    tb_ProductLine.Text = p.ProductLine.ToString();
                    tb_ProductName.Text = p.ProductName.ToString();
                    txt_InsuredName.Text = p.CustomerName;
                    txt_InsuredAge.Text = p.Age.ToString();
                    dp_Dob.Text = p.DOB.ToString();
                    if (p.Gender == "M")
                    {
                        rbtn_Male.IsChecked = true;
                    }
                    else if (p.Gender == "F")
                    {
                        rbtn_Female.IsChecked = true;
                    }
                    if (p.Habits == "Smoking")
                    {
                        rbtn_Smoker.IsChecked = true;
                    }
                    else if (p.Habits == "NoSmoking")
                    {
                        rbtn_NonSmoker.IsChecked = true;
                    }
                    txt_Address.Text = p.CustomerAddress;
                    txt_InsuredAge.Text = p.CustomerAge.ToString();
                    txt_TelephoneNo.Text = p.CustomerPhoneNo.ToString();
                    if (p.PremiumPaymentFrequency == "Annual")
                    {
                        rbtn_Annualy.IsChecked = true;
                    }
                    else if (p.PremiumPaymentFrequency == "HalfYearly")
                    {
                        rbtn_Annualy.IsChecked = true;
                    }
                    else if (p.PremiumPaymentFrequency == "Quarterly")
                    {
                        rbtn_Annualy.IsChecked = true;
                    }
                    else if (p.PremiumPaymentFrequency == "Monthly")
                    {
                        rbtn_Annualy.IsChecked = true;
                    }
                    txt_Nominee.Text = p.NomineeName;
                    txt_Relation.Text = p.Relation;
                    gb1.Visibility = Visibility.Visible;
                }
                else
                {
                    gb1.Visibility = Visibility.Hidden;
                    MessageBox.Show
                        (string.Format("customer with id {0} does not exist.", txt_CustomerId.Text),
                        "policy endorsement System");
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

        private void Btn_Update_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string gender = string.Empty;
                if (rbtn_Male.IsChecked == true)
                {
                    gender = "M";
                }
                else if (rbtn_Female.IsChecked == true)
                {
                    gender = "F";
                }
                string habits = string.Empty;
                if (rbtn_Smoker.IsChecked == true)
                {
                    habits = "Smoking";
                }
                else if (rbtn_NonSmoker.IsChecked == true)
                {
                    habits = "NoSmoking";
                }
                string premiumfreq = string.Empty;
                if (rbtn_Annualy.IsChecked == true)
                {
                    premiumfreq = "Yearly";
                }
                else if (rbtn_Halfyearly.IsChecked == true)
                {
                    premiumfreq = "Halfyearly";
                }
                else if (rbtn_Quarterly.IsChecked == true)
                {
                    premiumfreq = "Quarterly";
                }
                else if (rbtn_Monthly.IsChecked == true)
                {
                    premiumfreq = "monthly";
                }
                Customer p = new Customer
                {
                    CustomerID = int.Parse(txt_CustomerId.Text),
                    CustomerName = txt_InsuredName.Text,
                    CustomerAge = int.Parse(txt_InsuredAge.Text),
                    DOB = DateTime.Parse(dp_Dob.Text),
                    Gender = gender,
                    NomineeName = txt_Nominee.Text,
                    Relation = txt_Relation.Text,
                    Habits = habits,
                    CustomerAddress = txt_Address.Text,
                    CustomerPhoneNo = Int64.Parse(txt_TelephoneNo.Text),
                    PremiumPaymentFrequency = premiumfreq
                };
                ViewPolicyBal pb = new ViewPolicyBal();
                bool updated = pb.UpdatePolicy(p, ProductId);
                if (updated)
                {
                    gb1.Visibility = Visibility.Hidden;
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


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btn_Update.Visibility = Visibility.Hidden;
        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            HomePage h = new HomePage();
            h.Show();
            Close();
        }
    }
}
