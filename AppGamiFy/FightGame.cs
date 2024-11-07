using System.Windows.Forms;
using System;
using System.Windows.Forms.VisualStyles;
using System.Text.Json.Serialization;
using System.Drawing.Imaging;
using System.Media;
using WMPLib;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Winner;
using Lost;
using APP_CIH_CAHUL_BAC;
namespace Fighting_Game
{
    public partial class FightGame : Form
    {
        private Image Jotaro;
        private Image Boss;
        private Image Starplatinum;
        private int gif1FrameIndex = 0;
        private int gif2FrameIndex = 0;
        private int gif3FrameIndex = 0;
        private int gif1FrameCount;
        private int gif2FrameCount;
        private int gif3FrameCount;
        private System.Windows.Forms.Timer animationTimer;

        private System.Windows.Forms.Timer shakeTimer;
        private int shakeCount;
        private Point originalPosition;
        private Random random;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        System.Windows.Forms.Timer HealthTimer = new System.Windows.Forms.Timer();

        private int JXP=-60;
        private int BXP = 350;
        int JYP = 90;
        int BYP = 90;
        public WindowsMediaPlayer player;
        private int tmpbx;
        private int tmpby;
        private int tmpjx;
        private int tmpjy;
        HealthBar jhp;
        HealthBarBoss bhp;
        string dmgto;
        int numar;

        private System.Windows.Forms.Timer sptimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer spmoving = new System.Windows.Forms.Timer();
        private int spx;
        
        System.Windows.Forms.Timer spAtack = new System.Windows.Forms.Timer
        {
            Interval = 1400
        };

        System.Windows.Forms.Timer BossTimer = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer BossAttackTimer = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer secunde = new System.Windows.Forms.Timer {
            Interval = 1000
        };
        MainPage _main;
        public FightGame(MainPage main)
        {
            InitializeComponent();
            _main= main;
            tmpbx = BXP;
            tmpby = BYP;
            tmpjx = JXP;
            tmpjy = JYP;
            spmoving.Tick += spmoving_Tick;
            spmoving.Interval = 50;
            //spmoving.Start();

            sptimer.Tick += sptimer_Tick;
            sptimer.Interval = 1500;
            //sptimer.Start();

            ChangeImg(ref Jotaro, "Idle", "Jotaro");
            ChangeImg(ref Boss, "Idle", "Boss");
            Starplatinum = Image.FromFile($"../../../Jotaro/StarPlatinum.gif");
            gif1FrameCount = Jotaro.GetFrameCount(FrameDimension.Time);
            gif2FrameCount = Boss.GetFrameCount(FrameDimension.Time);
            gif3FrameCount=Starplatinum.GetFrameCount(FrameDimension.Time);
            DoubleBuffered = true;
            if (!File.Exists("1.mp3")) { File.Copy("../../../Music/1.mp3", "1.mp3"); }
            player=new WindowsMediaPlayer();
            player.URL="1.mp3";
            player.controls.play();
            player.settings.volume =20;

            DrawQuiz();

            animationTimer = new System.Windows.Forms.Timer { Interval = 100 }; // Adjust for desired frame rate
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
            shakeTimer = new System.Windows.Forms.Timer
            {
                Interval = 50 // Adjust to control the speed of the shake
            };
            spAtack.Tick += StopAnimation;
            shakeTimer.Tick += ShakeTimer_Tick;
            timer.Interval = 50;
            timer.Tick+=Moving_Tick;
            HealthTimer.Interval = 100;
            HealthTimer.Tick += HealthRemoval_Tick;
            ImageAnimator.Animate(Jotaro, new EventHandler(OnAnimationFrameChanged));
            ImageAnimator.Animate(Boss, new EventHandler(OnAnimationFrameChanged));
            BkMusic();
            secunde.Tick += new EventHandler((s, ev) =>
            {
                time.Text = dt.AddSeconds(timp).ToString("HH:mm:ss");
                if (timp == 0)
                {
                    secunde.Stop();
                    btOption1.Enabled = false;
                    btOption2.Enabled = false;
                    btOption3.Enabled = false;
                    GetHurt();
                }
                else timp--;
            });
            BossTimer.Interval = 50;
            BossTimer.Tick += BossWalking;
            jhp = new HealthBar
            {
                Location = new Point(40, 20),
                Size = new Size(200, 20),
                Health = 100 // Start at full health
            };
            Controls.Add(jhp);
            bhp = new HealthBarBoss
            {
                Location = new Point(400, 20),
                Size = new Size(200, 20),
                Health = 100 // Start at full health
            };
            Controls.Add(bhp);
        }
        public void spmoving_Tick(object sender, EventArgs e)
        {
            spx += numar;
            numar -= 1;
        }
        public void sptimer_Tick(object sender, EventArgs e)
        {
            ImageAnimator.StopAnimate(Starplatinum, new EventHandler(OnAnimationFrameChanged));
            sptimer.Stop();
            spmoving.Stop();
        }
        private void BkMusic()
        {
            player.controls.play();
        }
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            // Advance the frames for each GIF
            gif1FrameIndex = (gif1FrameIndex + 1) % gif1FrameCount;
            gif2FrameIndex = (gif2FrameIndex + 1) % gif2FrameCount;
            gif3FrameIndex = (gif3FrameIndex + 1) % gif3FrameCount;

