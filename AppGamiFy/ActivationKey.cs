using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Windows.Forms.VisualStyles;
using Microsoft.Data.Sqlite;
using static System.Formats.Asn1.AsnWriter;

namespace APP_CIH_CAHUL_BAC
{
    public partial class ActivationKey : Form
    {
        const string ConnectionString = "Data Source=ScorQuiz.db";
        public string QuickHash(string input)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var inputHash = SHA256.HashData(inputBytes);
            return Convert.ToHexString(inputHash);
        }
        private readonly Form1 _form;
        public ActivationKey(Form1 tmp)
        {
            _form = tmp;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtKey.Text==QuickHash($"{_form.Username.ToLower()}premium?forever"))
            {
                string stringsql = $"UPDATE Users SET premium=1 where id={_form._id}";

                using (SqliteConnection connection = new SqliteConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = new SqliteCommand(stringsql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Activation Complete");
                _form.PremiumVerify();
                this.Close();
            }

            else
            {
                MessageBox.Show("Invalid Key");
            }
        }
    }
}
