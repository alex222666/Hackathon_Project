using System.Windows.Forms;

namespace APP_CIH_CAHUL_BAC_SIGN_IN__SIGN_UP
{
    public partial class StartUp : Form
    {
        private Image originalImageSignUp;  // Original image for Sign Up button
        private Image originalImageSignIn;   // Original image for Sign In button

        public StartUp()
        {
            InitializeComponent();
            this.Opacity = 0;  
            this.StartPosition = FormStartPosition.CenterScreen;  
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler((sender, e) =>
            {
                if (this.Opacity < 1)
                    this.Opacity += 0.02;
                else
                    timer.Stop();
            });
            timer.Interval = 20;  
            timer.Start();  


            // Store original images for both buttons
            originalImageSignUp = btn_sign_up.Image;
            originalImageSignIn = btn_sign_in.Image;

            // Bind mouse event handlers for both buttons
            btn_sign_up.MouseEnter += new EventHandler(Btn_sign_up_MouseEnter);
            btn_sign_up.MouseLeave += new EventHandler(Btn_sign_up_MouseLeave);

        }

        // When mouse enters the Sign Up button
        private void Btn_sign_up_MouseEnter(object sender, EventArgs e)
        {
            // Change image for Sign Up button
            btn_sign_up.Image = Image.FromFile("../../../img/Button_6.png");
            // Change image for Sign In button
            btn_sign_in.Image = Image.FromFile("../../../img/Button_5.png"); // Update path as needed
        }

        // When mouse leaves the Sign Up button
        private void Btn_sign_up_MouseLeave(object sender, EventArgs e)
        {
            // Restore original image for Sign Up button
            btn_sign_up.Image = originalImageSignUp;
            // Restore original image for Sign In button
            btn_sign_in.Image = originalImageSignIn;
        }

        

        private async void close_lbl_Click(object sender, EventArgs e)
        {
            for (double i = 1; i > 0; i -= 0.01)
            {
                this.Opacity = i;
                await Task.Delay(6);
            }
            this.Close();
        }

        private async void btn_sign_in_Click(object sender, EventArgs e)
        {
            for (double i = 1; i > 0; i -= 0.01)
            {
                this.Opacity = i;
                await Task.Delay(6);
            }

            this.Hide();

            Sign_In sign_In = new Sign_In();
            sign_In.Opacity = 0;  
            sign_In.StartPosition = FormStartPosition.CenterScreen;
            sign_In.FormClosed += (s, args) => this.Close();  
            sign_In.Show();  

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler((s, ev) =>
            {
                if (sign_In.Opacity < 1)
                    sign_In.Opacity += 0.02;  
                else
                    timer.Stop();  
            });

            timer.Interval = 20;  
            timer.Start();  
        }

        private async void btn_sign_up_Click(object sender, EventArgs e)
        {
            for (double i = 1; i > 0; i -= 0.01)
            {
                this.Opacity = i;
                await Task.Delay(6);
            }

            this.Hide();
            Sign_Up sign_Up = new Sign_Up();
            sign_Up.Opacity = 0;
            sign_Up.StartPosition = FormStartPosition.CenterScreen;  
            sign_Up.FormClosed += (s, args) => this.Close();  
            sign_Up.Show(); 

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler((s, ev) =>
            {
                if (sign_Up.Opacity < 1)
                    sign_Up.Opacity += 0.02; 
                else
                    timer.Stop();  
            });

            timer.Interval = 20;  
            timer.Start();
        }
    }
}
