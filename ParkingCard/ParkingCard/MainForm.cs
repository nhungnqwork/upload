using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingCard
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CAR_Click(object sender, EventArgs e)
        {
            Hide();
            Car c = new Car();
            c.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Hide();
            Users c = new Users();
            c.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Hide();
            Customer c = new Customer();
            c.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Hide();
            Rental c = new Rental();
            c.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
