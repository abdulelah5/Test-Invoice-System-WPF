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
using invoiceWPF2.BLL;
using invoiceWPF2.DAL;
using invoiceWPF2;
using System.Data;

namespace invoiceWPF2.UI
{
    /// <summary>
    /// Interaction logic for products.xaml
    /// </summary>
    public partial class products : Window
    {
        public products()
        {
            InitializeComponent();
        }

        productsBLL b = new productsBLL();
        productsDAL dal = new productsDAL();
        DataGrid dg;
        DataRowView row_selected;

        private void clear()
        {
            txtPdescription.Text = "";
            txtAmount.Text = "";
            txtPrice.Text = "";
            txtPID.Text = "";

        }

        private void addProducts_Click(object sender, RoutedEventArgs e)
        {
            b.Description = txtPdescription.Text;
            b.Amount = Convert.ToInt32(txtAmount.Text);
            b.Price = Convert.ToInt32(txtPrice.Text);            

            bool success = dal.InsertP(b);

            if (success == true)
            {
                MessageBox.Show("Product Successfully Added. ");
                dtLoad();
                clear();
            }
            else
            {
                MessageBox.Show("Faild to Add.");
            }
            dtLoad();
        }

        private void updateProducts_Click(object sender, RoutedEventArgs e)
        {
            b.Items = Convert.ToInt32(txtPID.Text);
            b.Description = txtPdescription.Text;
            b.Amount = Convert.ToInt32(txtAmount.Text);
            b.Price = Convert.ToInt32(txtPrice.Text);

            bool success = dal.UpdateP(b);
            if (success == true)
            {
                MessageBox.Show("Product information Successfully updated.");
                dtLoad();
                clear();
            }
            else
            {
                MessageBox.Show("Error");
            }
            dtLoad();
        }

        private void deleteProducts_Click(object sender, RoutedEventArgs e)
        {
            b.Items = Convert.ToInt32(txtPID.Text);

            bool success = dal.DeleteP(b);
            if (success == true)
            {
                MessageBox.Show("Product Successfully Deleted.");
                dtLoad();
                clear();
            }
            else
            {
                MessageBox.Show("Faild to delete product");
            }
            dtLoad();
            // dgvCustomers.DataSource = dt;
        }

        private void cancelProducts_Click(object sender, RoutedEventArgs e)
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

        private void dgvProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dg = (DataGrid)sender;
            row_selected = dg.SelectedItem as DataRowView;

            if (row_selected != null)
            {
                txtPID.Text = row_selected[0].ToString();
                txtPdescription.Text = row_selected[1].ToString();
                txtAmount.Text = row_selected[2].ToString();
                txtPrice.Text = row_selected[3].ToString();                

            }
        }
    }
}
