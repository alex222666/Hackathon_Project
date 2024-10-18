using System.Diagnostics;

namespace APP_CIH_CAHUL_BAC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Opacity = 1;
            guna2Panel14.Visible = false;
            DoubleBuffered = true;
        }

        private async void guna2TileButton7_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {

            guna2Panel2.Visible = false;

            MainForm mainForm = new MainForm();
            mainForm.Opacity = 1;
            mainForm.Show();

            // Плавное появление MainForm

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", "file:///C:/Users/N0%20N4M3/Desktop/APP%20CIH%20CAHUL%20BAC%20(2)%202/APP%20CIH%20CAHUL%20BAC/APP_CIH_CAHUL_BAC/APP_CIH_CAHUL_BAC/pdf/info.pdf");
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", "file:///C:/Users/N0%20N4M3/Desktop/playlist.htm");
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", "https://ance.gov.md/content/informatica");
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            guna2Panel2.Visible = false;
            guna2Panel14.Visible = true;
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            guna2Panel2.Visible = true;
            guna2Panel14.Visible = false;
        }

        private void label65_Click(object sender, EventArgs e)
        {

        }
    }
}
