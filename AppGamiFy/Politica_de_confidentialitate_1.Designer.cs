namespace APP_CIH_CAHUL_BAC_SIGN_IN__SIGN_UP
{
    partial class Politica_de_confidentialitate_1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Politica_de_confidentialitate_1));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            accept = new Guna.UI2.WinForms.Guna2PictureBox();
            panel_0 = new Guna.UI2.WinForms.Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)accept).BeginInit();
            panel_0.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 44;
            guna2Elipse1.TargetControl = this;
            // 
            // accept
            // 
            accept.BackgroundImage = (Image)resources.GetObject("accept.BackgroundImage");
            accept.BackgroundImageLayout = ImageLayout.None;
            accept.CustomizableEdges = customizableEdges1;
            accept.FillColor = Color.Transparent;
            accept.ImageRotate = 0F;
            accept.Location = new Point(389, 555);
            accept.Name = "accept";
            accept.ShadowDecoration.CustomizableEdges = customizableEdges2;
            accept.Size = new Size(185, 49);
            accept.TabIndex = 11;
            accept.TabStop = false;
            accept.Click += accept_Click;
            // 
            // panel_0
            // 
            panel_0.BackColor = Color.Transparent;
            panel_0.BackgroundImage = (Image)resources.GetObject("panel_0.BackgroundImage");
            panel_0.BackgroundImageLayout = ImageLayout.None;
            panel_0.Controls.Add(accept);
            panel_0.CustomizableEdges = customizableEdges3;
            panel_0.Location = new Point(3, 3);
            panel_0.Name = "panel_0";
            panel_0.ShadowDecoration.CustomizableEdges = customizableEdges4;
            panel_0.Size = new Size(951, 642);
            panel_0.TabIndex = 5;
            // 
            // Politica_de_confidentialitate_1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(958, 650);
            Controls.Add(panel_0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Politica_de_confidentialitate_1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Politica_de_confidentialitate_1";
            ((System.ComponentModel.ISupportInitialize)accept).EndInit();
            panel_0.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Panel panel_0;
        private Guna.UI2.WinForms.Guna2PictureBox accept;
    }
}