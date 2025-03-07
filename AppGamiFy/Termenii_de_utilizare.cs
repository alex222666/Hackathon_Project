﻿using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_CIH_CAHUL_BAC_SIGN_IN__SIGN_UP
{
    public partial class Termenii_de_utilizare : Form
    {
        private Image originalImage;  // Хранит исходное изображение

        public Termenii_de_utilizare()
        {
            InitializeComponent();

            // Сохраняем изначальное изображение для возврата после убирания курсора
            originalImage = next_1.Image;

            // Привязываем обработчики событий для PictureBox
            next_1.MouseEnter += new EventHandler(Next_1_MouseEnter);
            next_1.MouseLeave += new EventHandler(Next_1_MouseLeave);




            
        }

        // Когда курсор попадает на PictureBox
        private void Next_1_MouseEnter(object sender, EventArgs e)
        {
            // Меняем изображение на другую картинку
            next_1.Image = Image.FromFile("../../../img/Button_10.png");
        }

        // Когда курсор уходит с PictureBox
        private void Next_1_MouseLeave(object sender, EventArgs e)
        {
            // Возвращаем исходное изображение
            next_1.Image = originalImage;
        }

        private async void next_1_Click(object sender, EventArgs e)
        {
            // Плавное исчезновение текущей формы
            for (double i = 1; i > 0; i -= 0.01)
            {
                this.Opacity = i;
                await Task.Delay(6);
            }

            this.Hide();  // Скрываем текущую форму

            // Создаем новую форму Sign_Up
            Termenii_de_utilizare1 termenii_de_utilizare1 = new Termenii_de_utilizare1();
            termenii_de_utilizare1.Opacity = 0;  // Начальная прозрачность формы 0 (невидима)
            termenii_de_utilizare1.StartPosition = FormStartPosition.CenterScreen;  // Центрируем форму на экране
            termenii_de_utilizare1.FormClosed += (s, args) => this.Close();  // Закрываем главное окно, если Sign_Up закрыт
            termenii_de_utilizare1.Show();  // Показываем новую форму

            // Таймер для плавного появления новой формы
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler((s, ev) =>
            {
                if (termenii_de_utilizare1.Opacity < 1)
                    termenii_de_utilizare1.Opacity += 0.02;  // Увеличиваем прозрачность
                else
                    timer.Stop();  // Останавливаем таймер, когда форма становится полностью видимой
            });

            timer.Interval = 20;  // Интервал для плавной анимации
            timer.Start();  // Запускаем таймер
        }
    }
}
