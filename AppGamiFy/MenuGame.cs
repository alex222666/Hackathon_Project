using APP_CIH_CAHUL_BAC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Fighting_Game
{
    public partial class MenuGame : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        MainPage _main;
        public MenuGame(MainPage main)
        {
            _main = main;
            if (!File.Exists("UndertaleOST.mp3")) File.Copy("../../../Music/UndertaleOST.mp3", "UndertaleOST.mp3");
            InitializeComponent();
            this.FormBorderStyle= FormBorderStyle.None;
            player.URL = "UndertaleOST.mp3";
            player.controls.play();
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile("../../../Photos/StartGame.png");
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.Image = Image.FromFile("../../../Photos/QuitGame.png");
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile("../../../Photos/StartGameNoP.png");
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Image.FromFile("../../../Photos/QuitGameNoP.png");
        }
        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            player.URL = "";
            player.controls.stop();
            FightGame game=new FightGame(_main);
            this.Hide();
            game.FormClosed += (s, args) => this.Close();
            game.Show();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            player.URL = "";
            _main.Visible = true;
            this.Close();
        }
    }
}
