using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingCard
{
    public partial class Car : Form
    {
        public Car()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-77LQJ4S;Initial Catalog=CarDb;Integrated Security=True");
        private void populate()
        {
            sqlConnection.Open();
            string query = "select * from CarTbl";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable data = new DataTable();
            sqlDataAdapter.Fill(data);
            CarDGV.DataSource = data;
            sqlConnection.Close();
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (RegTb.Text == "" || BrandTb.Text == "" || ModelTb.Text == "" || PriceTb.Text == "" || availableCb.SelectedIndex == -1)
            {
                MessageBox.Show("Kiểm tra lại thông tin");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    string query = "insert into CarTbl values ('" + RegTb.Text + "', '" + BrandTb.Text + "','" + ModelTb.Text + "', '" + availableCb.SelectedItem.ToString() + "', '" + PriceTb.Text + "')";
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

        private void Car_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (RegTb.Text == "")
            {
                MessageBox.Show("Kiểm tra lại thông tin");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    string query = "delete from CarTbl where RegNum='" + RegTb.Text + "'";
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

        private void CarDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RegTb.Text = CarDGV.SelectedRows[0].Cells[0].Value.ToString();
            BrandTb.Text = CarDGV.SelectedRows[0].Cells[1].Value.ToString();
            ModelTb.Text = CarDGV.SelectedRows[0].Cells[2].Value.ToString();
            availableCb.Text = CarDGV.SelectedRows[0].Cells[3].Value.ToString();
            PriceTb.Text = CarDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (RegTb.Text == "" || BrandTb.Text == "" || ModelTb.Text == "" || PriceTb.Text == "" || availableCb.SelectedIndex == -1)
            {
                MessageBox.Show("Kiểm tra lại thông tin");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    string query = "update CarTbl set Brand='" + BrandTb.Text + "', Model='" + ModelTb.Text + "', Available='" + availableCb.Text + "', Price='" + PriceTb.Text + "' where RegNum='" + RegTb.Text + "'";
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
    }
}
