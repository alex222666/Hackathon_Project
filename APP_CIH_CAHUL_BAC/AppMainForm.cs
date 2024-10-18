using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_CIH_CAHUL_BAC
{
    public partial class AppMainForm : Form
    {
        database1 db;
        List<Intrebare> list;
        int score = 0;
        int id;
        public AppMainForm()
        {
            InitializeComponent();
            db = new database1();
            list = db.getData();
            id = new Random().Next(0, list.Count);
            placeDataOn(ref panel2, ref list);
        }
        public void placeDataOn(ref Panel panel, ref List<Intrebare> list)
        {
            panel.Controls.Clear();
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(751, 114);
            pictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox.BackgroundImage = new Bitmap($"../../../quizimg/{list[id].imageName}");
            panel.Controls.Add(pictureBox);
            radiobutton1.Text = list[id].Raspunsuri[2];
            radiobutton2.Text = list[id].Raspunsuri[1];
            radiobutton3.Text = list[id].Raspunsuri[0];
            radiobutton1.Tag = list[id].Raspunsuri[2];
            radiobutton2.Tag = list[id].Raspunsuri[1];
            radiobutton3.Tag = list[id].Raspunsuri[0];
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

        private void buttOnClick(object sender, EventArgs e)
        {
            foreach (Control c in panel1.Controls)
            {

                if (c is RadioButton && ((RadioButton)c).Checked)
                {
                    score += list[id].Corecte.Contains(c.Tag) ? 1 : 0;
                }
            }
            if (list.Count != 0) list.RemoveAt(id);
            if (list.Count == 0)
            {
                panel1.Controls.Clear();
                Label score = new Label();
                score.AutoSize = true;
                score.Font = new Font("Comic Sans MS,", 20, FontStyle.Bold);
                score.Text = $"Your score is {this.score}";
                score.Location = new Point(258, 102);
                panel1.Controls.Add(score);
                return;
            }
            id = new Random().Next(0, list.Count);
            placeDataOn(ref panel2, ref list);
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            Process.Start("mspaint");
        }
    }
}
