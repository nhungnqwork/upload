﻿using System;
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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }
        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 2;
            MyProgress.Value= startpoint;
            Percentage.Text = ""+startpoint;
            if (MyProgress.Value == 100)
            {
                timer1.Stop();
                Login log = new Login();
                log.Show();
                Hide();
            }
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Start(); 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
