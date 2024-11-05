using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic.ApplicationServices;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Formats.Asn1.AsnWriter;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Configuration;
using System.Text;
using Fighting_Game;
using System.Linq.Expressions;
using Microsoft.VisualBasic;
using AchievementPop;

namespace APP_CIH_CAHUL_BAC
{
    public partial class MainPage : Form
    {

        const string ConnectionString = "Data Source=ScorQuiz.db";
        public string Username = "";
        public readonly int _id = int.MinValue;
        string materie = "Info";
        Point defaultPositionPhoto;
        Point defaultPositionScore;
        int oldScore = 0;
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
        public MainPage(int id, string username)
        {
            InitializeComponent();
            _id = id;
            Username = username;
            label1.Text = $"Salut {username}!";
            defaultPositionPhoto = new Point(pbL.Location.X, pbL.Location.Y);
            defaultPositionScore = new Point(pbL.Location.X + 9, pbL.Location.Y - 30);
            guna2Panel20.Visible = false;
            guna2Panel14.Visible = false;
            guna2Panel22.Visible = false;
            secunde.Tick += secunde_Tick;
            DoubleBuffered = true;
            ScoreChangeText();
            PremiumVerify();
        }
        public void ScoreChangeText()
        {
            //lbTotalPoints.Text = VerifyTotalPoints().ToString();
            RankVerify();
            progressbar.Value = VerifyTotalPoints();
            procentage.Text = VerifyTotalPoints() + "%";
        }
        DateTime dt = new DateTime();
        public void secunde_Tick(object sender, EventArgs e)
        {
            timp--;
            time.Text = dt.AddSeconds(timp).ToString("HH:mm:ss");
            if (timp == 0)
            {
                inainte.Enabled = false;
                inapoi.Enabled = false;
                verifyAnsers();
                AdaugareScor();
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
            //Sarcici de lucru
            //pbD pdL pdMa pdMe pdJ pdV 145max
            ShowScoreWeekly();

            guna2Panel20.Visible = false;
            guna2Panel2.Visible = false;
            guna2Panel22.Visible = false;
            guna2Panel14.Visible = true;
        }
        private void ShowScoreWeekly()
        {
            List<QuizScoreWeekly> tmp = EveryScoreWeek();
            double pasi = MaximScoreWeek();
            DateTime dateTime = DateTime.Now;
            foreach (QuizScoreWeekly s in tmp)
            {
                if ((int)dateTime.DayOfWeek == s.Day) puncteAzi.Text = s.Score.ToString();
                switch (s.Day)
                {
                    case 1:
                        {
                            pbL.Location = new Point(pbL.Location.X, defaultPositionPhoto.Y);
                            lbPntsL.Location = new Point(lbPntsL.Location.X, defaultPositionScore.Y);
                            pbL.Size = new Size(pbL.Width, 0);
                            pbL.Size = new Size(pbL.Width, pbL.Height + Convert.ToInt32(pasi * s.Score));
                            pbL.Location = new Point(pbL.Location.X, pbL.Location.Y - Convert.ToInt32(pasi * s.Score));
                            lbPntsL.Location = new Point(lbPntsL.Location.X, lbPntsL.Location.Y - Convert.ToInt32(pasi * s.Score));
                            lbPntsL.Text = s.Score.ToString();
                        }
                        break;
                    case 2:
                        {
                            pbMa.Location = new Point(pbMa.Location.X, defaultPositionPhoto.Y);
                            lbPntsMa.Location = new Point(lbPntsMa.Location.X, defaultPositionScore.Y);
                            pbL.Size = new Size(pbL.Width, 0);
                            pbMa.Size = new Size(pbMa.Width, pbMa.Height + Convert.ToInt32(pasi * s.Score));
                            pbMa.Location = new Point(pbMa.Location.X, pbMa.Location.Y - Convert.ToInt32(pasi * s.Score));
                            lbPntsMa.Location = new Point(lbPntsMa.Location.X, lbPntsMa.Location.Y - Convert.ToInt32(pasi * s.Score));
                            lbPntsMa.Text = s.Score.ToString();
                        }
                        break;
                    case 3:
                        {
                            pbMe.Location = new Point(pbMe.Location.X, defaultPositionPhoto.Y);
                            lbPntsMe.Location = new Point(lbPntsMe.Location.X, defaultPositionScore.Y);
                            pbMe.Size = new Size(pbL.Width, 0);
                            pbMe.Size = new Size(pbMe.Width, pbMe.Height + Convert.ToInt32(pasi * s.Score));
                            pbMe.Location = new Point(pbMe.Location.X, pbMe.Location.Y - Convert.ToInt32(pasi * s.Score));
                            lbPntsMe.Location = new Point(lbPntsMe.Location.X, lbPntsMe.Location.Y - Convert.ToInt32(pasi * s.Score));
                            lbPntsMe.Text = s.Score.ToString();
                        }
                        break;
                    case 4:
                        {
                            pbJ.Location = new Point(pbJ.Location.X, defaultPositionPhoto.Y);
                            lbPntsJ.Location = new Point(lbPntsJ.Location.X, defaultPositionScore.Y);
                            pbJ.Size = new Size(pbL.Width, 0);
                            pbJ.Size = new Size(pbJ.Width, pbJ.Height + Convert.ToInt32(pasi * s.Score));
                            pbJ.Location = new Point(pbJ.Location.X, pbJ.Location.Y - Convert.ToInt32(pasi * s.Score));
                            lbPntsJ.Location = new Point(lbPntsJ.Location.X, lbPntsJ.Location.Y - Convert.ToInt32(pasi * s.Score));
                            lbPntsJ.Text = s.Score.ToString();
                        }
                        break;
                    case 5:
                        {
                            pbV.Location = new Point(pbV.Location.X, defaultPositionPhoto.Y);
                            lbPntsV.Location = new Point(lbPntsV.Location.X, defaultPositionScore.Y);
                            pbV.Size = new Size(pbL.Width, 0);
                            pbV.Size = new Size(pbV.Width, pbV.Height + Convert.ToInt32(pasi * s.Score));
                            pbV.Location = new Point(pbV.Location.X, pbV.Location.Y - Convert.ToInt32(pasi * s.Score));
                            lbPntsV.Location = new Point(lbPntsV.Location.X, lbPntsV.Location.Y - Convert.ToInt32(pasi * s.Score));
                            lbPntsV.Text = s.Score.ToString();
                        }
                        break;
                    case 6:
                        {
                            pbS.Location = new Point(pbS.Location.X, defaultPositionPhoto.Y);
                            lbPntsS.Location = new Point(lbPntsS.Location.X, defaultPositionScore.Y);
                            pbS.Size = new Size(pbL.Width, 0);
                            pbS.Size = new Size(pbS.Width, pbS.Height + Convert.ToInt32(pasi * s.Score));
                            pbS.Location = new Point(pbS.Location.X, pbS.Location.Y - Convert.ToInt32(pasi * s.Score));
                            lbPntsS.Location = new Point(lbPntsS.Location.X, lbPntsS.Location.Y - Convert.ToInt32(pasi * s.Score));
                            lbPntsS.Text = s.Score.ToString();
                        }
                        break;
                    case 0:
                        {
                            pbD.Location = new Point(pbD.Location.X, defaultPositionPhoto.Y);
                            lbPntsD.Location = new Point(lbPntsD.Location.X, defaultPositionScore.Y);
                            pbD.Size = new Size(pbL.Width, 0);
                            pbD.Size = new Size(pbD.Width, pbD.Height + Convert.ToInt32(pasi * s.Score));
                            pbD.Location = new Point(pbD.Location.X, pbD.Location.Y - Convert.ToInt32(pasi * s.Score));
                            lbPntsD.Location = new Point(lbPntsD.Location.X, lbPntsD.Location.Y - Convert.ToInt32(pasi * s.Score));
                            lbPntsD.Text = s.Score.ToString();
                        }
                        break;
                }
            }
        }
        private double MaximScoreWeek()
        {
            //SELECT max(Score) FROM WeeklyQuizScoreInfo where User={_id}
            string stringsql = $"SELECT max(Score) FROM WeeklyQuizScore{materie} where User ={_id}";
            double tmp = 0;
            using (SqliteConnection connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqliteCommand(stringsql, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            try
                            {
                                tmp = reader.GetInt32(0);
                            }
                            catch { 
                                tmp = 1; 
                            }
                        }
                    }
                }
            }
            return 100 / tmp;
        }
        private List<QuizScoreWeekly> EveryScoreWeek()
        {
            List<QuizScoreWeekly> data = new List<QuizScoreWeekly>();
            //SELECT max(Score) FROM WeeklyQuizScoreInfo where User={_id}
            for(int i = 0; i < 7; i++)
            {
                string stringsql = $"SELECT sum(Score) from WeeklyQuizScore{materie} where User={_id} and Day={i} ";

                using (SqliteConnection connection = new SqliteConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = new SqliteCommand(stringsql, connection))
                    {
                        using (SqliteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                QuizScoreWeekly tmp = new QuizScoreWeekly();
                                tmp.Day = i;
                                try {
                                    tmp.Score = reader.GetInt32(0);
                                }
                                catch
                                {
                                    tmp.Day = 0;
                                }
                                data.Add(tmp);
                            }
                        }
                    }
                }
            }
            return data;
        }

        public void AdaugareScor()
        {
            List<QuizScoreWeekly> tmp = EveryScoreWeek();
            DateTime dateTime = DateTime.Now;
            int dayscore = 0;
            foreach (var s in tmp)
            {
                if (s.Day == (int)dateTime.DayOfWeek)
                {
                    dayscore = s.Score;
                }
            }
            //INSERT INTO WeeklyQuizScoreInfo (Day, Scor) VALUES(0,1) ON CONFLICT(Day) DO UPDATE SET Scor = excluded.Scor
            if (score > oldScore)
            {
                string stringsql = $"INSERT INTO WeeklyQuizScore{materie} (Day, Score, User) VALUES({(int)dateTime.DayOfWeek},{score - oldScore + dayscore},{_id})";

                using (SqliteConnection connection = new SqliteConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = new SqliteCommand(stringsql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            ScoreChangeText();
            guna2Panel20.Visible = false;
            guna2Panel2.Visible = true;
            guna2Panel14.Visible = false;
            guna2Panel22.Visible = false;
        }
        public void RankVerify()
        {
            int rank=0;
            string stringsql = sqlCommand($"Username = \"{Username}\"");

            using (SqliteConnection connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqliteCommand(stringsql, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lbTotalPoints.Text = reader.GetInt32(1).ToString();
                            rank=reader.GetInt32(2);
                        }
                    }
                }
            }
            lbrank.Text = $"Tu Ocupi locul {rank} la curs";
            try{
                rankPB.Image = Image.FromFile($"../../../img/rank{rank}.png");
            }
            catch{
                rankPB.Dispose();
            }
            label26.Text = RankInfo(1, 0);
            label27.Text = RankInfo(2, 0);
            label28.Text = RankInfo(1, 1);
            label29.Text = RankInfo(2, 1);
        }
        public string RankInfo(int rank,int id)
        {
            string stringsql = sqlCommand($"Rank = {rank}");

            using (SqliteConnection connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqliteCommand(stringsql, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            try { 
                                return reader.GetString(id).ToString();
                            }
                            catch
                            {
                                return string.Empty;
                            }
                        }
                    }
                }
            }
            return string.Empty;
        }
        public string sqlCommand(string condition) => "SELECT * FROM " +
                "(SELECT " +
                    "u.Username," +
                    "SUM(q.Scor) AS TotalScore," +
                    "RANK() OVER (ORDER BY SUM(q.Scor) DESC) AS Rank " +
                    "FROM " +
                    $"quizScore{materie} q " +
                    "INNER JOIN " +
                    "Users u ON q.User = u.ID " +
                    "GROUP BY " +
                    "u.Username) " +
                    "AS RankedUsers " +
                 $"WHERE {condition}";

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
            //OutOfArray din cauza ca nu este id cu +10 (SolvedAlready)
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
            for (int i = 0; i < 10; i++)
            {
                score += list[randomid[i] % 10].Corecte.Contains(quiz[i].Answer) ? 1 : 0;
            }
            oldScore = VerifyScore();
            if (score > oldScore)
            {
                string stringsql = $"INSERT INTO quizScore{materie}(Intrebare, Scor, User) VALUES(@quiz, @score, @user) " +
                    "ON CONFLICT(Intrebare, User) DO UPDATE SET Scor = excluded.Scor";

                using (SqliteConnection connection = new SqliteConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = new SqliteCommand(stringsql, connection))
                    {
                        command.Parameters.AddWithValue("@quiz", QzLb);
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
                            try
                            {
                                return reader.GetInt32(0);
                            }
                            catch
                            {
                                return 0;
                            }
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
                    command.Parameters.AddWithValue("@quiz", QzLb);
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
            if (id != 9) id += 1;
            else if (id == 9)
            {
                inainte.Enabled = false;
                inapoi.Enabled = false;
                verifyAnsers();
                AdaugareScor();
                secunde.Stop();
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
            ShowScoreWeekly();
            guna2Panel20.Visible = false;
            guna2Panel2.Visible = false;
            guna2Panel14.Visible = true;
            guna2Panel22.Visible = false;
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
        private void GetQuiz(int number)
        {
            for (int i = number * 10 - 10; i < number * 10; i++)
            {
                randomid[i - (number * 10 - 10)] = i + 1;
            }
            randomid = ShuffleArray(randomid);
        }
        int QzLb;
        private void btQuiz_Click(object sender, EventArgs e)
        {
            Guna2Button varianta = (Guna2Button)sender;
            QzLb = int.Parse(varianta.Text);
            lbQuiz.Text = $"Quiz:{QzLb}";
            btRezolvaQuiz.Enabled = true;
            lbScore.Text = $"Score:{VerifyScore()}";

        }
        private void qz_Click(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;
            id = int.Parse(button.Text) - 1;
            placeDataOn(ref panel2, list);
            checkedVerify();
        }
        private void btRezolvaQuiz_Click(object sender, EventArgs e)
        {
            guna2Panel21.Controls.Remove(tmp);
            panel1.Visible = true;
            guna2Panel20.Visible = true;
            guna2Panel2.Visible = false;
            guna2Panel14.Visible = false;
            guna2Panel22.Visible = false;
            inainte.Enabled = true;
            inapoi.Enabled = true;
            GetQuiz(QzLb);
            db = new database1();
            list = db.getData("Info", QzLb * 10 - 10, QzLb * 10);
            timp = 300;
            secunde.Start();
            score = 0;
            time.Text = dt.AddSeconds(timp).ToString("HH:mm:ss");
            id = 0;
            if (materie == "Info")
            {
                lbvarianta.Text = $"Informatica Quiz: Varianta {QzLb}";
            }
            else
            {
                lbvarianta.Text = $"Matematica Quiz: Varianta {QzLb}";
            }
            placeDataOn(ref panel2, list);
        }
        public void PremiumVerify()
        {
            int premium = 0;
            string stringsql = $"SELECT premium FROM Users where id={_id}";
            using (SqliteConnection connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqliteCommand(stringsql, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            premium = reader.GetInt32(0);
                        }
                    }
                }
            }
            if (premium == 1)
            {
                label20.Visible = false;
                label19.Text = "Incearca jocul Activat";
                btActivate.Text = "Play";
            }
        }
        private void btActivate_Click(object sender, EventArgs e)
        {
            //SELECT premium FROM Users where id=1
            PremiumVerify();
            if (btActivate.Text == "Play")
            {
                MenuGame menu = new MenuGame(this);
                menu.Show();
                this.Visible = false;
            }
            else
            {
                ActivationKey tmp = new ActivationKey(this);
                tmp.ShowDialog();
            }
        }

        private void guna2TileButton3_Click(object sender, EventArgs e)
        {
            guna2Panel20.Visible = false;
            guna2Panel2.Visible = false;
            guna2Panel14.Visible = false;
            guna2Panel22.Visible = true;
            int user = 1;
            const string ConnectionString = "Data Source=Achievements.db";
            achievementsDB db;
            List<Achievement> achievements;
                db = new achievementsDB();
                achievements = db.getData();
                int Y = 0;

                using (SqliteConnection connection = new SqliteConnection(ConnectionString))
                {
                    connection.Open();
                    foreach (Achievement achievement in achievements)
                    {
                        string stringsql = $"SELECT COUNT(*) FROM Achievements_complete WHERE id_user = {_id} AND id_achievement = {achievement.Id}";
                        using (var command = new SqliteCommand(stringsql, connection))
                        {
                            long achievementCheck = (long)command.ExecuteScalar();
                            Panel achievementPanel = new Panel
                            {
                                Width = guna2Panel23.Width - 50,
                                Height = 120,
                                Padding = new Padding(5),
                                Location = new Point(5, Y)
                            };

                            Image image = new Bitmap($"../../../achievementsimg/{achievement.AchievementImage}bw.png");
                            if (achievementCheck == 1) image = new Bitmap($"../../../achievementsimg/{achievement.AchievementImage}.png");
                            PictureBox pictureBox = new PictureBox
                            {
                                Image = image,
                                BackColor = Color.White,
                                Size = new Size(100, 100),
                                SizeMode = PictureBoxSizeMode.Zoom,
                                Location = new Point(5, 10)
                            };

                            achievementPanel.Controls.Add(pictureBox);

                            Label titleLabel = new Label
                            {
                                Text = achievement.AchievementName,
                                Font = new Font("Comic Sans MS", 18, FontStyle.Bold),
                                Location = new Point(115, 10),
                                AutoSize = true
                            };
                            achievementPanel.Controls.Add(titleLabel);

                            Label descriptionLabel = new Label
                            {
                                Text = achievement.AchievementText,
                                Font = new Font("Comic Sans MS", 12, FontStyle.Bold),
                                Location = new Point(115, 50),
                                Size = new Size(achievementPanel.Width - 100, 60),
                                AutoSize = false
                            };
                            achievementPanel.Controls.Add(descriptionLabel);
                            guna2Panel23.Controls.Add(achievementPanel);
                            Y += 120;
                        }
                    }
                }
            }
        }
    }
