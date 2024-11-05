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

namespace SETTINGS_APP_CIH_CAHUL_BAC
{
    public partial class Form2 : Form
    {
        private bool isPasswordVisible2 = false;
        private Image eyeOpen1;
        private Image eyeClosed1;
        int _id;
        string ConnectionString;
        public Form2(int id, string connectionString)
        {
            InitializeComponent();
            _id = id;
            ConnectionString = connectionString;
            eyeOpen1 = Image.FromFile("../../../img/open2.png");
            eyeClosed1 = Image.FromFile("../../../img/close2.png");

            eye3.Image = eyeClosed1;

            pass1.UseSystemPasswordChar = true;

            eye3.Click += new EventHandler(Eye3_Click);
        }

        private void Eye3_Click(object sender, EventArgs e)
        {
            isPasswordVisible2 = !isPasswordVisible2;

            if (isPasswordVisible2)
            {
                pass1.UseSystemPasswordChar = false;
                eye3.Image = eyeOpen1;
            }
            else
            {
                pass1.UseSystemPasswordChar = true;
                eye3.Image = eyeClosed1;
            }
        }



        private async void Btn5_Click(object sender, EventArgs e)
        {
            for (double i = 1; i > 0; i -= 0.01)
            {
                this.Opacity = i;
                await Task.Delay(6);
            }
            this.Hide();
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM Users WHERE Id = @Id";
            string sqlVerification = "SELECT COUNT(1) FROM Users WHERE Id = @Id AND hashpsswd = @hashpsswd";
            using (SqliteConnection connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqliteCommand(sqlVerification, connection))
                {
                    command.Parameters.AddWithValue("@Id", _id);
                    command.Parameters.AddWithValue("@hashpsswd", QuickHash(pass1.Text));

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    if (count == 0)
                    {
                        Debug.WriteLine(_id + " " + QuickHash(pass1.Text));
                        pass1.BorderColor = Color.Red;
                        return;
                    }
                }
                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", _id);

                    command.ExecuteNonQuery();
                }
                connection.Close();
                this.Close();
            }
        }
        public string QuickHash(string input)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var inputHash = SHA256.HashData(inputBytes);
            return Convert.ToHexString(inputHash);
        }
    }
}
