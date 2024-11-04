using Guna.UI2.WinForms.Suite;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;

namespace APP_CIH_CAHUL_BAC
{
    public partial class AchievementsForm : Form
    {
        int user = 1;
        const string ConnectionString = "Data Source=Achievements.db";
        achievementsDB db;
        List<Achievement> achievements;
        public AchievementsForm()
        {
            InitializeComponent();
            db = new achievementsDB();
            achievements = db.getData();
            int Y = 0;

            using (SqliteConnection connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                foreach (Achievement achievement in achievements)
                {
                    string stringsql = $"SELECT COUNT(*) FROM Achievements_complete WHERE id_user = {user} AND id_achievement = {achievement.Id}";
                    using (var command = new SqliteCommand(stringsql, connection))
                    {
                        long achievementCheck = (long)command.ExecuteScalar();
                        Panel achievementPanel = new Panel
                        {
                            Width = guna2Panel19.Width-50,
                            Height = 120,
                            Padding = new Padding(5),
                            Location = new Point(5, Y)
                        };

                        Image image = new Bitmap($"../../../achievementsimg/{achievement.AchievementImage}bw.png");
                        if(achievementCheck == 1) image = new Bitmap($"../../../achievementsimg/{achievement.AchievementImage}.png");
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
                        guna2Panel19.Controls.Add(achievementPanel);
                        Y += 120;
                    }
                }
            }
        }
    }
}
