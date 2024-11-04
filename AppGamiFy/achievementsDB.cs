using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_CIH_CAHUL_BAC
{
    public class Achievement
    {
        public int Id { get; set; }
        public string AchievementImage { get; set; }
        public string AchievementName { get; set; }
        public string AchievementText { get; set; }

        public Achievement(int id, string achievementImage, string achievementName, string achievementText)
        {
            this.Id = id;
            this.AchievementImage = achievementImage;
            this.AchievementName = achievementName;
            this.AchievementText = achievementText;
        }
    }

    public class achievementsDB
    {
        private readonly string connectionString;
        //public string connectionString;
        public achievementsDB()
        {
            this.connectionString = "Data Source=Achievements.db";
        }
        public List<Achievement> getData()
        {
            List<Achievement> data = new List<Achievement>();
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand($"SELECT * FROM \"Achievements\";", connection);

                SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string achievementImage = Convert.ToString(reader["AchievementImage"]);
                    string achievementName = Convert.ToString(reader["AchievementName"]);
                    string achievementText = Convert.ToString(reader["AchievementText"]);
                    data.Add(new Achievement(id, achievementImage, achievementName, achievementText));
                }
                reader.Close();
                connection.Close();
            }
            return data;
        }
    }
}
