using invoiceWPF2.BLL;
using invoiceWPF2.DAL;
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
using invoiceWPF2;
using System.Data.SqlClient;
using System.Configuration;

namespace invoiceWPF2.UI
{
    /// <summary>
    /// Interaction logic for invoice.xaml
    /// </summary>
public partial class invoice : Window
    {
        public invoice()
        {
           InitializeComponent();
        }

        productsBLL p = new productsBLL();
        productsDAL dal = new productsDAL();

        invoiceBLL b = new invoiceBLL();
        invoiceDAL dali = new invoiceDAL();

        DataGrid dg;
        DataRowView row_selected;

        int t = 0;
        int q = 0;

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Bill_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.SelectP();
            //dgvProducts.DataSource = dt;

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void Clear2(object sender, RoutedEventArgs e)
        {
            t = t - Convert.ToInt32(txtPrice2.Text);
            txtTotal.Text = Convert.ToString(t);
            txtItem2.Text = "";
            txtDesc2.Text = "";
            txtQuan2.Text = "";
            txtPrice2.Text = "";
        }

        private void Clear3(object sender, RoutedEventArgs e)
        {
            t = t - Convert.ToInt32(txtPrice3.Text);
            txtTotal.Text = Convert.ToString(t);
            txtItem3.Text = "";
            txtDesc3.Text = "";
            txtQuan3.Text = "";
            txtPrice3.Text = "";
        }

        private void Clear4(object sender, RoutedEventArgs e)
        {
            t = t - Convert.ToInt32(txtPrice4.Text);
            txtTotal.Text = Convert.ToString(t);
            txtItem4.Text = "";
            txtDesc4.Text = "";
            txtQuan4.Text = "";
            txtPrice4.Text = "";
        }

        private void Clear5(object sender, RoutedEventArgs e)
        {
            t = t - Convert.ToInt32(txtPrice5.Text);
            txtTotal.Text = Convert.ToString(t);
            txtItem5.Text = "";
            txtDesc5.Text = "";
            txtQuan5.Text = "";
            txtPrice5.Text = "";
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            t = t - Convert.ToInt32(txtPrice1.Text);
            txtTotal.Text = Convert.ToString(t);
            txtItem1.Text = "";
            txtDesc1.Text = "";
            txtQuan1.Text = "";
            txtPrice1.Text = "";            

        }

        private void clearAll()
        {
            txtItem1.Text = "";
            txtDesc1.Text = "";
            txtQuan1.Text = "";
            txtPrice1.Text = "";

            txtItem2.Text = "";
            txtDesc2.Text = "";
            txtQuan2.Text = "";
            txtPrice2.Text = "";

            txtItem3.Text = "";
            txtDesc3.Text = "";
            txtQuan3.Text = "";
            txtPrice3.Text = "";

            txtItem4.Text = "";
            txtDesc4.Text = "";
            txtQuan4.Text = "";
            txtPrice4.Text = "";

            txtItem5.Text = "";
            txtDesc5.Text = "";
            txtQuan5.Text = "";
            txtPrice5.Text = "";

            txtTotal.Text = "";

        }

        private void addInvoice(object sender, RoutedEventArgs e)
        {                        
            b.invoiceItems = txtItem1.Text;            
            b.price = Convert.ToInt32(txtPrice1.Text);
            b.total = Convert.ToInt32(txtTotal.Text);
            b.customerName = txtFname.Text;
            if(txtMobile.Text!="")
            b.customerMobile = Convert.ToInt32(txtMobile.Text);
            b.price = Convert.ToInt32(txtPrice1.Text);
            if (txtQuan1.Text != "") { b.quantity = Convert.ToInt32(txtQuan1.Text); }

            bool success = dali.InsertI(b);

            if (success == true)
            {
                MessageBox.Show("Invoice Successfully Added. ");
                dtLoad();
                clearAll();
            }
            else
            {
                MessageBox.Show("Faild to Add.");
            }
        }

        private void cancelCustomer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Edit_Load(object sender, RoutedEventArgs e)
        {            
                DataTable dt = dal.SelectP();
                dgvProducts.ItemsSource = dt.DefaultView;
            
        }
        private void dtLoad()
        {
            DataTable dt = dal.SelectP();
            dgvProducts.ItemsSource = dt.DefaultView;
        }

