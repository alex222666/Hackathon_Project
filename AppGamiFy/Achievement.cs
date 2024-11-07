using APP_CIH_CAHUL_BAC;
using Microsoft.Data.Sqlite;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Windows.Forms;
using WMPLib;


namespace AchievementPop
{
    public partial class Achievements : Form
    {
        WindowsMediaPlayer player=new WindowsMediaPlayer();
        public Achievements(int id)
        {
            this.FormBorderStyle= FormBorderStyle.None; 
            InitializeComponent();
            this.DoubleBuffered = true;
            const string ConnectionString = "Data Source=Achievements.db";
            achievementsDB db;
            List<Achievement> achievements;
            db = new achievementsDB();
            achievements = db.getData(id);
            int Y = 0;

            using (SqliteConnection connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                foreach (Achievement achievement in achievements)
                {
                    string stringsql = $"SELECT COUNT(*) FROM Achievements_complete WHERE id_achievement = {id}";
                    using (var command = new SqliteCommand(stringsql, connection))
                    {
                        long achievementCheck = (long)command.ExecuteScalar();
                        Panel achievementPanel = new Panel
                        {
                            Width = this.Width - 50,
                            Height = 120,
                            Padding = new Padding(5),
                            Location = new Point(5, Y)
                        };

                        Image image = new Bitmap($"../../../achievementsimg/{achievement.AchievementImage}.png");
                        PictureBox pictureBox = new PictureBox
                        {
                            Image = image,
                            BackColor = Color.White,
                            Size = new Size(70, 70),
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Location = new Point(5, 10)
                        };

                        achievementPanel.Size = new Size(this.Width, this.Height);
                        achievementPanel.Controls.Add(pictureBox);
                        Label titleLabel = new Label
                        {
                            Text = achievement.AchievementName,
                            Font = new Font("Comic Sans MS", 10, FontStyle.Bold),
                            Location = new Point(85, 10),
                            AutoSize = true
                        };
                        achievementPanel.Controls.Add(titleLabel);

                        Label descriptionLabel = new Label
                        {
                            Text = achievement.AchievementText,
                            Font = new Font("Comic Sans MS", 8, FontStyle.Bold),
                            Location = new Point(85, 50),
                            Size = new Size(achievementPanel.Width, 60),
                            AutoSize = false
                        };
                        achievementPanel.Controls.Add(descriptionLabel);
                        this.Controls.Add(achievementPanel);
                    }
                }
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleparam = base.CreateParams;
                handleparam.ExStyle |= 0x02000000;
                return handleparam;
            }
        }
        private void Position()
        {
            int ScreenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int ScreenHeigth = Screen.PrimaryScreen.WorkingArea.Height;
            int X = ScreenWidth - this.Width;
            int Y = ScreenHeigth - this.Height+130;
            this.Location = new Point(X, Y);
        }
        System.Windows.Forms.Timer TimeUp = new System.Windows.Forms.Timer {
            Interval = 5
        };
        System.Windows.Forms.Timer TimeDown = new System.Windows.Forms.Timer
        {
            Interval = 5
        };
        System.Windows.Forms.Timer TimeStay = new System.Windows.Forms.Timer
        {
            Interval = 3000
        };
        private void Form1_Load(object sender, EventArgs e)
        {
            Position();
            int Y=this.Location.Y;
            TimeUp.Tick += new EventHandler((sender, e) => {
                if (this.Location.Y >= Screen.PrimaryScreen.WorkingArea.Height - this.Height)
                {
                    this.Location = new Point(this.Location.X, this.Location.Y - 3);
                } else {
                    player.URL = "sounds/achsound.mp3";
                    TimeUp.Stop();
                    TimeStay.Start();
                }
            });
            TimeStay.Tick += new EventHandler((sender, e) =>
            {
                TimeStay.Stop();
                TimeDown.Start();
            });
            TimeDown.Tick += new EventHandler((sender, e) => {
                if (this.Location.Y <= Y)
                {
                    this.Location = new Point(this.Location.X, this.Location.Y + 3);
                }
                else this.Close();
            });
            TimeUp.Start();
        }
    }
}
