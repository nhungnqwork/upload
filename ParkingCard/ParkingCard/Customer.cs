using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingCard
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-77LQJ4S;Initial Catalog=CarDb;Integrated Security=True");

        private void populate()
        {
            sqlConnection.Open();
            string query = "select * from CustomerTbl";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable data = new DataTable();
            sqlDataAdapter.Fill(data);
            CustomerDGV.DataSource = data;
            sqlConnection.Close();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || AddressTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Kiểm tra lại thông tin");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    string query = "insert into CustomerTbl values ('" + NameTb.Text + "','" + AddressTb.Text + "', '" + PhoneTb.Text + "')";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công!");
                    sqlConnection.Close();
                    populate();
                }
                catch (Exception MyEx)
                {
                    MessageBox.Show($"{MyEx.Message}");
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || AddressTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Kiểm tra lại thông tin");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    string query = "delete from CustomerTbl where CustId='" + IdTb.Text + "'";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!");
                    sqlConnection.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show($"{Ex}");
                    throw;
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || AddressTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Kiểm tra lại thông tin");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    string query = "update CustomerTbl set CustName='" + NameTb.Text + "', CustAdd='" + AddressTb.Text + "', Phone='" + PhoneTb.Text + "' where CustId='" + IdTb.Text + "'";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Sửa thành công!");
                    sqlConnection.Close();
                    populate();
                }
                catch (Exception MyEx)
                {
                    MessageBox.Show($"{MyEx.Message}");
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            Hide();
        }

        private void CustomerDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTb.Text = CustomerDGV.SelectedRows[0].Cells[0].Value.ToString();
            NameTb.Text = CustomerDGV.SelectedRows[0].Cells[1].Value.ToString();
            AddressTb.Text = CustomerDGV.SelectedRows[0].Cells[2].Value.ToString();
            PhoneTb.Text = CustomerDGV.SelectedRows[0].Cells[3].Value.ToString();
        }
    }
}
