namespace WB_postavki
{
    partial class FormPodsorti
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPodsorti));
            btnOpen = new ReaLTaiizor.Controls.Button();
            btnSave = new ReaLTaiizor.Controls.Button();
            button2 = new ReaLTaiizor.Controls.Button();
            SuspendLayout();
            // 
            // btnOpen
            // 
            btnOpen.BackColor = Color.Transparent;
            btnOpen.BackgroundImage = (Image)resources.GetObject("btnOpen.BackgroundImage");
            btnOpen.BackgroundImageLayout = ImageLayout.None;
            btnOpen.BorderColor = Color.FromArgb(32, 34, 37);
            btnOpen.EnteredBorderColor = Color.FromArgb(165, 37, 37);
            btnOpen.EnteredColor = Color.FromArgb(32, 34, 37);
            btnOpen.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnOpen.Image = (Image)resources.GetObject("btnOpen.Image");
            btnOpen.ImageAlign = ContentAlignment.MiddleCenter;
            btnOpen.InactiveColor = Color.FromArgb(32, 34, 37);
            btnOpen.Location = new Point(12, 12);
            btnOpen.Name = "btnOpen";
            btnOpen.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnOpen.PressedColor = Color.FromArgb(165, 37, 37);
            btnOpen.Size = new Size(45, 45);
            btnOpen.TabIndex = 0;
            btnOpen.TextAlignment = StringAlignment.Center;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Transparent;
            btnSave.BackgroundImage = (Image)resources.GetObject("btnSave.BackgroundImage");
            btnSave.BackgroundImageLayout = ImageLayout.None;
            btnSave.BorderColor = Color.FromArgb(32, 34, 37);
            btnSave.EnteredBorderColor = Color.FromArgb(165, 37, 37);
            btnSave.EnteredColor = Color.FromArgb(32, 34, 37);
            btnSave.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            btnSave.ImageAlign = ContentAlignment.MiddleCenter;
            btnSave.InactiveColor = Color.FromArgb(32, 34, 37);
            btnSave.Location = new Point(63, 12);
            btnSave.Name = "btnSave";
            btnSave.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnSave.PressedColor = Color.FromArgb(165, 37, 37);
            btnSave.Size = new Size(45, 45);
            btnSave.TabIndex = 0;
            btnSave.TextAlignment = StringAlignment.Center;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.BorderColor = Color.FromArgb(32, 34, 37);
            button2.EnteredBorderColor = Color.FromArgb(165, 37, 37);
            button2.EnteredColor = Color.FromArgb(32, 34, 37);
            button2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleCenter;
            button2.InactiveColor = Color.FromArgb(32, 34, 37);
            button2.Location = new Point(114, 12);
            button2.Name = "button2";
            button2.PressedBorderColor = Color.FromArgb(165, 37, 37);
            button2.PressedColor = Color.FromArgb(165, 37, 37);
            button2.Size = new Size(45, 45);
            button2.TabIndex = 0;
            button2.TextAlignment = StringAlignment.Center;
            // 
            // FormPodsorti
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(btnSave);
            Controls.Add(btnOpen);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormPodsorti";
            Text = "FormPodsorti";
            FormClosed += FormPodsorti_FormClosed;
            Load += FormPodsorti_Load;
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.Button btnOpen;
        private ReaLTaiizor.Controls.Button btnSave;
        private ReaLTaiizor.Controls.Button button2;
    }
}