            // Request a repaint
            Invalidate();
        }
        private void OnAnimationFrameChanged(object sender, EventArgs e)
        {
            // Request a repaint whenever the animation frame changes
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ImageAnimator.UpdateFrames(Jotaro);
            ImageAnimator.UpdateFrames(Boss);
            ImageAnimator.UpdateFrames(Starplatinum);
            try
            {
                e.Graphics.DrawImage(Jotaro, new Rectangle(JXP, JYP, 350, 350)); // Resized position of the first GIF
                e.Graphics.DrawImage(Boss, new Rectangle(BXP, BYP, 350, 350));
                e.Graphics.DrawImage(Starplatinum, new Rectangle(spx, 180, 170, 170)); // Resized position of the second GIF
            }
            catch
            {
                this.Close();
            }
        }
        public Image ChangeImg(ref Image img,string action,string Character)
        {
            Image image;
            using (Stream stream = File.OpenRead($"../../../{Character}/{Character}{action}.gif"))
            {
                image = System.Drawing.Image.FromStream(stream);
            }
            img = Image.FromFile($"../../../{Character}/{Character}{action}.gif");
            return img;
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
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Dispose of images to free resources
            player.URL = "";
            secunde.Stop();
            _main.Visible = true;
            Jotaro.Dispose();
            Boss.Dispose();
            Starplatinum.Dispose();
            ImageAnimator.StopAnimate(Jotaro, new EventHandler(OnAnimationFrameChanged));
            ImageAnimator.StopAnimate(Boss, new EventHandler(OnAnimationFrameChanged));
            ImageAnimator.StopAnimate(Starplatinum, new EventHandler(OnAnimationFrameChanged));
            _main.Show();
            base.OnFormClosing(e);
        }
        private void JPunch_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            spAtack.Start();
            SoundPlayer tmp = new SoundPlayer("../../../Music/ORA.wav");
            tmp.Play();
            HealthTimer.Start();  
        }
        public void Fight()
        {
            secunde.Stop();
            timer.Start();
            //Point tmp = Jotaro.Location;
            ChangeImg(ref Jotaro, "Walking", "Jotaro");
            ImageAnimator.Animate(Jotaro, new EventHandler(OnAnimationFrameChanged));
        }
        public Image img;
        public void TriggerShakeEffect(Image characterimg)
        {
            img= characterimg;
            shakeCount = 0; // Reset shake count
            shakeTimer.Start(); // Start shaking
        }
        private void Moving_Tick(object sender, EventArgs e)
        {
            JXP += 7;
            if (JXP > 200)
            {
                timer.Stop();
                timer1.Start();
                ChangeImg(ref Jotaro, "Punching", "Jotaro");
                ImageAnimator.Animate(Jotaro, new EventHandler(OnAnimationFrameChanged));
                ImageAnimator.Animate(Starplatinum, new EventHandler(OnAnimationFrameChanged));
                SoundPlayer simpleSound = new SoundPlayer(@"../../../Music/getSerios.wav");
                simpleSound.Play();
                TriggerShakeEffect(Boss);
                spx = JXP + 100;
                sptimer.Start();
                spmoving.Start();
                
                dmgto = "Boss";
                dmg = 10;
                
                numar = 10;
            }
        }
        
        public void StopAnimation(object sender, EventArgs e)
        {
            ChangeImg(ref Jotaro, "Idle", "Jotaro");
            ImageAnimator.Animate(Jotaro, new EventHandler(OnAnimationFrameChanged));
            spAtack.Stop();
        }
        private void ShakeTimer_Tick(object sender, EventArgs e)
        {
            ImageAnimator.StopAnimate(img, new EventHandler(OnAnimationFrameChanged));
            random =new Random();
            if (shakeCount < 20) // Adjust the shake duration by changing the max count
            {
                // Generate a small random offset to move the PictureBox
                int offsetX = random.Next(-10, 10);
                int offsetY = random.Next(-5, 6);
                shakeCount++;
                if (img == Jotaro)
                {
                    JXP += offsetX;
                    JYP += offsetY;
                }
                else
                {
                    BXP += offsetX;
                    BYP += offsetY;
                }
            }
            else
            {
                JXP = tmpjx;
                JYP = tmpjy;
                BXP = tmpbx;
                BYP = tmpby;
                // Stop shaking and reset to the original position
                shakeTimer.Stop();
                timp = 10;   
                ImageAnimator.Animate(img, new EventHandler(OnAnimationFrameChanged));
                DrawQuiz();
            }
        }
        

        public void GetHurt()
        {
            secunde.Stop();
            BossTimer.Start();
            BossAttackTimer.Interval = 1100;
            BossAttackTimer.Tick += BossAttack;
            ChangeImg(ref Boss, "Walking", "Boss");
            timp = 10;
            ImageAnimator.Animate(Boss, new EventHandler(OnAnimationFrameChanged));
        }
        public void BossWalking(object sender,EventArgs e) {
            BXP -= 13;
            if (BXP < 90)
            {
                BossTimer.Stop();
                BossAttackTimer.Start();
                ChangeImg(ref Boss, "Punching", "Boss");
                SoundPlayer slash = new SoundPlayer("../../../sounds/slash.wav");
                slash.Play();
                ImageAnimator.Animate(Boss, new EventHandler(OnAnimationFrameChanged));
            }
        }
        
        int dmg = 10;
        public void BossAttack(object sender,EventArgs e)
        {
            ChangeImg(ref Boss, "Idle", "Boss");
            ImageAnimator.Animate(Boss, new EventHandler(OnAnimationFrameChanged));
            BossAttackTimer.Stop();
            TriggerShakeEffect(Jotaro);
            HealthTimer.Start();
            dmgto = "Jotaro";
            dmg = 2;
        }
        public void HealthRemoval(ref HealthBar healthBar)
        {
            if(dmg>=1) dmg-=2;
            else
            {
                HealthTimer.Stop();
            }
            healthBar.Health -= 5;
            //Winner
            if (healthBar.Health == 0)
            {
                player.URL = "";
                LostGame frame = new LostGame(this,_main);
                frame.Show();
                secunde=new System.Windows.Forms.Timer();
                this.Visible = false;
            }
        }
        public void HealthRemoval(ref HealthBarBoss healthBar)
        {
            if (dmg != 1) dmg--;
            else
            {
                HealthTimer.Stop();
            }
            healthBar.Health--;

            //Winner
            if(healthBar.Health == 0)
            {
                player.URL = "";
                JotaroWinning frame = new JotaroWinning(this,_main);
                secunde=new System.Windows.Forms.Timer();
                frame.Show();
            }
        }
        public void HealthRemoval_Tick(object sender,EventArgs e)
        {
            if (dmgto == "Jotaro") HealthRemoval(ref jhp);
            else HealthRemoval(ref bhp);
        }
        database1 db=new database1();
        Intrebare tmp = new Intrebare();
        DateTime dt = new DateTime();
        int timp = 10;
        public void DrawQuiz()
        {
            secunde.Start();
            Random random = new Random();
            int id = random.Next(1, 100);
            tmp=db.getQuiz(_main.materie, id);
            lbQuestionText.Text = tmp.questionText;
            btOption1.Text = tmp.Raspunsuri[0];
            btOption2.Text = tmp.Raspunsuri[1];
            btOption3.Text = tmp.Raspunsuri[2];
            btOption1.Enabled = true;
            btOption2.Enabled = true;
            btOption3.Enabled = true;

        }
        public void btOption_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == tmp.Corecte)
            {
                Fight();
            }
            else
            {
                GetHurt();
            }
            btOption1.Enabled = false;
            btOption2.Enabled = false;
            btOption3.Enabled = false;
        }
    }
}
