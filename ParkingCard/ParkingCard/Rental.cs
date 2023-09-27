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
    public partial class Rental : Form
    {
        public Rental()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-77LQJ4S;Initial Catalog=CarDb;Integrated Security=True");
        private void fillcombo()
        {
            sqlConnection.Open();
            string query = "select RegNum from CarTbl";
            SqlCommand sqlCommand= new SqlCommand(query,sqlConnection);
            SqlDataReader rdr;
            rdr = sqlCommand.ExecuteReader();
            DataTable data = new DataTable();
            data.Columns.Add("RegNum", typeof(string));
            data.Load(rdr);
            CarRegCb.ValueMember = "RegNum";
            CarRegCb.DataSource = data;
            sqlConnection.Close();
        }


        private void fillCustName()
        {
            sqlConnection.Open();
            string query = "select CustId from CustomerTbl";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader rdr;
            rdr = sqlCommand.ExecuteReader();
            DataTable data = new DataTable();
            data.Columns.Add("CustId", typeof(string));
            data.Load(rdr);
            CustIdCb.ValueMember = "CustId";
            CustIdCb.DataSource = data;
            sqlConnection.Close();
        }
        private void fetchCustomer()
        {
            sqlConnection.Open();
            string query = "select * from CustomerTbl where CustId='"+CustIdCb.SelectedValue.ToString()+"'";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            DataTable data = new DataTable();
            SqlDataAdapter rdr = new SqlDataAdapter(sqlCommand);
            rdr.Fill(data);
            foreach (DataRow dr in data.Rows)
            {
                CustNameTb.Text = dr["CustName"].ToString();
            }
            sqlConnection.Close();
        }
        private void Rental_Load(object sender, EventArgs e)
        {
            fillcombo();
            fillCustName();
            populate();
        }

        private void CarRegCb_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void CustIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchCustomer();
        }
        private void populate()
        {
            sqlConnection.Open();
            string query = "select * from RentalTbl";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable data = new DataTable();
            sqlDataAdapter.Fill(data);
            CarDGV.DataSource = data;
            sqlConnection.Close();
        }
        private void UpdateonRent()
        {
            sqlConnection.Open();
            string query = "update CarTbl set Available='"+"NO"+"' where RegNum= '"+CarRegCb.SelectedValue.ToString()+"'";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            //MessageBox.Show("Sửa thành công!");
            sqlConnection.Close();
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || CarRegCb.SelectedIndex == -1 || CustIdCb.SelectedIndex == -1 || CustNameTb.Text == "" || FeeTb.Text == "")
            {
                MessageBox.Show("Kiểm tra lại thông tin");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    string query = "insert into RentalTbl values ('" + IdTb.Text + "','" + CarRegCb.SelectedValue.ToString() + "', '" + CustIdCb.SelectedValue.ToString() + "', '"+CustNameTb.Text+ "', '"+RentalDate.Value.ToString()+ "', '"+ReturnDate.Value.ToString()+"', '"+FeeTb.Text+"')";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công!");
                    sqlConnection.Close();
                    UpdateonRent();
                    populate();
                }
                catch (Exception MyEx)
                {
                    MessageBox.Show($"{MyEx.Message}");
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            Hide();
        }
    }
}
