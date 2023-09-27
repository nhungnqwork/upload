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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-77LQJ4S;Initial Catalog=CarDb;Integrated Security=True");
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void populate()
        {
            sqlConnection.Open();
            string query = "select * from UserTbl";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable data = new DataTable();
            sqlDataAdapter.Fill(data);
            UserDGV.DataSource = data;
            sqlConnection.Close();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            populate();
        }
        private void CAR_Click(object sender, EventArgs e)
        {
            if (UName.Text == "" || UPass.Text == "")
            {
                MessageBox.Show("Kiểm tra lại thông tin");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    string query = "insert into UserTbl values ('" + UName.Text + "','" + UPass.Text + "')";
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
            if (UId.Text == "")
            {
                MessageBox.Show("Kiểm tra lại thông tin");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    string query = "delete from UserTbl where Id='"+UId.Text+"'";
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

        private void UserDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UId.Text = UserDGV.SelectedRows[0].Cells[0].Value.ToString();
            UName.Text = UserDGV.SelectedRows[0].Cells[1].Value.ToString();
            UPass.Text = UserDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (UName.Text == "" || UPass.Text == "")
            {
                MessageBox.Show("Kiểm tra lại thông tin");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    string query = "update UserTbl set Uname='"+UName.Text+"', Upass='"+UPass.Text+"' where Id='"+UId.Text+"'";
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
