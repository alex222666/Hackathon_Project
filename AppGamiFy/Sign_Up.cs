using Microsoft.Data.Sqlite;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Cryptography;

namespace APP_CIH_CAHUL_BAC_SIGN_IN__SIGN_UP
{
    public partial class Sign_Up : Form
    {
        private Image originalImage;  // Хранит исходное изображение

        private bool isPasswordVisible1 = false;  // Отслеживает видимость пароля для password_1
        private bool isPasswordVisible2 = false;  // Отслеживает видимость пароля для password_2
        private Image eyeOpen;  // Изображение "открытого глаза"
        private Image eyeClosed;  // Изображение "закрытого глаза"

        public Sign_Up()
        {
            InitializeComponent();

            // Сохраняем изначальное изображение для возврата после убирания курсора
            originalImage = btn_sign_up.Image;

            // Привязываем обработчики событий для PictureBox
            btn_sign_up.MouseEnter += new EventHandler(Btn_sign_up_MouseEnter);
            btn_sign_up.MouseLeave += new EventHandler(Btn_sign_up_MouseLeave);



            // Загружаем изображения глаз
            eyeOpen = Image.FromFile("../../../img/open.png");  // Путь к изображению открытого глаза
            eyeClosed = Image.FromFile("../../../img/close.png");  // Путь к изображению закрытого глаза

            // Устанавливаем начальные изображения "закрытого глаза" при запуске приложения
            eye1.Image = eyeClosed;
            eye2.Image = eyeClosed;

            // Изначально пароль скрыт
            password_1.UseSystemPasswordChar = true;
            password_2.UseSystemPasswordChar = true;


            // Привязываем обработчики нажатий к PictureBox
            eye1.Click += new EventHandler(Eye1_Click);
            eye2.Click += new EventHandler(Eye2_Click);
        }


        // Когда курсор попадает на PictureBox
        private void Btn_sign_up_MouseEnter(object sender, EventArgs e)
        {
            // Меняем изображение на другую картинку
            btn_sign_up.Image = Image.FromFile("../../../img/Button_2.png");
        }

        // Когда курсор уходит с PictureBox
        private void Btn_sign_up_MouseLeave(object sender, EventArgs e)
        {
            // Возвращаем исходное изображение
            btn_sign_up.Image = originalImage;
        }

        // Обработчик нажатия для pictureBoxEye1
        private void Eye1_Click(object sender, EventArgs e)
        {
            // Переключаем видимость пароля для password_1
            isPasswordVisible1 = !isPasswordVisible1;

            if (isPasswordVisible1)
            {
                // Показываем пароль и меняем картинку на "открытый глаз"
                password_1.UseSystemPasswordChar = false;
                eye1.Image = eyeOpen;
            }
            else
            {
                // Скрываем пароль и меняем картинку на "закрытый глаз"
                password_1.UseSystemPasswordChar = true;
                eye1.Image = eyeClosed;
            }
        }

        // Обработчик нажатия для pictureBoxEye2
        private void Eye2_Click(object sender, EventArgs e)
        {
            // Переключаем видимость пароля для password_2
            isPasswordVisible2 = !isPasswordVisible2;

            if (isPasswordVisible2)
            {
                // Показываем пароль и меняем картинку на "открытый глаз"
                password_2.UseSystemPasswordChar = false;
                eye2.Image = eyeOpen;
            }
            else
            {
                // Скрываем пароль и меняем картинку на "закрытый глаз"
                password_2.UseSystemPasswordChar = true;
                eye2.Image = eyeClosed;
            }
        }

        private async void close_logo_Click(object sender, EventArgs e)
        {
            for (double i = 1; i > 0; i -= 0.01)
            {
                this.Opacity = i;
                await Task.Delay(6); // Задержка в 5 миллисекунд
            }
            this.Close();
        }

        private async void lbl_sign_in_Click(object sender, EventArgs e)
        {
            // Плавное исчезновение текущей формы
            for (double i = 1; i > 0; i -= 0.01)
            {
                this.Opacity = i;
                await Task.Delay(6);
            }

            this.Hide();  // Скрываем текущую форму

            // Создаем новую форму Sign_Up
            Sign_In sign_In = new Sign_In();
            sign_In.Opacity = 0;  // Начальная прозрачность формы 0 (невидима)
            sign_In.StartPosition = FormStartPosition.CenterScreen;  // Центрируем форму на экране
            sign_In.FormClosed += (s, args) => this.Close();  // Закрываем главное окно, если Sign_Up закрыт
            sign_In.Show();  // Показываем новую форму

            // Таймер для плавного появления новой формы
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler((s, ev) =>
            {
                if (sign_In.Opacity < 1)
                    sign_In.Opacity += 0.02;  // Увеличиваем прозрачность
                else
                    timer.Stop();  // Останавливаем таймер, когда форма становится полностью видимой
            });

            timer.Interval = 15;  // Интервал для плавной анимации
            timer.Start();  // Запускаем таймер
        }