        private void txtCustomerID_TextChanged(object sender, TextChangedEventArgs e)
        {
            string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();


            String sql = "SELECT First_Name, Last_Name, Mobile FROM Customer_table WHERE id=@id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            conn.Open();
            if (txtCustomerID.Text != "")
            {                                
                cmd.Parameters.AddWithValue("@id", int.Parse(txtCustomerID.Text));                
                SqlDataReader da = cmd.ExecuteReader();                
                while (da.Read())
                {                    
                    txtFname.Text = da.GetValue(0).ToString() + " " + da.GetValue(1).ToString();
                    txtMobile.Text = da.GetValue(2).ToString();                    
                }
                conn.Close();
            }
        }

        private void txtTotal_TextChanged_1(object sender, TextChangedEventArgs e)
        {            
        }

        private void dgvProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             dg = (DataGrid)sender;
             row_selected = dg.SelectedItem as DataRowView;
                        
            if (row_selected != null)
            {
                if (txtItem1.Text == "" && txtItem5.Text != row_selected[0].ToString() && txtItem2.Text != row_selected[0].ToString() && txtItem3.Text != row_selected[0].ToString() && txtItem4.Text != row_selected[0].ToString())
                {
                    txtItem1.Text = row_selected[0].ToString();
                    txtDesc1.Text = row_selected[1].ToString();
                    txtPrice1.Text = row_selected[2].ToString();

                    if (txtQuan1.Text == "")
                    {
                        //t = t + (Convert.ToInt32(txtPrice1.Text) * Convert.ToInt32(txtQuan1.Text));
                        t = t + Convert.ToInt32(txtPrice1.Text);
                        txtTotal.Text = t.ToString();
                    }
                }

                //txtTotal.Text = (float.Parse(txtPrice1.Text).ToString() * float.Parse(txtQuan1.Text).ToString();

                else if (txtItem2.Text == "" && txtItem1.Text != row_selected[0].ToString() && txtItem5.Text != row_selected[0].ToString() && txtItem3.Text != row_selected[0].ToString() && txtItem4.Text != row_selected[0].ToString())
                {
                    
                        txtItem2.Text = row_selected[0].ToString();
                        txtDesc2.Text = row_selected[1].ToString();
                        txtPrice2.Text = row_selected[2].ToString();


                        if (txtQuan2.Text == "")
                        {
                            //t = t + (Convert.ToInt32(txtPrice1.Text) * Convert.ToInt32(txtQuan1.Text));
                            t = t + Convert.ToInt32(txtPrice2.Text);
                            txtTotal.Text = t.ToString();
                        }                    
                }

                else if (txtItem3.Text == "" && txtItem1.Text != row_selected[0].ToString() && txtItem2.Text != row_selected[0].ToString() && txtItem5.Text != row_selected[0].ToString() && txtItem4.Text != row_selected[0].ToString())
                {
                        txtItem3.Text = row_selected[0].ToString();
                        txtDesc3.Text = row_selected[1].ToString();
                        txtPrice3.Text = row_selected[2].ToString();

                    if (txtQuan3.Text == "")
                    {
                        //t = t + (Convert.ToInt32(txtPrice1.Text) * Convert.ToInt32(txtQuan1.Text));
                        t = t + Convert.ToInt32(txtPrice3.Text);
                        txtTotal.Text = t.ToString();
                    }
                }

                else if (txtItem4.Text == "" && txtItem1.Text != row_selected[0].ToString() && txtItem2.Text != row_selected[0].ToString() && txtItem3.Text != row_selected[0].ToString() && txtItem5.Text != row_selected[0].ToString())
                {
                        txtItem4.Text = row_selected[0].ToString();
                        txtDesc4.Text = row_selected[1].ToString();
                        txtPrice4.Text = row_selected[2].ToString();

                    if (txtQuan4.Text == "")
                    {
                        //t = t + (Convert.ToInt32(txtPrice1.Text) * Convert.ToInt32(txtQuan1.Text));
                        t = t + Convert.ToInt32(txtPrice4.Text);
                        txtTotal.Text = t.ToString();
                    }
                }

                else if (txtItem5.Text == "" && txtItem1.Text != row_selected[0].ToString() && txtItem2.Text != row_selected[0].ToString() && txtItem3.Text != row_selected[0].ToString() && txtItem4.Text != row_selected[0].ToString())
                {
                        txtItem5.Text = row_selected[0].ToString();
                        txtDesc5.Text = row_selected[1].ToString();
                        txtPrice5.Text = row_selected[2].ToString();

                    if (txtQuan5.Text == "")
                    {
                        //t = t + (Convert.ToInt32(txtPrice1.Text) * Convert.ToInt32(txtQuan1.Text));
                        t = t + Convert.ToInt32(txtPrice5.Text);
                        txtTotal.Text = t.ToString();
                    }
                }

            }
        }

