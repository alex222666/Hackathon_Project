using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_CIH_CAHUL_BAC_SIGN_IN__SIGN_UP
{
    public partial class Termenii_de_utilizare1 : Form
    {
        private Image originalImage;  // Хранит исходное изображение 

        public Termenii_de_utilizare1()
        {
            InitializeComponent();

            // Сохраняем изначальное изображение для возврата после убирания курсора
            originalImage = accept.Image;

            // Привязываем обработчики событий для PictureBox
            accept.MouseEnter += new EventHandler(Accept_MouseEnter);
            accept.MouseLeave += new EventHandler(Accept_MouseLeave);
        }

        // Когда курсор попадает на PictureBox
        private void Accept_MouseEnter(object sender, EventArgs e)
        {
            // Меняем изображение на другую картинку
            accept.Image = Image.FromFile("../../../img/Button_12.png");
        }

        // Когда курсор уходит с PictureBox
        private void Accept_MouseLeave(object sender, EventArgs e)
        {
            // Возвращаем исходное изображение
            accept.Image = originalImage;
        }

        private async void accept_Click(object sender, EventArgs e)
        {
            // Плавное исчезновение текущей формы
            for (double i = 1; i > 0; i -= 0.01)
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
                    sign_Up.Opacity += 0.02;  // Увеличиваем прозрачность
                else
                    timer.Stop();  // Останавливаем таймер, когда форма становится полностью видимой
            });

            timer.Interval = 20;  // Интервал для плавной анимации
            timer.Start();  // Запускаем таймер
        }
    }
}
