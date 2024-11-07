namespace APP_CIH_CAHUL_BAC
{
    partial class ActivationKey
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
            txtKey = new TextBox();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // txtKey
            // 
            txtKey.Location = new Point(51, 9);
            txtKey.Name = "txtKey";
            txtKey.Size = new Size(342, 27);
            txtKey.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(33, 20);
            label1.TabIndex = 1;
            label1.Text = "Key";
            // 
            // button1
            // 
            button1.Location = new Point(155, 46);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "Activate";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ActivationKey
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(405, 87);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(txtKey);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ActivationKey";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ActivationKey";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtKey;
        private Label label1;
        private Button button1;
    }
}