        private void txtQuan1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtQuan1.Text != "")
            {
                if (Convert.ToInt32(txtQuan1.Text) > 1)
                {
                    q = (Convert.ToInt32(txtPrice1.Text) * Convert.ToInt32(txtQuan1.Text)-Convert.ToInt32(txtPrice1.Text));
                    t = t + q;
                    txtTotal.Text = Convert.ToString(t);
                }
            }
            else if (txtQuan1.Text == "" && txtQuan1.Text != "1")
            {                
                t = t - q;
                txtTotal.Text = Convert.ToString(t);
            }
        }

        private void txtQuan2_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txtQuan2.Text != "")
            {
                if (Convert.ToInt32(txtQuan2.Text) > 1)
                {
                    q = (Convert.ToInt32(txtPrice2.Text) * Convert.ToInt32(txtQuan2.Text) - Convert.ToInt32(txtPrice2.Text));
                    t = t + q;
                    txtTotal.Text = Convert.ToString(t);
                }
            }
            else if (txtQuan2.Text == "" && txtQuan2.Text != "1")
            {
                t = t - q;
                txtTotal.Text = Convert.ToString(t);
            }
        }

        private void txtQuan3_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txtQuan3.Text != "")
            {
                if (Convert.ToInt32(txtQuan3.Text) > 0)
                {
                    q = (Convert.ToInt32(txtPrice3.Text) * Convert.ToInt32(txtQuan3.Text) - Convert.ToInt32(txtPrice3.Text));
                    t = t + q;
                    txtTotal.Text = Convert.ToString(t);
                }
            }
            else if (txtQuan3.Text == "" && txtQuan3.Text != "1")
            {
                t = t - q;
                txtTotal.Text = Convert.ToString(t);
            }
        }

        private void txtQuan4_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txtQuan4.Text != "")
            {
                if (Convert.ToInt32(txtQuan4.Text) > 0)
                {
                    q = (Convert.ToInt32(txtPrice4.Text) * Convert.ToInt32(txtQuan4.Text) - Convert.ToInt32(txtPrice4.Text));
                    t = t + q;
                    txtTotal.Text = Convert.ToString(t);
                }
            }
            else if (txtQuan4.Text == "" && txtQuan4.Text != "1")
            {
                t = t - q;
                txtTotal.Text = Convert.ToString(t);
            }
        }

        private void txtQuan5_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txtQuan5.Text != "")
            {
                if (Convert.ToInt32(txtQuan5.Text) > 0)
                {
                    q = (Convert.ToInt32(txtPrice5.Text) * Convert.ToInt32(txtQuan5.Text) - Convert.ToInt32(txtPrice5.Text));
                    t = t + q;
                    txtTotal.Text = Convert.ToString(t);
                }
            }
            else if (txtQuan5.Text == "" && txtQuan5.Text != "1")
            {
                t = t - q;
                txtTotal.Text = Convert.ToString(t);
            }
        }



        /* private void txtQuan1_TextChanged(object sender, TextChangedEventArgs e)
         {
             if (txtQuan1.Text != "")
             {
                 int t = (Convert.ToInt32(txtPrice1.Text) * Convert.ToInt32(txtQuan1.Text));

                 txtTotal.Text = t.ToString();

             }
         }   */
    }
}
