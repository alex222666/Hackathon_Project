namespace Fighting_Game
{
    partial class FightGame
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FightGame));
            timer1 = new System.Windows.Forms.Timer(components);
            panel1 = new Panel();
            btOption3 = new Button();
            btOption2 = new Button();
            btOption1 = new Button();
            time = new Label();
            lbQuestionText = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Interval = 10;
            timer1.Tick += JPunch_Tick;
            // 
            // panel1
            // 
            panel1.Controls.Add(btOption3);
            panel1.Controls.Add(btOption2);
            panel1.Controls.Add(btOption1);
            panel1.Controls.Add(time);
            panel1.Controls.Add(lbQuestionText);
            panel1.Location = new Point(0, 361);
            panel1.Name = "panel1";
            panel1.Size = new Size(644, 357);
            panel1.TabIndex = 60;
            // 
            // btOption3
            // 
            btOption3.Location = new Point(0, 258);
            btOption3.Name = "btOption3";
            btOption3.Size = new Size(638, 85);
            btOption3.TabIndex = 63;
            btOption3.Text = "Option3";
            btOption3.UseVisualStyleBackColor = true;
            btOption3.Click += btOption_Click;
            // 
            // btOption2
            // 
            btOption2.Location = new Point(3, 167);
            btOption2.Name = "btOption2";
            btOption2.Size = new Size(638, 85);
            btOption2.TabIndex = 62;
            btOption2.Text = "Option2";
            btOption2.UseVisualStyleBackColor = true;
            btOption2.Click += btOption_Click;
            // 
            // btOption1
            // 
            btOption1.Location = new Point(3, 76);
            btOption1.Name = "btOption1";
            btOption1.Size = new Size(638, 85);
            btOption1.TabIndex = 61;
            btOption1.Text = "Option1";
            btOption1.UseVisualStyleBackColor = true;
            btOption1.Click += btOption_Click;
            // 
            // time
            // 
            time.AutoSize = true;
            time.BackColor = Color.Black;
            time.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            time.ForeColor = Color.White;
            time.Location = new Point(523, 0);
            time.Name = "time";
            time.Size = new Size(118, 32);
            time.TabIndex = 57;
            time.Text = "00:00:10";
            // 
            // lbQuestionText
            // 
            lbQuestionText.Font = new Font("Comic Sans MS", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lbQuestionText.Location = new Point(0, 0);
            lbQuestionText.Name = "lbQuestionText";
            lbQuestionText.Size = new Size(517, 73);
            lbQuestionText.TabIndex = 34;
            lbQuestionText.Text = "Totate sarcinile sunt similare cu cele folosite la bac.";
            // 
            // FightGame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(639, 721);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FightGame";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GOKU";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private Panel panel1;
        public Label time;
        private Label lbQuestionText;
        private Button btOption3;
        private Button btOption2;
        private Button btOption1;
    }
}
