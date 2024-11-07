using APP_CIH_CAHUL_BAC;
using AppGamiFy.Properties;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace APP_CIH_CAHUL_BAC_SIGN_IN__SIGN_UP
{
    public partial class Sign_In : Form
    {
        private Image originalImage;

        private bool isPasswordVisible1 = false;  // Отслеживает видимость пароля для password_1
        private Image eyeOpen;  // Изображение "открытого глаза"
        private Image eyeClosed;  // Изображение "закрытого глаза"

        public Sign_In()
        {
            InitializeComponent();
            if (Settings.Default.Username != "")
            {
                usernameTbx.Text=Settings.Default.Username;
                passwordTbx.Text=Settings.Default.Password;
            }
            CheckBox.Checked = Settings.Default.Checked;
            // Сохраняем изначальное изображение для возврата после убирания курсора
            originalImage = btn_sign_in.Image;

            // Привязываем обработчики событий для PictureBox
            btn_sign_in.MouseEnter += new EventHandler(Btn_sign_in_MouseEnter);
            btn_sign_in.MouseLeave += new EventHandler(Btn_sign_in_MouseLeave);



            // Загружаем изображения глаз
            eyeOpen = Image.FromFile("../../../img/open.png");  // Путь к изображению открытого глаза
            eyeClosed = Image.FromFile("../../../img/close.png");  // Путь к изображению закрытого глаза

            // Устанавливаем начальные изображения "закрытого глаза" при запуске приложения
            eye1.Image = eyeClosed;

            // Изначально пароль скрыт
            passwordTbx.UseSystemPasswordChar = true;


            // Привязываем обработчики нажатий к PictureBox
            eye1.Click += new EventHandler(Eye1_Click);
        }

        // Когда курсор попадает на PictureBox
        private void Btn_sign_in_MouseEnter(object sender, EventArgs e)
        {
            // Меняем изображение на другую картинку
            btn_sign_in.Image = Image.FromFile("../../../img/Button_8.png");
        }

        // Когда курсор уходит с PictureBox
        private void Btn_sign_in_MouseLeave(object sender, EventArgs e)
        {
            // Возвращаем исходное изображение
            btn_sign_in.Image = originalImage;
        }

        // Обработчик нажатия для pictureBoxEye1
        private void Eye1_Click(object sender, EventArgs e)
        {
            // Переключаем видимость пароля для password_1
            isPasswordVisible1 = !isPasswordVisible1;

            if (isPasswordVisible1)
            {
                // Показываем пароль и меняем картинку на "открытый глаз"
                passwordTbx.UseSystemPasswordChar = false;
                eye1.Image = eyeOpen;
            }
            else
            {
                // Скрываем пароль и меняем картинку на "закрытый глаз"
                passwordTbx.UseSystemPasswordChar = true;
                eye1.Image = eyeClosed;
            }
        }


        private async void close_logo_Click(object sender, EventArgs e)
        {
            for (double i = 1; i > 0; i -= 0.05)
            {
                this.Opacity = i;
                await Task.Delay(6); // Задержка в 5 миллисекунд
            }
            this.Close();
        }

        private async void lbl_sign_up_Click(object sender, EventArgs e)
        {
            // Плавное исчезновение текущей формы
            for (double i = 1; i > 0; i -= 0.05)
            {
                this.Opacity = i;
                await Task.Delay(6);
            }

            this.Hide();  // Скрываем текущую форму

            // Создаем новую форму Sign_Up
            Sign_Up sign_Up = new Sign_Up();
            sign_Up.Opacity = 0;  // Начальная прозрачность формы 0 (невидима)
            sign_Up.StartPosition = FormStartPosition.CenterScreen;  // Центрируем форму на экране
            sign_Up.FormClosed += (s, args) => this.Close();  // Закрываем главное окно, если Sign_Up закрыт
            sign_Up.Show();  // Показываем новую форму

            // Таймер для плавного появления новой формы
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler((s, ev) =>
            {
                if (sign_Up.Opacity < 1)
                    sign_Up.Opacity += 0.05;  // Увеличиваем прозрачность
                else
                    timer.Stop();  // Останавливаем таймер, когда форма становится полностью видимой
            });

            timer.Interval = 15;  // Интервал для плавной анимации
            timer.Start();  // Запускаем таймер
        }
        private void btn_sign_in_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=ScorQuiz.db";
            string query = "SELECT Id FROM Users WHERE Username = @username AND hashpsswd = @password";

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@username", usernameTbx.Text);
                command.Parameters.AddWithValue("@password", EncryptPassword(passwordTbx.Text));
                int id=-1;
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                }
                if (id != -1)
                {
                    if (CheckBox.Checked)
                    {
                        Settings.Default.Password = passwordTbx.Text;
                        Settings.Default.Username = usernameTbx.Text;
                        Settings.Default.Checked = true;
                        Settings.Default.Save();
                    }
                    else
                    {
                        Settings.Default.Password = "";
                        Settings.Default.Username = "";
                        Settings.Default.Checked = false;
                        Settings.Default.Save();
                    }
                    MainPage main = new MainPage(id, usernameTbx.Text);
                    main.Show();
                    main.FormClosed += (s, args) => this.Close();
                    this.Hide();

                    usernameTbx.BorderColor = Color.FromArgb(213, 218, 223);
                    passwordTbx.BorderColor = Color.FromArgb(213, 218, 223);
                    guna2PictureBox1.ImageLocation = "../../../img/errors/Correct.png";
                    guna2PictureBox3.ImageLocation = "../../../img/errors/Correct.png";
                }
                else
                {
                    usernameTbx.BorderColor = Color.Red;
                    passwordTbx.BorderColor = Color.Red;
                    guna2PictureBox1.ImageLocation = "../../../img/errors/InCorrect.png";
                    guna2PictureBox3.ImageLocation = "../../../img/errors/InCorrect.png";
                }
                connection.Close();
            }
        }
        private string EncryptPassword(string input)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var inputHash = SHA256.HashData(inputBytes);
            return Convert.ToHexString(inputHash);
        }
    }
}
