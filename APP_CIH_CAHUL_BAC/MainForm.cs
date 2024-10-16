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
            for (double i = 1; i > 0; i -= 0.01)
            {
                this.Opacity = i;
                await Task.Delay(1); 
            }

            this.Hide(); 

            Form1 form1 = new Form1(); 
            form1.Opacity = 0; 
            form1.ShowDialog(); 


            for (double i = 0; i <= 2; i += 0.01)
            {
                form1.Opacity = i;
                await Task.Delay(1); 
            }
        }

        private async void guna2Button2_Click(object sender, EventArgs e)
        {
            for (double i = 1; i > 0; i -= 0.01)
            {
                this.Opacity = i;
                await Task.Delay(6); 
            }

            this.Hide();

            AppMainForm appmainForm = new AppMainForm();
            appmainForm.Opacity = 0; 
            appmainForm.Show();

            // Плавное появление MainForm
            for (double i = 0; i <= 1; i += 0.01)
            {
                appmainForm.Opacity = i;
                await Task.Delay(6); 
            }
        }
    }
}