        private async void ter_de_util_Click(object sender, EventArgs e)
        {
            // Плавное исчезновение текущей формы
            for (double i = 1; i > 0; i -= 0.01)
            {
                this.Opacity = i;
                await Task.Delay(6);
            }

            this.Hide();  // Скрываем текущую форму

            // Создаем новую форму Sign_Up
            Termenii_de_utilizare termenii_de_utilizare = new Termenii_de_utilizare();
            termenii_de_utilizare.Opacity = 0;  // Начальная прозрачность формы 0 (невидима)
            termenii_de_utilizare.StartPosition = FormStartPosition.CenterScreen;  // Центрируем форму на экране
            termenii_de_utilizare.FormClosed += (s, args) => this.Close();  // Закрываем главное окно, если Sign_Up закрыт
            termenii_de_utilizare.Show();  // Показываем новую форму

            // Таймер для плавного появления новой формы
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler((s, ev) =>
            {
                if (termenii_de_utilizare.Opacity < 1)
                    termenii_de_utilizare.Opacity += 0.02;  // Увеличиваем прозрачность
                else
                    timer.Stop();  // Останавливаем таймер, когда форма становится полностью видимой
            });

            timer.Interval = 20;  // Интервал для плавной анимации
            timer.Start();  // Запускаем таймер
        }

