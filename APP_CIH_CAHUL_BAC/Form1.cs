using System.Diagnostics;

namespace APP_CIH_CAHUL_BAC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Opacity = 0;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler((sender, e) =>
            {
                if (this.Opacity < 1)
                    this.Opacity += 0.05;
                else
                    timer.Stop();
            });
            timer.Interval = 50;
            timer.Start();
        }

        private async void guna2TileButton7_Click_1(object sender, EventArgs e)
        {
            for (double i = 1; i > 0; i -= 0.01)
            {
                this.Opacity = i;
                await Task.Delay(6);
            }
            Application.Exit();
        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            for (double i = 1; i > 0; i -= 0.01)
            {
                this.Opacity = i;
                await Task.Delay(6);
            }

            this.Hide();

            MainForm mainForm = new MainForm();
            mainForm.Opacity = 0;
            mainForm.Show();

            // Плавное появление MainForm
            for (double i = 0; i <= 1; i += 0.01)
            {
                mainForm.Opacity = i;
                await Task.Delay(6);
            }
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
    }
}
