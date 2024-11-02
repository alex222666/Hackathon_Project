using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic.ApplicationServices;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;

namespace APP_CIH_CAHUL_BAC
{
    public partial class Form1 : Form
    {
        const string ConnectionString = "Data Source=ScorQuiz.db";
        private readonly string Username="AkoForU";
        private readonly int _id = 0;
        private int slquiz;
        string materie = "Info";
        System.Windows.Forms.Timer secunde = new System.Windows.Forms.Timer
        {
            Interval = 1000
        };
        int timp;
        struct Quizs
        {
            public int id { get; set; }
            public string answer;
            public string Answer { get { return answer ?? "DefaultAnswer"; } set { answer = value; } }
        }
        Quizs[] quiz = new Quizs[10];
        int[] randomid = new int[10];
        public Form1()
        {
            InitializeComponent();
            guna2Panel20.Visible = false;
            guna2Panel14.Visible = false;
            secunde.Tick += secunde_Tick;
            DoubleBuffered = true;
        }
        DateTime dt = new DateTime();
        public void secunde_Tick(object sender, EventArgs e)
        {
            timp--;
            time.Text = dt.AddSeconds(timp).ToString("HH:mm:ss");
            if (timp == 0)
            {
                verifyAnsers();
                showScore();
                secunde.Stop();
            }
        }
        private async void guna2TileButton7_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
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
                pictureBox.BackgroundImage = new Bitmap($"../../../quizimg/{materie}/{list[randomid[id] % 10].imageName}");
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
        private void verifyAnsers()
        {
            for(int i = 0; i < 10; i++)
            {
                score += list[randomid[i] % 10].Corecte.Contains(quiz[i].Answer) ? 1 : 0;
            }
            int tmp = VerifyScore();
            if (score > tmp)
            {
                string stringsql = "INSERT INTO quizScoreInfo(Intrebare, Scor, User) VALUES(@quiz, @score, @user) " +
                    "ON CONFLICT(Intrebare, User) DO UPDATE SET Scor = excluded.Scor";

                using (SqliteConnection connection = new SqliteConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = new SqliteCommand(stringsql, connection))
                    {
                        command.Parameters.AddWithValue("@quiz", slquiz);
                        command.Parameters.AddWithValue("@score", score);
                        command.Parameters.AddWithValue("@user", _id);
                        // Use ExecuteNonQuery for INSERT/UPDATE/DELETE
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }

            }
            //INSERT INTO quizScoreInfo (Intrebare, Scor, User) VALUES (1, 8, 1) ON CONFLICT(Intrebare, User) DO UPDATE SET Scor = excluded.Scor;

        }
        private int VerifyTotalPoints()
        {
            string stringsql = $"SELECT SUM(Scor) FROM quizScore{materie} WHERE User = @user";

            using (SqliteConnection connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqliteCommand(stringsql, connection))
                {
                    command.Parameters.AddWithValue("@user", _id);
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetInt32(0);
                        }
                    }
                }
                return 0;
            }
        }
        private int VerifyScore()
        {
            string stringsql = $"SELECT Scor FROM quizScore{materie} WHERE Intrebare = @quiz AND User = @user";

            using (SqliteConnection connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqliteCommand(stringsql, connection))
                {
                    command.Parameters.AddWithValue("@quiz", slquiz);
                    command.Parameters.AddWithValue("@user", _id);
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetInt32(0);
                        }
                    }
                }
            }
            return 0;

        }
        private void inainte_Click(object sender, EventArgs e)
        {
            foreach (Control c in panel1.Controls)
            {

                if (c is RadioButton && ((RadioButton)c).Checked)
                {
                    quiz[id].answer = c.Text;
                    ((RadioButton)c).Checked = false;
                }
            }
            if(id!=9)id+=1;
            else if (id == 9)
            {
                inainte.Enabled= false;
                inapoi.Enabled=false;
                verifyAnsers();
                showScore();
            }
            placeDataOn(ref panel2, list);
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
            secunde.Stop();
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
            inainte.Enabled = true;
            inapoi.Enabled = true;
            Guna2Button varianta = (Guna2Button)sender;
            GetQuiz(int.Parse(varianta.Text));
            db = new database1();
            list = db.getData("Info", int.Parse(varianta.Text) * 10 - 10, int.Parse(varianta.Text) * 10);
            slquiz=int.Parse(varianta.Text);
            //id = new Random().Next(0, list.Count);
            timp = 300;
            secunde.Start();
            score = 0;
            time.Text = dt.AddSeconds(timp).ToString("HH:mm:ss");
            id = 0;
            if (materie == "Info")
            {
                lbvarianta.Text = $"Informatica Quiz: Varianta {varianta.Text}";
            }
            else
            {
                lbvarianta.Text = $"Matematica Quiz: Varianta {varianta.Text}";
            }
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
