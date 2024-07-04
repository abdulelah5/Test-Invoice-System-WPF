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
using invoiceWPF2.BLL;
using invoiceWPF2.DAL;
using invoiceWPF2;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;

namespace invoiceWPF2.UI
{
    /// <summary>
    /// Interaction logic for customers.xaml
    /// </summary>
    public partial class customers : Window
    {
        public customers()
        {
            InitializeComponent();
            
        }

        customersBLL b = new customersBLL();
        customersDAL dal = new customersDAL();
        DataGrid dg;
        DataRowView row_selected;




        private void clear()
        {
            txtID.Text = "";
            txtFname.Text = "";
            txtLname.Text = "";
            txtMobile.Text = "";
            txtAddress.Text = "";
        }
        /*private void dgvUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtID.Text = dgvCustomers.Rows[rowIndex].Cells[0].Value.ToString();
            txtFname.Text = dgvCustomers.Rows[rowIndex].Cells[1].Value.ToString();
            txtLname.Text = dgvCustomers.Rows[rowIndex].Cells[2].Value.ToString();
            txtAddress.Text = dgvCustomers.Rows[rowIndex].Cells[3].Value.ToString();
            txtMobile.Text = dgvCustomers.Rows[rowIndex].Cells[4].Value.ToString();
        }*/
        private void dtLoad()
        {
            DataTable dt = dal.Select();
            dgvCustomers.ItemsSource = dt.DefaultView;
        }

        private void Edit_Load(object sender, RoutedEventArgs e)
        {            
            DataTable dt = dal.Select();
            dgvCustomers.ItemsSource = dt.DefaultView;
            /*
            SqlConnection conn = new SqlConnection(myconnstrng);
            conn.Open();

            String sql = "SELECT First_Name FROM Customer_table WHERE id=@id";
            SqlCommand cmd = new SqlCommand("SELECT First_Name, Last_Name FROM Customer_table WHERE id =@id", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@id", 12);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                dgvCustomers.SelectedItem= da;
                //txtLname.Text = da.GetValue(1).ToString();
            }


            conn.Close();*/

        }

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        private void addCustomer_Click_1(object sender, RoutedEventArgs e)
        {
            b.First_Name = txtFname.Text;
            b.Last_Name = txtLname.Text;
            b.Address = txtAddress.Text;
            b.Mobile = Convert.ToInt32(txtMobile.Text);

            bool success = dal.Insert(b);

            if (success == true)
            {                
                MessageBox.Show("Customer Successfully Added. ");
                dtLoad();
                clear();
            }
            else
            {
                MessageBox.Show("Faild to Add.");
            }
            dtLoad();
           // DataTable dt = dal.Select();
            //dgvUsers.DataSource = dt;
        }

        private void updateCustomer_Click(object sender, RoutedEventArgs e)
        {
            b.id = Convert.ToInt32(txtID.Text);
            b.First_Name = txtFname.Text;
            b.Last_Name = txtLname.Text;
            b.Address = txtAddress.Text;
            b.Mobile = Convert.ToInt32(txtMobile.Text);

            bool success = dal.Update(b);
            if (success == true)
            {
                MessageBox.Show("Customer information Successfully updated.");
                clear();
            }
            else
            {
                MessageBox.Show("Error");
            }
            dtLoad();

        }

        private void delete(object sender, RoutedEventArgs e)
        {
            b.id = Convert.ToInt32(txtID.Text);

            bool success = dal.Delete(b);
            if (success == true)
            {
                MessageBox.Show("Customer Successfully Deleted.");
                clear();
            }
            else
            {
                MessageBox.Show("Faild to delete customer");
            }
            dtLoad();
        }

        private void cancelCustomer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgvCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dg = (DataGrid)sender;
            row_selected = dg.SelectedItem as DataRowView;

            if (row_selected != null)
            {
                txtID.Text = row_selected[0].ToString();
                txtFname.Text = row_selected[1].ToString();
                txtLname.Text = row_selected[2].ToString();
                txtAddress.Text = row_selected[3].ToString();
                txtMobile.Text = row_selected[4].ToString();

            }
        }

        /*private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtSearch.Text;

            if (keywords != null)
            {
                DataTable dt = dal.Search(keywords);
                dgvCustomers.DataSource = dt;
            }
            else
            {
                DataTable dt = dal.Select();
                dgvCustomers.DataSource = dt;
            }
        }*/

    }
}
