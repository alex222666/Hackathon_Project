using Guna.UI2.WinForms;
using System.Diagnostics;

namespace APP_CIH_CAHUL_BAC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            guna2Panel20.Visible = false;
            guna2Panel14.Visible = false;
            DoubleBuffered = true;
        }

        private async void guna2TileButton7_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2Panel20.Visible = false;
            guna2Panel2.Visible = false;
            MainForm mainForm = new MainForm();
            mainForm.Show();

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
            guna2Panel20.Visible = false;
            guna2Panel2.Visible = false;
            guna2Panel14.Visible = true;
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            guna2Panel20.Visible = false;
            guna2Panel2.Visible = true;
            guna2Panel14.Visible = false;
        }


        database1 db;
        List<Intrebare> list;
        int score = 0;
        int id;

        public void placeDataOn(ref Panel panel, ref List<Intrebare> list)
        {
            panel.Controls.Clear();
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(388, 366);
            pictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            try
            {
                pictureBox.BackgroundImage = new Bitmap($"../../../quizimg/{list[id].imageName}");
            }
            catch
            {
                pictureBox.BackgroundImage = new Bitmap($"../../../quizimg/default.png");
            }
            panel.Controls.Add(pictureBox);
            lbQuestionText.Text = list[id].questionText;
            radiobutton1.Text = list[id].Raspunsuri[2];
            radiobutton2.Text = list[id].Raspunsuri[1];
            radiobutton3.Text = list[id].Raspunsuri[0];
            radiobutton1.Tag = list[id].Raspunsuri[2];
            radiobutton2.Tag = list[id].Raspunsuri[1];
            radiobutton3.Tag = list[id].Raspunsuri[0];
        }

        private void inainte_Click(object sender, EventArgs e)
        {
            foreach (Control c in panel1.Controls)
            {

                if (c is RadioButton && ((RadioButton)c).Checked)
                {

                    //score += list[id].Corecte.Contains(c.Tag) ? 1 : 0;
                    MessageBox.Show(c.Tag.ToString());
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

        private void guna2Button20_Click(object sender, EventArgs e)
        {
            Process.Start("mspaint");
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            guna2Panel20.Visible = false;
            guna2Panel2.Visible = false;
            guna2Panel14.Visible = true;
        }

        //Functie care amesteca array-urile
        static int[] ShuffleArray(int[] array)
        {
            Random rand = new Random();
            int[] shuffledArray = (int[])array.Clone(); // Create a copy of the original array
            for (int i = shuffledArray.Length - 1; i > 0; i--)
            {
                int j = rand.Next(0, i + 1);
                int temp = shuffledArray[i];
                shuffledArray[i] = shuffledArray[j];
                shuffledArray[j] = temp;
            }
            return shuffledArray;
        }
        private void guna2Button18_Click(object sender, EventArgs e)
        {
            guna2Panel20.Visible = true;
            guna2Panel2.Visible = false;
            guna2Panel14.Visible = false;
            db = new database1();
            list = db.getData();
            id = new Random().Next(0, list.Count);
            placeDataOn(ref panel2, ref list);
        }
        private void btQuiz2_Click(object sender, EventArgs e)
        {

        }

        private void btQuiz3_Click(object sender, EventArgs e)
        {

        }

        private void btQuiz4_Click(object sender, EventArgs e)
        {

        }

        private void btQuiz5_Click(object sender, EventArgs e)
        {

        }

        private void btQuiz6_Click(object sender, EventArgs e)
        {

        }

        private void btQuiz7_Click(object sender, EventArgs e)
        {

        }

        private void btQuiz8_Click(object sender, EventArgs e)
        {

        }

        private void btQuiz9_Click(object sender, EventArgs e)
        {

        }

        private void btQuiz10_Click(object sender, EventArgs e)
        {

        }
    }
}
