using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_CIH_CAHUL_BAC
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {


            this.Hide(); 

            Form1 form1 = new Form1(); 
            form1.Opacity = 1; 
            form1.ShowDialog(); 



        }

        private async void guna2Button2_Click(object sender, EventArgs e)
        {


            this.Hide();

            AppMainForm appmainForm = new AppMainForm();
            appmainForm.Opacity = 1; 
            appmainForm.Show();

            // Плавное появление MainForm

        }
    }
}
