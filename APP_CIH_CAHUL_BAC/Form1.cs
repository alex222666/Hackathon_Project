using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using System.Diagnostics;

namespace APP_CIH_CAHUL_BAC
{
    public partial class Form1 : Form
    {
        struct Quizs
        {
            public int id;
            public string answer;
        }
        Quizs[] quiz = new Quizs[10];
        int[] randomid = new int[10];
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
        int id = 0;
        Label tmp;
        public void showScore()
        {
            Label score = new Label();
            score.AutoSize = true;
            score.Font = new Font("Comic Sans MS,", 20, FontStyle.Bold);
            score.Text = $"Your score is {this.score}";
            score.Location = new Point(278, 302);
            tmp = score;
            guna2Panel21.Controls.Add(tmp);
            panel1.Visible = false;
        }
        public void placeDataOn(ref Panel panel, List<Intrebare> list)
        {
            panel.Controls.Clear();
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(388, 366);
            pictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            try
            {
                pictureBox.BackgroundImage = new Bitmap($"../../../quizimg/info/{list[randomid[id] % 10].imageName}");
            }
            catch
            {
                pictureBox.BackgroundImage = new Bitmap($"../../../quizimg/default.png");
            }
            panel.Controls.Add(pictureBox);
            //OutOfArray din cauza ca nu este id cu +10
            lbQuestionText.Text = list[randomid[id] % 10].questionText;
            radiobutton1.Text = list[randomid[id] % 10].Raspunsuri[2];
            radiobutton2.Text = list[randomid[id] % 10].Raspunsuri[1];
            radiobutton3.Text = list[randomid[id] % 10].Raspunsuri[0];
            radiobutton1.Tag = list[randomid[id] % 10].Raspunsuri[2];
            radiobutton2.Tag = list[randomid[id] % 10].Raspunsuri[1];
            radiobutton3.Tag = list[randomid[id] % 10].Raspunsuri[0];
            quiz[id].id = list[randomid[id] % 10].Id;
            checkedVerify();
        }
        public void checkedVerify()
        {
            foreach (Control c in panel1.Controls)
            {
                if (c is Guna2RadioButton && c.Text == quiz[id].answer)
                {
                    ((RadioButton)c).Checked = true;
                }
                else if (c is Guna2RadioButton)
                {
                    ((RadioButton)c).Checked = false;
                }
            }
        }
        private void inainte_Click(object sender, EventArgs e)  
        {
            foreach (Control c in panel1.Controls)
            {

                if (c is RadioButton && ((RadioButton)c).Checked)
                {
                    //score += list[id].Corecte.Contains(c.Tag) ? 1 : 0;
                    //MessageBox.Show(c.Tag.ToString());
                    quiz[id].answer = c.Text;
                    ((RadioButton)c).Checked = false;
                }
            }
            id += 1;
            //if (list.Count != 0) list.RemoveAt(id);
            if (id == 10)
            {
                //panel1.Controls.Clear();
                showScore();
                //return;
            }else placeDataOn(ref panel2, list);
        }
        private void inapoi_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                id -= 1;
            }
            placeDataOn(ref panel2, list);
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
                shuffledArray[j]= temp;
            }
            return shuffledArray;
        }
        private void GetQuiz(int number)
        {
            for (int i = number * 10 - 10; i < number * 10; i++)
            {
                randomid[i - (number * 10 - 10)] = i + 1;
            }
            randomid = ShuffleArray(randomid);
        }
        private void btQuiz_Click(object sender, EventArgs e)
        {
            guna2Panel21.Controls.Remove(tmp);
            panel1.Visible=true;
            guna2Panel20.Visible = true;
            guna2Panel2.Visible = false;
            guna2Panel14.Visible = false;
            Guna2Button varianta = (Guna2Button)sender;
            GetQuiz(int.Parse(varianta.Text));
            db = new database1();
            list = db.getData("Info", int.Parse(varianta.Text) * 10 - 10, int.Parse(varianta.Text) * 10);
            //id = new Random().Next(0, list.Count);
            id = 0;
            placeDataOn(ref panel2, list);
        }
        private void qz_Click(object sender, EventArgs e)
        {
            Guna2Button button= (Guna2Button)sender;
            id = int.Parse(button.Text)-1;
            placeDataOn(ref panel2, list);
            checkedVerify();
        }
    }
}