        private async void pol_de_conf_Click(object sender, EventArgs e)
        {
            // Плавное исчезновение текущей формы
            for (double i = 1; i > 0; i -= 0.01)
            {
                this.Opacity = i;
                await Task.Delay(6);
            }

            this.Hide();  // Скрываем текущую форму

            // Создаем новую форму Sign_Up
            Politica_de_confidentialitate politica_de_confidentialitate = new Politica_de_confidentialitate();
            politica_de_confidentialitate.Opacity = 0;  // Начальная прозрачность формы 0 (невидима)
            politica_de_confidentialitate.StartPosition = FormStartPosition.CenterScreen;  // Центрируем форму на экране
            politica_de_confidentialitate.FormClosed += (s, args) => this.Close();  // Закрываем главное окно, если Sign_Up закрыт
            politica_de_confidentialitate.Show();  // Показываем новую форму

            // Таймер для плавного появления новой формы
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler((s, ev) =>
            {
                if (politica_de_confidentialitate.Opacity < 1)
                    politica_de_confidentialitate.Opacity += 0.02;  // Увеличиваем прозрачность
                else
                    timer.Stop();  // Останавливаем таймер, когда форма становится полностью видимой
            });

            timer.Interval = 20;  // Интервал для плавной анимации
            timer.Start();  // Запускаем таймер
        }
        string connectionString = "Data Source=ScorQuiz.db";
        bool[] errors =
        {
            false, //проверка поля с именем
            false, //проверка уникальности имени
            false, //проверка длинны пароля
            false, //проверка символов пароля 
            false, //проверка совпадений паролей
            false, //проверка подтвержнения пользователя
        };
        bool errorsExist = false;
        private async void btn_sign_up_Click(object sender, EventArgs e)
        {
            CheckErrors();
            if (!errorsExist){
                CreateUser();
                for (double i = 1; i > 0; i -= 0.01)
                {
                    this.Opacity = i;
                    await Task.Delay(6);
                }

                this.Hide();  // Скрываем текущую форму

                // Создаем новую форму Sign_Up
                Sign_In sign_In = new Sign_In();
                sign_In.Opacity = 0;  // Начальная прозрачность формы 0 (невидима)
                sign_In.StartPosition = FormStartPosition.CenterScreen;  // Центрируем форму на экране
                sign_In.FormClosed += (s, args) => this.Close();  // Закрываем главное окно, если Sign_Up закрыт
                sign_In.Show();
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Tick += new EventHandler((s, ev) =>
                {
                    if (sign_In.Opacity < 1)
                        sign_In.Opacity += 0.02;  // Увеличиваем прозрачность
                    else
                        timer.Stop();  // Останавливаем таймер, когда форма становится полностью видимой
                });

                timer.Interval = 15;  // Интервал для плавной анимации
                timer.Start();
            }
            else DisplayErrors();
        }
        private void CreateUser()
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Users (Username, hashpsswd, premium) VALUES (@value1, @value2, 0)";
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@value1", guna2TextBox1.Text);
                    command.Parameters.AddWithValue("@value2", EncryptPassword(password_1.Text));
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("User Added");
                connection.Close();
            }
        }
        private string EncryptPassword(string input)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var inputHash = SHA256.HashData(inputBytes);
            return Convert.ToHexString(inputHash);
        }
        private void CheckErrors()
        {
            errorsExist = false;
            if (guna2TextBox1.Text.Length == 0) errors[0] = true;
            else
            {
                errors[0] = false;
                long userCount = 0;
                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @username";
                    SqliteCommand command = new SqliteCommand(query, connection);
                    command.Parameters.AddWithValue("@username", guna2TextBox1.Text);
                    userCount = (long)command.ExecuteScalar();
                }
                if (userCount != 0) errors[1] = true;
                else errors[1] = false;
            }
            if (password_1.Text.Length < 6) errors[2] = true;
            else
            {
                errors[2] = false;
                if (!Regex.IsMatch(password_1.Text, "[!@#$%^*()=+/*`.(){}|\\-\\[\\]]") || !Regex.IsMatch(password_1.Text, @"[A-Z]") || !Regex.IsMatch(password_1.Text, @"[a-z]") || !Regex.IsMatch(password_1.Text, @"\d"))
                    errors[3] = true;
                else
                {
                    errors[3] = false;
                    if (password_1.Text != password_2.Text) errors[4] = true;
                    else errors[4] = false;
                }
            }
            if (!guna2CustomCheckBox1.Checked) errors[5] = true;
            else errors[5] = false;
            foreach (bool error in errors) { Debug.WriteLine(error); if (error) errorsExist = true; }

        }
        private void DisplayErrors()
        {
            if (errors[0])
            {
                guna2TextBox1.BorderColor = Color.Red;

                pictureBox4.Visible = true;
                pictureBox4.ImageLocation = "../../../img/errors/Username/Numele de Utilizator este obligatoriu.png";
                guna2PictureBox3.ImageLocation = "../../../img/errors/InCorrect.png";
            }
            else if (errors[1])
            {
                guna2TextBox1.BorderColor = Color.Red;

                pictureBox4.Visible = true;
                pictureBox4.ImageLocation = "../../../img/errors/Username/Numele de Utilizator este deja utilizat.png";
                guna2PictureBox3.ImageLocation = "../../../img/errors/InCorrect.png";
            }
            else
            {
                guna2TextBox1.BorderColor = Color.FromArgb(213, 218, 223);

                pictureBox4.Visible = false;
                guna2PictureBox3.ImageLocation = "../../../img/errors/Correct.png";
            }
            if (errors[2])
            {
                password_1.BorderColor = Color.FromArgb(213, 218, 223);

                pictureBox1.Visible = true;
                pictureBox1.ImageLocation = "../../../img/errors/Password/Parola este prea scurtă.png";
                guna2PictureBox2.ImageLocation = "../../../img/errors/InCorrect.png";
            }
            else if (errors[3])
            {
                password_1.BorderColor = Color.Red;

                pictureBox1.Visible = true;
                pictureBox1.ImageLocation = "../../../img/errors/Password/Parola nu respectă cerințele de complexitate.png";
                guna2PictureBox2.ImageLocation = "../../../img/errors/InCorrect.png";
            }
            else if (errors[4])
            {
                password_2.BorderColor = Color.Red;

                pictureBox1.Visible = true;
                pictureBox1.ImageLocation = "../../../img/errors/Repeat Password/Parolele nu se potrivesc.png";
                guna2PictureBox1.ImageLocation = "../../../img/errors/InCorrect.png";
                guna2PictureBox2.ImageLocation = "../../../img/errors/Correct.png";
            }
            else
            {
                password_1.BorderColor = Color.FromArgb(213, 218, 223);

                password_2.BorderColor = Color.FromArgb(213, 218, 223);

                pictureBox1.Visible = false;
                guna2PictureBox1.ImageLocation = "../../../img/errors/Correct.png";
                guna2PictureBox2.ImageLocation = "../../../img/errors/Correct.png";
            }
            if (errors[5])
            {
                pictureBox5.Visible = true;
            }
            else pictureBox5.Visible = false;
        }
    }
}
